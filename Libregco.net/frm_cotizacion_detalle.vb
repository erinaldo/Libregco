Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports System.Drawing.Printing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportAppServer
Public Class frm_cotizacion_detalle
    Friend IDCotizacion As New Label
    Dim sqlQ As String = ""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim Permisos As New ArrayList
    Dim btnPushed As String
    Friend ChangedCodeEmployee As Boolean

    Private Sub frm_cotizacion_detalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.WindowState = CheckWindowState()
        ChangedCodeEmployee = False
        lblStatusBar.Text = "Listo"

        If LookEmployeesValidated(DtEmpleado.Rows(0).item("IDEmpleado").ToString()) = 1 Then
            txtIDVendedor.Text = DtEmpleado.Rows(0).item("IDEmpleado").ToString()
            txtVendedor.Text = frm_inicio.lblNombre.Text
        End If

        If txtIDCliente.Text = 1 Then
            txtNombre.Enabled = True
            txtRNC.Enabled = True
        Else
            txtNombre.Enabled = False
            txtRNC.Enabled = False
        End If

        txtNombre.Focus()
        txtNombre.SelectAll()
    End Sub

    Private Sub btnContinuar_Click(sender As Object, e As EventArgs) Handles btnContinuar.Click
        Try
            btnPushed = sender.Name

            If txtIDCliente.Text = 1 Then
                If txtNombre.Text = "" Then
                    txtNombre.Text = "CONTADO"
                End If
            End If

            Dim TRN As String = txtRNC.Text.Replace("-", "").Trim
            If TRN.Length = 0 Then
                txtRNC.Text = ""
            End If

            DgvNombre.Visible = False

            If frm_cotizacion_nw.txtIDCotizacion.Text = "" Then
                If frm_cotizacion_nw.RNCInteligente = 1 Then
                    If txtNombre.Text.Contains("SRL") Or txtNombre.Text.Contains("S.R.L") Or txtNombre.Text.Contains("EIRL") Or txtNombre.Text.Contains("E.I.R.L") Or txtNombre.Text.Contains("S.A") Or txtNombre.Text.Contains(" S A") Or txtNombre.Text.Contains("CXA") Or txtNombre.Text.Contains("C.X.A") Or txtNombre.Text.Contains("C POR A") And rdbCreditoFiscal.Checked = False Then
                        rdbCreditoFiscal.Checked = True
                        lblStatusBar.Text = "El tipo de comprobante fiscal se ha cambiado a " & txtTipoNcf.Text & "."
                    End If
                End If
            End If

            If txtIDCliente.Text = "" Then
                lblStatusBar.Text = "Verificando código del cliente..."
                MessageBox.Show("Seleccione el cliente para procesar la cotización.", "No se ha específicado el cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                btnBuscarCliente.PerformClick()
                Exit Sub
            ElseIf txtNombre.Text = "" Then
                lblStatusBar.Text = "Verificando nombre del cliente..."
                MessageBox.Show("Escriba el nombre del cliente de la cotización a procesar.", "Nombre del cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtNombre.Focus()
                Exit Sub

            ElseIf Len(txtNombre.Text) < 3 Then
                lblStatusBar.Text = "Verificando validez del cliente..."
                MessageBox.Show("Escriba un nombre válido para generar la cotización.", "Nombre no válido", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtNombre.Focus()
                txtNombre.SelectAll()
                Exit Sub

            ElseIf frm_cotizacion_nw.SolicitarNombreCliente = 1 And txtNombre.Text.Contains("CONTADO") And CDbl(txtNeto.Text) > CDbl(frm_cotizacion_nw.LimiteSolNombre) Then
                lblStatusBar.Text = "Verificando requerimientos del monto de la factura..."
                MessageBox.Show("El monto total de la factura (" & txtNeto.Text & ") " & "excede el límite máximo establecido (" & CDbl(frm_cotizacion_nw.LimiteSolNombre).ToString("C") & ") para facturas sin el respectivo nombre del cliente." & vbNewLine & vbNewLine & "Por favor escriba el nombre del cliente para continuar con la factura.", "Escriba el nombre del cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                lblStatusBar.Text = "El monto total de la factura (" & txtNeto.Text & ") " & "excede el límite máximo establecido (" & CDbl(frm_cotizacion_nw.LimiteSolNombre).ToString("C") & ") para facturas sin el respectivo nombre del cliente"
                txtNombre.Focus()
                txtNombre.SelectAll()
                Exit Sub

            ElseIf txtVendedor.Text = "" Or txtIDVendedor.Text = "" Then
                lblStatusBar.Text = "Verificando información del vendedor..."
                If txtIDVendedor.Text <> "" Then
                    txtIDVendedor.Clear()
                End If
                MessageBox.Show("Escriba el código del vendedor para registrar la cotización.", "Código del vendedor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtIDVendedor.Focus()

                Exit Sub
            ElseIf txtIDCondicion.Text = "" Then
                lblStatusBar.Text = "Verificando condición de la venta..."
                MessageBox.Show("Seleccione el tipo de condición de la cotización.", "Condición de cotización", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                btnCondicion.PerformClick()
                Exit Sub

            ElseIf txtIDNcf.Text = "" Then
                lblStatusBar.Text = "Verificando comprobante fiscal..."
                MessageBox.Show("Seleccione el tipo de comprobante a fiscal que desea generar.", "Tipo de Comprobante Fiscal", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                btnNcf.PerformClick()
                Exit Sub

            ElseIf rdbCreditoFiscal.Checked = True Or txtIDNcf.Text <> 2 Then
                lblStatusBar.Text = "Verificando integridad de datos para crédito fiscal..."
                Dim RN As String = txtRNC.Text.Replace("-", "").Trim

                If RN = "" Then
                    MessageBox.Show("Se ha detectado que la factura a procesar posee comprobante fiscal." & vbNewLine & vbNewLine & "Por favor específique el RNC o cédula de identidad para continuar con la cotización.", "RNC Vacío", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    txtRNC.Focus()
                    txtRNC.SelectAll()
                    Exit Sub

                ElseIf frm_cotizacion_nw.CantidadCaracteresRNC.Contains(RN.Length) = False Then
                    MessageBox.Show("Se ha detectado que la factura a procesar posee comprobante fiscal." & vbNewLine & vbNewLine & "Por favor complete el RNC o cédula de identidad para continuar con la cotización.", "RNC no completado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    txtRNC.Focus()
                    txtRNC.SelectAll()
                    Exit Sub
                End If
            End If

            If txtIDCliente.Text <> 1 Then
                Dim dstemp As New DataSet

                ConLibregco.Open()
                cmd = New MySqlCommand("SELECT Clientes.IDComprobanteFiscal,ComprobanteFiscal.TipoComprobante FROM libregco.clientes inner join libregco.ComprobanteFiscal on Clientes.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal Where Clientes.IDCliente='" + txtIDCliente.Text + "'", ConLibregco)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(dstemp, "ComprobanteFiscal")
                ConLibregco.Close()

                Dim Tabla As DataTable = dstemp.Tables("ComprobanteFiscal")

                If txtIDNcf.Text <> Tabla.Rows(0).Item("IDComprobanteFiscal") Then
                    frm_alerta_tipocomprobante.lblComprobanteRecomendado.Tag = Tabla.Rows(0).Item("IDComprobanteFiscal")
                    frm_alerta_tipocomprobante.lblComprobanteRecomendado.Text = Tabla.Rows(0).Item("TipoComprobante")
                    frm_alerta_tipocomprobante.lblComprobanteElegido.Tag = txtIDNcf.Text
                    frm_alerta_tipocomprobante.lblComprobanteElegido.Text = txtTipoNcf.Text
                    frm_alerta_tipocomprobante.ShowDialog(Me)
                End If

                Tabla.Dispose()
                dstemp.Dispose()
            End If

            If CDbl(txtIDCondicion.Text) > 2 And txtIDCliente.Text = 1 Then
                lblStatusBar.Text = "Verificando integridad de la factura vs condición de facturación..."
                MessageBox.Show("No existe la posibilidad de realizar facturas a crédito con el código de contado." & vbNewLine & vbNewLine & "Verifique el código del cliente que esta utilizando en este proceso.", "Código de cliente no válido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            Dim Result As MsgBoxResult = MessageBox.Show("Este es el último paso para procesar la cotización." & vbNewLine & vbNewLine & "Está seguro que desea continuar?", "Procesar cotización", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then

                If rdbGubernamental.Checked = True Then
                    Dim Result1 As MsgBoxResult = MessageBox.Show("Está seguro que desea generar una factura con el comprobante del tipo" & vbNewLine & vbNewLine & rdbGubernamental.Text.ToUpper & "?", "NCF Gubernamental", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    If Result1 = MsgBoxResult.No Then
                        Exit Sub
                    End If
                ElseIf rdbRegimenEsp.Checked = True Then
                    Dim Result1 As MsgBoxResult = MessageBox.Show("Está seguro que desea generar una factura con el comprobante del tipo" & vbNewLine & vbNewLine & rdbRegimenEsp.Text.ToUpper & "?", "NCF Régimen Especial", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    If Result1 = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If


                ControlSuperClave = 0
                frm_cotizacion_nw.txtNombre.Text = txtNombre.Text
                frm_cotizacion_nw.txtIDCondicion.Text = txtIDCondicion.Text
                txtNombre.Focus()
                Close()
            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        frm_buscar_clientes.ShowDialog(Me)

        If txtIDCliente.Text = 1 Then
            txtNombre.Enabled = True
            txtRNC.Enabled = True
        Else
            txtNombre.Enabled = False
            txtRNC.Enabled = False
        End If
    End Sub

    Private Sub btnVendedor_Click(sender As Object, e As EventArgs) Handles btnVendedor.Click
        DgvNombre.Visible = False
        frm_vendedor_prefacturacion.cbxVendedor.Focus()
        frm_vendedor_prefacturacion.ShowDialog(Me)
    End Sub

    Private Sub btnCondicion_Click(sender As Object, e As EventArgs) Handles btnCondicion.Click
        DgvNombre.Visible = False
        frm_buscar_condicion.ShowDialog(Me)
    End Sub

    Private Sub btnNcf_Click(sender As Object, e As EventArgs) Handles btnNcf.Click
        DgvNombre.Visible = False
        frm_buscar_tipo_comprobantes.ShowDialog(Me)
    End Sub

    Private Sub rdbCreditoFiscal_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCreditoFiscal.CheckedChanged
        If rdbCreditoFiscal.Checked = True Then
            txtIDNcf.Text = 1
            txtTipoNcf.Text = "Crédito Fiscal"
        End If
    End Sub

    Private Sub rdbConsumidorFin_CheckedChanged(sender As Object, e As EventArgs) Handles rdbConsumidorFin.CheckedChanged
        If rdbConsumidorFin.Checked = True Then
            txtIDNcf.Text = 2
            txtTipoNcf.Text = "Consumidor Final"
        End If
    End Sub

    Private Sub rdbRegimenEsp_CheckedChanged(sender As Object, e As EventArgs) Handles rdbRegimenEsp.CheckedChanged
        If rdbRegimenEsp.Checked = True Then
            txtIDNcf.Text = 8
            txtTipoNcf.Text = "Regímenes Especiales de Tributación"
        End If
    End Sub

    Private Sub rdbGubernamental_CheckedChanged(sender As Object, e As EventArgs) Handles rdbGubernamental.CheckedChanged
        If rdbGubernamental.Checked = True Then
            txtIDNcf.Text = 9
            txtTipoNcf.Text = "Comprobante Gubernamental"
        End If
    End Sub

    Private Sub txtIDVendedor_Leave(sender As Object, e As EventArgs) Handles txtIDVendedor.Leave
        If txtIDVendedor.Text <> "" Then
            If LookEmployeesValidated(txtIDVendedor.Text) = 0 Then
                If ChangedCodeEmployee = True And txtIDVendedor.Text <> "" Then
                    frm_vendedor_prefacturacion.cbxVendedor.Focus()
                    frm_vendedor_prefacturacion.ShowDialog(Me)

                Else
                    If txtIDVendedor.Text <> "" Then
                        If txtVendedor.Text = "" Then
                            frm_vendedor_prefacturacion.ShowDialog(Me)
                        End If
                    Else
                        txtIDVendedor.Clear()
                        txtVendedor.Clear()
                    End If
                End If


            Else
                ConLibregco.Open()
                cmd = New MySqlCommand("Select Nombre from Empleados Where IDEmpleado='" + txtIDVendedor.Text + "'", ConLibregco)
                txtVendedor.Text = Convert.ToString(cmd.ExecuteScalar())
                ConLibregco.Close()

                If txtVendedor.Text = "" Then txtIDVendedor.Clear()

            End If

        Else
            txtIDVendedor.Clear()
            txtVendedor.Clear()
        End If

    End Sub

    Private Sub txtIDVendedor_TextChanged(sender As Object, e As EventArgs) Handles txtIDVendedor.TextChanged
        ChangedCodeEmployee = True
    End Sub

    Private Sub txtIDCondicion_Leave(sender As Object, e As EventArgs) Handles txtIDCondicion.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Condicion from Condicion Where IDCondicion='" + txtIDCondicion.Text + "'", ConLibregco)
        txtCondicion.Text = Convert.ToString(cmd.ExecuteScalar()).ToUpper

        cmd = New MySqlCommand("Select Dias from Condicion Where IDCondicion='" + txtIDCondicion.Text + "'", ConLibregco)
        txtIDCondicion.Tag = Convert.ToString(cmd.ExecuteScalar()).ToUpper
        ConLibregco.Close()

        If txtCondicion.Text = "" Then
            txtIDCondicion.Clear()
            txtIDCondicion.Tag = ""
        End If
    End Sub

    Private Sub txtIDNcf_Leave(sender As Object, e As EventArgs) Handles txtIDNcf.Leave
        Con.Open()
        cmd = New MySqlCommand("Select TipoComprobante from ComprobanteFiscal Where IDComprobanteFiscal='" + txtIDNcf.Text + "'", Con)
        txtTipoNcf.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
        If txtTipoNcf.Text = "" Then txtIDNcf.Clear()

        If txtIDNcf.Text = "1" Then
            rdbCreditoFiscal.Checked = True
        ElseIf txtIDNcf.Text = "2" Then
            rdbConsumidorFin.Checked = True
        ElseIf txtIDNcf.Text = "8" Then
            rdbRegimenEsp.Checked = True
        ElseIf txtIDNcf.Text = "9" Then
            rdbGubernamental.Checked = True
        Else
            txtIDNcf.Clear()
            txtTipoNcf.Clear()
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        btnPushed = sender.Name

        Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea cancelar la cotización?", "Detener proceso de cotización", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If Result = MsgBoxResult.Yes Then
            ControlSuperClave = 1
            MessageBox.Show("Se canceló el registro al pago de factura.", "La Factura no se procesó", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Close()
        Else
            Exit Sub
        End If
    End Sub



    Private Sub txtRNC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRNC.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "0123456789-"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "abcdefghijklmnñopqrstuvwxyz0123456789., "
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtDireccion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDireccion.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "abcdefghijklmnñopqrstuvwxyz0123456789#., "
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtTelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefono.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "-0123456789 "
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtRNC_Leave(sender As Object, e As EventArgs) Handles txtRNC.Leave
        Try
            Dim Cedula As New Label
            Cedula.Text = Replace(txtRNC.Text, "-", "").Replace(" ", "")

            If Cedula.Text = "" Then
            Else
                Ds.Clear()
                ConLibregco.Open()
                cmd = New MySqlCommand("SELECT IDCliente,Clientes.Nombre,Clientes.Apodo,Clientes.IDNacionalidad,Nacionalidad,Clientes.IDTipoIdentificacion,Identificacion,TipoIdentificacion.Descripcion as TipoIdentificacion,Clientes.IDGenero,Genero,Clientes.FechaNacimiento,LugarNacimiento,Clientes.IDProvincia,Provincia,Clientes.IDMunicipio,Municipio,Clientes.Direccion,Referencia,Clientes.TelefonoPersonal,Clientes.TelefonoHogar,Clientes.CorreoElectronico,Clientes.IDOcupacion,OcupacionCliente.Ocupacion as OcupacionCliente,LugarTrabajo,UbicacionTrabajo,TelefonoTrabajo,PadreCliente,MadreCliente,DomicilioPaternos,TelefonoPaternos,Clientes.IDCivil,Estadocivil,Conyuge,TelefonoConyuge,IDOcupacionConyuge,OcupacionConyuge.Ocupacion as OcupacionConyuge,LugarTrabajoConyuge,PadreConyuge,MadreConyuge,DomicilioPatConyuge,TelefonoPatConyuge,Clientes.IDCalificacion,Calificacion,CalificacionAutonoma,DiasCondicion,LimiteCredito,Clientes.IDGrupocxc,Grupocxc.Descripcion as GrupoCxc,Clientes.IDTipoCredito,Clientes.IDTipoCredito,TipoCredito.Descripcion as TipoCredito,Clientes.IDEmpleado,Empleados.Nombre as NombreEmpleado,Clientes.IDComprobanteFiscal,ComprobanteFiscal.TipoComprobante,InformacionAdc,Clientes.EntregarPorConduce,Clientes.Alertas,Clientes.FechaIngreso,NoRecibirCheques,CuentaIncobrable,GenerarCargo,CerrarCredito,EntregarPorConduce,BalanceGeneral,Desactivar,ifnull((Select Fecha from Abonos where IDCliente=Clientes.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago,(LimiteCredito-BalanceGeneral) as CreditoDisponible FROM clientes INNER JOIN Calificacion on Clientes.IDCalificacion=Calificacion.IDCalificacion INNER JOIN Empleados on Clientes.IDEmpleado=Empleados.IDEmpleado INNER JOIN Ocupacion as OcupacionConyuge on Clientes.IDOcupacionConyuge=OcupacionConyuge.IDOcupacion INNER JOIN estadocivil on Clientes.IDCivil=EstadoCivil.IDCivil INNER JOIN Ocupacion as OcupacionCliente on Clientes.IDOcupacion=OcupacionCliente.IDOcupacion INNER JOIN Provincias on Clientes.IDProvincia=Provincias.IDProvincia INNER JOIN Municipios on Clientes.IDMunicipio=Municipios.IDMunicipio INNER JOIN genero on Clientes.IDGenero=Genero.IDGenero INNER JOIN Nacionalidad on Clientes.IDNacionalidad=Nacionalidad.IDNacionalidad INNER JOIN TipoIdentificacion on Clientes.IDTipoIdentificacion=TipoIdentificacion.IDTipoIdentificacion INNER JOIN TipoCredito on Clientes.IDTipoCredito=TipoCredito.IDTipoCredito INNER JOIN GrupoCxc on Clientes.IDGrupoCxc=GrupoCxc.IDGrupocxc INNER JOIN ComprobanteFiscal on Clientes.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal WHERE REPLACE(Identificacion,'-','')='" + txtRNC.Text.Replace("-", "") + "'", ConLibregco)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds, "Clientes")
                ConLibregco.Close()

                Dim Tabla As DataTable = Ds.Tables("Clientes")
                If Tabla.Rows.Count = 0 Then
                    Ds.Clear()
                    ConUtilitarios.Open()
                    cmd = New MySqlCommand("SELECT * FROM Libregco_Utilitarios.RncDgii WHERE RNC= '" + Cedula.Text + "'", ConUtilitarios)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(Ds, "RncDgii")
                    ConUtilitarios.Close()

                    Dim TablaRNC As DataTable = Ds.Tables("RncDgii")

                    If TablaRNC.Rows.Count = 0 Then
                        Dim ValueReplace As String
                        ValueReplace = Replace(txtRNC.Text, "_", "")
                        ValueReplace = Replace(ValueReplace, "-", "")

                        If ValueReplace.Trim <> "" Then
                            MessageBox.Show("El registro de cédula no se encuentra en la base de datos de la DGII.", "No se encontraron resultados", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        End If
                    Else
                        txtIDCliente.Text = 1
                        txtNombre.Text = (TablaRNC.Rows(0).Item("Nombre"))
                    End If

                    TablaRNC.Dispose()

                Else
                    MessageBox.Show("La cédula introducida ya existe en la base de datos." & vbNewLine & vbNewLine & "Pertenece al cliente código No. [" & (Tabla.Rows(0).Item("IDCliente")) & "] " & (Tabla.Rows(0).Item("Nombre")) & ".", "Existe en la base de datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                    txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    txtNombre.Text = (Tabla.Rows(0).Item("Nombre"))
                    txtDireccion.Text = ((Tabla.Rows(0).Item("Direccion")) & ", " & (Tabla.Rows(0).Item("Municipio")) & ", " & (Tabla.Rows(0).Item("Provincia"))).ToString.ToUpper
                    txtRNC.Text = Tabla.Rows(0).Item("Identificacion")
                    txtTelefono.Text = Tabla.Rows(0).Item("TelefonoPersonal") & " " & (Tabla.Rows(0).Item("TelefonoHogar"))
                End If

                Tabla.Dispose()
                Cedula.Dispose()
            End If


            Dim Masked As New MaskedTextBox
            Dim ValueFilt As String = txtRNC.Text.Replace("-", "")

            If Len(ValueFilt) = 9 Then
                Masked.Mask = "0-00-00000-0"
                Masked.Text = txtRNC.Text
                txtRNC.Text = Masked.Text

                rdbCreditoFiscal.Checked = True

            ElseIf Len(ValueFilt) = 11 Then
                Masked.Mask = "000-0000000-0"
                Masked.Text = txtRNC.Text
                txtRNC.Text = Masked.Text

                If txtIDCliente.Text = 1 Then
                    rdbCreditoFiscal.Focus()
                End If
            Else
                txtRNC.Clear()
                rdbConsumidorFin.Checked = True
            End If

            Masked.Dispose()


            If frm_cotizacion_nw.txtIDCotizacion.Text = "" Then
                If frm_cotizacion_nw.RNCInteligente = 1 Then
                    If txtNombre.Text.Contains("SRL") Or txtNombre.Text.Contains("S.R.L") Or txtNombre.Text.Contains("EIRL") Or txtNombre.Text.Contains("E.I.R.L") Or txtNombre.Text.Contains("S.A") Or txtNombre.Text.Contains(" S A") Or txtNombre.Text.Contains("CXA") Or txtNombre.Text.Contains("C.X.A") Or txtNombre.Text.Contains("C POR A") Then
                        rdbCreditoFiscal.Checked = True
                        lblStatusBar.Text = "El tipo de comprobante fiscal se ha cambiado a " & txtTipoNcf.Text & "."
                    End If
                Else
                    rdbConsumidorFin.Checked = True
                End If
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtIDVendedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIDVendedor.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "0123456789"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtIDCondicion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIDCondicion.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "0123456789"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtIDNcf_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIDNcf.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "0123456789"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub frm_cotizacion_nw_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F12 Then
            txtNombre.Focus()
            txtNombre.SelectAll()

        ElseIf e.KeyCode = Keys.F10 Then
            btnContinuar.PerformClick()

        ElseIf e.KeyCode = Keys.Add Then
            btnContinuar.PerformClick()

        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub txtNombre_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNombre.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Down Then


            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Up Then
            btnBuscarCliente.Focus()

            '    If DgvNombre.Visible = False Then
            '    Else
            '        DgvNombre.Focus()
            '        BindingNavigatorMovePreviousItem.PerformClick()
            '    End If

        ElseIf e.KeyCode = Keys.Left Then
            btnBuscarCliente.Focus()

        End If
    End Sub

    Private Sub txtRNC_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRNC.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Down Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Up Then
            e.Handled = True
            txtNombre.Focus()
            txtNombre.SelectAll()
        End If
    End Sub

    Private Sub txtDireccion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDireccion.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Up Then
            e.Handled = True
            txtRNC.Focus()
            txtRNC.SelectAll()

        ElseIf e.KeyCode = Keys.Down Then
            e.Handled = True
            txtTelefono.Focus()
            txtTelefono.SelectAll()

        End If
    End Sub

    Private Sub txtTelefono_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTelefono.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Up Then
            e.Handled = True
            txtDireccion.Focus()
            txtDireccion.SelectAll()

        ElseIf e.KeyCode = Keys.Down Then
            e.Handled = True
            txtOrden.Focus()
            txtOrden.SelectAll()
        End If
    End Sub

    Private Sub txtIDVendedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIDVendedor.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Right Then
            e.Handled = True
            btnVendedor.Focus()

        ElseIf e.KeyCode = Keys.Up Then
            e.Handled = True
            txtOrden.Focus()
            txtOrden.SelectAll()

        ElseIf e.KeyCode = Keys.Down Then
            If txtIDCondicion.Text <> "" Then
                e.Handled = True
                txtIDCondicion.Focus()
                txtIDCondicion.SelectAll()
            End If

        End If

    End Sub

    Private Sub txtIDCondicion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIDCondicion.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Up Then
            e.Handled = True
            txtIDVendedor.Focus()
            txtIDVendedor.SelectAll()

        ElseIf e.KeyCode = Keys.Right Then
            e.Handled = True
            btnCondicion.Focus()

        ElseIf e.KeyCode = Keys.Down Then
            If txtIDCondicion.Text <> "" Then
                e.Handled = True
                txtIDNcf.Focus()
                txtIDNcf.SelectAll()
            End If
        End If
    End Sub

    Private Sub txtIDNcf_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIDNcf.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Right Then
            e.Handled = True
            btnNcf.Focus()

        ElseIf e.KeyCode = Keys.Up Then
            e.Handled = True
            txtIDCondicion.Focus()
            txtIDCondicion.SelectAll()

        ElseIf e.KeyCode = Keys.Down Then
            If txtIDNcf.Text <> "" Then
                e.Handled = True
                txtObservacion.Focus()
                txtObservacion.SelectAll()
            End If
        End If
    End Sub

    Private Sub rdbCreditoFiscal_KeyDown(sender As Object, e As KeyEventArgs) Handles rdbCreditoFiscal.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub rdbConsumidorFin_KeyDown(sender As Object, e As KeyEventArgs) Handles rdbConsumidorFin.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub rdbRegimenEsp_KeyDown(sender As Object, e As KeyEventArgs) Handles rdbRegimenEsp.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub rdbGubernamental_KeyDown(sender As Object, e As KeyEventArgs) Handles rdbGubernamental.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtObservacion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtObservacion.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Down Then
            e.Handled = True
            btnContinuar.Focus()

        ElseIf e.KeyCode = Keys.Up Then
            e.Handled = True
            txtIDNcf.Focus()
            txtIDNcf.SelectAll()

        End If
    End Sub

    Private Sub btnBuscarCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles btnBuscarCliente.KeyDown
        If e.KeyCode = Keys.Left Then
            e.Handled = True
            txtNombre.Focus()
            txtNombre.SelectAll()

        ElseIf e.KeyCode = Keys.Down Then
            e.Handled = True
            txtRNC.Focus()
            txtRNC.SelectAll()

        End If
    End Sub

    Private Sub btnVendedor_KeyDown(sender As Object, e As KeyEventArgs) Handles btnVendedor.KeyDown
        If e.KeyCode = Keys.Down Then
            If txtIDVendedor.Text <> "" Then
                e.Handled = True
                txtIDCondicion.Focus()
                txtIDCondicion.SelectAll()
            End If

        ElseIf e.KeyCode = Keys.Left Then
            e.Handled = True
            txtIDVendedor.Focus()
            txtIDVendedor.SelectAll()

        ElseIf e.KeyCode = Keys.Up Then
            e.Handled = True
            txtTelefono.Focus()
            txtTelefono.SelectAll()

        ElseIf e.KeyCode = Keys.Right Then
            e.Handled = True
            txtIDCondicion.Focus()
            txtIDCondicion.SelectAll()
        End If
    End Sub

    Private Sub btnCondicion_KeyDown(sender As Object, e As KeyEventArgs) Handles btnCondicion.KeyDown
        If e.KeyCode = Keys.Down Then
            e.Handled = True
            txtIDNcf.Focus()
            txtIDNcf.SelectAll()

        ElseIf e.KeyCode = Keys.Left Then
            e.Handled = True
            txtIDCondicion.Focus()
            txtIDCondicion.SelectAll()

        ElseIf e.KeyCode = Keys.Up Then
            e.Handled = True
            btnVendedor.Focus()

        ElseIf e.KeyCode = Keys.Right Then
            e.Handled = True
            txtIDNcf.Focus()
            txtIDNcf.SelectAll()

        End If
    End Sub

    Private Sub btnNcf_KeyDown(sender As Object, e As KeyEventArgs) Handles btnNcf.KeyDown
        If e.KeyCode = Keys.Left Then
            e.Handled = True
            txtIDNcf.Focus()
            txtIDNcf.SelectAll()

        ElseIf e.KeyCode = Keys.Up Then
            e.Handled = True
            btnCondicion.Focus()

        ElseIf e.KeyCode = Keys.Down Then
            e.Handled = True
            txtObservacion.Focus()
            txtObservacion.SelectAll()

        ElseIf e.KeyCode = Keys.Right Then
            e.Handled = True
            txtObservacion.Focus()
            txtObservacion.SelectAll()
        End If
    End Sub

    Private Sub btnContinuar_KeyDown(sender As Object, e As KeyEventArgs) Handles btnContinuar.KeyDown
        If e.KeyCode = Keys.Down Then
            e.Handled = True
            btnCancelar.Focus()

        ElseIf e.KeyCode = Keys.Up Then
            e.Handled = True
            txtObservacion.Focus()
            txtObservacion.SelectAll()
        End If
    End Sub

    Private Sub btnCancelar_KeyDown(sender As Object, e As KeyEventArgs) Handles btnCancelar.KeyDown
        If e.KeyCode = Keys.Up Then
            e.Handled = True
            btnContinuar.Focus()

        End If
    End Sub

    Private Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged
        Try
            frm_cotizacion_nw.txtNombre.Text = txtNombre.Text

            If txtIDCliente.Text = "1" Then
                If Len(txtNombre.Text) > 0 Then
                    Dim Bs As New BindingSource

                    Ds.Clear()
                    'cmd = New MySqlCommand("SELECT FacturaDatos.NombreFactura as Nombre,IdentificacionFactura as RNC FROM" & SysName.Text & "FacturaDatos Where FacturaDatos.IDCliente=1 and FacturaDatos.NombreFactura like '%" + txtNombre.Text + "%'", ConMixta)
                    cmd = New MySqlCommand("SELECT FacturaDatos.NombreFactura as Nombre,IdentificacionFactura as RNC FROM" & SysName.Text & "FacturaDatos Where FacturaDatos.IDCliente=1 and length(NombreFactura)>10 and FacturaDatos.NombreFactura like '%" + txtNombre.Text + "%' GROUP BY NombreFactura Order by NombreFactura ASC LIMIT 50", ConMixta)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(Ds, "FacturaDatos")
                    Bs.DataMember = "FacturaDatos"
                    Bs.DataSource = Ds
                    BindingNavigator.BindingSource = Bs
                    DgvNombre.DataSource = Bs
                    DgvNombre.Columns(0).Width = 300
                    DgvNombre.Columns(1).Width = 110

                    If DgvNombre.Rows.Count = 0 Then
                        DgvNombre.Visible = False
                    Else
                        DgvNombre.Visible = True
                    End If
                End If

            End If
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try



    End Sub

    Private Sub txtIDCliente_TextChanged(sender As Object, e As EventArgs) Handles txtIDCliente.TextChanged
        frm_cotizacion_nw.txtIDCliente.Text = txtIDCliente.Text
    End Sub

    Private Sub txtObservacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtObservacion.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "abcdefghijklmnñopqrstuvwxyz0123456789. #-_"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub DgvNombre_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvNombre.CellClick
        If e.RowIndex >= 0 Then
            txtNombre.Text = DgvNombre.CurrentRow.Cells(0).Value
            txtRNC.Text = DgvNombre.CurrentRow.Cells(1).Value


            Dim ValueFilt As String = DgvNombre.CurrentRow.Cells(1).Value.Replace("-", "")

            If Len(ValueFilt) = 9 Then
                rdbCreditoFiscal.Checked = True

            ElseIf Len(ValueFilt) = 11 Then
                rdbCreditoFiscal.Checked = True
            Else
                txtRNC.Clear()
                rdbConsumidorFin.Checked = True
            End If

            DgvNombre.Visible = False
        End If
    End Sub

    Private Sub txtNombre_Enter(sender As Object, e As EventArgs) Handles txtNombre.Enter
        If txtIDCliente.Text = 1 Then
            DgvNombre.Visible = True
        End If
    End Sub

    Private Sub DgvNombre_VisibleChanged(sender As Object, e As EventArgs) Handles DgvNombre.VisibleChanged
        If DgvNombre.Visible = False Then
            If txtIDCliente.Text = "1" Then
                If txtNombre.Text = "" Then
                    txtNombre.Text = "CONTADO"
                End If
            End If
        End If
    End Sub

    Private Sub txtRNC_Enter(sender As Object, e As EventArgs) Handles txtRNC.Enter
        DgvNombre.Visible = False
    End Sub

    Private Sub txtDireccion_Enter(sender As Object, e As EventArgs) Handles txtDireccion.Enter
        DgvNombre.Visible = False
    End Sub

    Private Sub txtTelefono_Enter(sender As Object, e As EventArgs) Handles txtTelefono.Enter
        DgvNombre.Visible = False
    End Sub

    Private Sub txtIDVendedor_Enter(sender As Object, e As EventArgs) Handles txtIDVendedor.Enter
        DgvNombre.Visible = False
    End Sub

    Private Sub txtIDCondicion_Enter(sender As Object, e As EventArgs) Handles txtIDCondicion.Enter
        DgvNombre.Visible = False
    End Sub

    Private Sub txtIDNcf_Enter(sender As Object, e As EventArgs) Handles txtIDNcf.Enter
        DgvNombre.Visible = False
    End Sub

    Private Sub txtObservacion_Enter(sender As Object, e As EventArgs) Handles txtObservacion.Enter
        DgvNombre.Visible = False
    End Sub

    Private Sub DgvNombre_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvNombre.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvNombre.ColumnCount
                Dim NumRows As Integer = DgvNombre.RowCount
                Dim CurCell As DataGridViewCell = DgvNombre.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvNombre.CurrentCell = DgvNombre.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvNombre.CurrentCell = DgvNombre.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvNombre.KeyPress
        If DgvNombre.Rows.Count > 0 Then
            If e.KeyChar = ChrW(Keys.Enter) Then
                txtNombre.Text = DgvNombre.CurrentRow.Cells(0).Value
                txtRNC.Text = DgvNombre.CurrentRow.Cells(1).Value

                Dim ValueFilt As String = DgvNombre.CurrentRow.Cells(1).Value.Replace("-", "")

                If Len(ValueFilt) = 9 Then
                    rdbCreditoFiscal.Checked = True

                ElseIf Len(ValueFilt) = 11 Then
                    rdbCreditoFiscal.Checked = True
                Else
                    txtRNC.Clear()
                    rdbConsumidorFin.Checked = True
                End If

                DgvNombre.Visible = False
            End If
        End If
    End Sub

    Private Sub frm_cotizacion_detalle_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If btnPushed = btnContinuar.Name Then
            If txtIDCliente.Text = "" Then
                MessageBox.Show("Seleccione el cliente para procesar la cotización.", "No se ha específicado el cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                btnBuscarCliente.PerformClick()

                e.Cancel = True
                Exit Sub
            ElseIf txtNombre.Text = "" Then
                MessageBox.Show("Escriba el nombre del cliente de la cotización a procesar.", "Nombre del cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtNombre.Focus()

                e.Cancel = True

                Exit Sub

            ElseIf Len(txtNombre.Text) < 3 Then
                MessageBox.Show("Escriba un nombre válido para generar la cotización.", "Nombre no válido", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtNombre.Focus()
                txtNombre.SelectAll()

                e.Cancel = True

                Exit Sub

            ElseIf frm_cotizacion_nw.SolicitarNombreCliente = 1 And txtNombre.Text.Contains("CONTADO") And CDbl(txtNeto.Text) > CDbl(frm_cotizacion_nw.LimiteSolNombre) Then
                MessageBox.Show("El monto total de la factura (" & txtNeto.Text & ") " & "excede el límite máximo establecido (" & CDbl(frm_cotizacion_nw.LimiteSolNombre).ToString("C") & ") para facturas sin el respectivo nombre del cliente." & vbNewLine & vbNewLine & "Por favor escriba el nombre del cliente para continuar con la factura.", "Escriba el nombre del cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                lblStatusBar.Text = "El monto total de la factura (" & txtNeto.Text & ") " & "excede el límite máximo establecido (" & CDbl(frm_cotizacion_nw.LimiteSolNombre).ToString("C") & ") para facturas sin el respectivo nombre del cliente"
                txtNombre.Focus()
                txtNombre.SelectAll()

                e.Cancel = True

                Exit Sub

            ElseIf txtVendedor.Text = "" Or txtIDVendedor.Text = "" Then
                If txtIDVendedor.Text <> "" Then
                    txtIDVendedor.Clear()
                End If
                MessageBox.Show("Escriba el código del vendedor para registrar la cotización.", "Código del vendedor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtIDVendedor.Focus()

                e.Cancel = True

                Exit Sub
            ElseIf txtIDCondicion.Text = "" Then
                MessageBox.Show("Seleccione el tipo de condición de la cotización.", "Condición de cotización", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                btnCondicion.PerformClick()

                e.Cancel = True

                Exit Sub

            ElseIf txtIDNcf.Text = "" Then
                MessageBox.Show("Seleccione el tipo de comprobante a fiscal que desea generar.", "Tipo de Comprobante Fiscal", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                btnNcf.PerformClick()

                e.Cancel = True

                Exit Sub
            End If
        End If
    End Sub

    Private Sub txtNombre_Leave(sender As Object, e As EventArgs) Handles txtNombre.Leave
        If frm_cotizacion_nw.txtIDCotizacion.Text = "" Then
            If frm_cotizacion_nw.RNCInteligente = 1 Then
                If txtNombre.Text.Contains("SRL") Or txtNombre.Text.Contains("S.R.L") Or txtNombre.Text.Contains("EIRL") Or txtNombre.Text.Contains("E.I.R.L") Or txtNombre.Text.Contains("S.A") Or txtNombre.Text.Contains(" S A") Or txtNombre.Text.Contains("CXA") Or txtNombre.Text.Contains("C.X.A") Or txtNombre.Text.Contains("C POR A") Then
                    rdbCreditoFiscal.Checked = True
                    lblStatusBar.Text = "El tipo de comprobante fiscal se ha cambiado a " & txtTipoNcf.Text & "."
                End If
            End If
        End If
    End Sub

    Private Sub txtOrden_TextChanged(sender As Object, e As EventArgs) Handles txtOrden.TextChanged
        frm_cotizacion_nw.txtOrden.Text = txtOrden.Text
    End Sub

    Private Sub txtOrden_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOrden.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "abcdefghijklmnñopqrstuvwxyz0123456789., "
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtOrden_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOrden.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Up Then
            e.Handled = True
            txtTelefono.Focus()
            txtDireccion.SelectAll()

        ElseIf e.KeyCode = Keys.Down Then
            e.Handled = True
            txtIDVendedor.Focus()
            txtIDVendedor.SelectAll()
        End If
    End Sub
End Class