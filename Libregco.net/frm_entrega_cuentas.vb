Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportAppServer

Public Class frm_entrega_cuentas

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim CheckColumn As New DataGridViewCheckBoxColumn
    Dim Bs As New BindingSource
    Dim Permisos As New ArrayList

    Private Sub frm_entrega_cuentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        Permisos = PasarPermisos(Me.Tag)
        ActualizarTodo()
        CargarLibregco()
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub ActualizarTodo()
        lblIDCliente.Text = ""
        lblSecondIDCliente.Text = ""
        lblNombre.Text = ""
        lblApodo.Text = ""
        lblDireccion.Text = ""
        lblReferencia.Text = ""
        lblProvincia.Text = ""
        lblTelefonos.Text = ""
        lblIngreso.Text = ""
        lblBalanceGeneral.Text = ""
        lblUltimaFecha.Text = ""
        lblUltimoMonto.Text = ""
        FillCalificacion()
        FillCobrador()
        MakeRoundedImage(My.Resources.no_photo, PicFoto)
        MakeRoundedImage(My.Resources.no_photo, PictureBox1)
        txtFechaInicial.Enabled = True
        txtFechaFinal.Enabled = True
        Button1.Enabled = True
        lblFactura.Text = ""
        lblFechaFactura.Text = ""
        lblUsuarioFactura.Text = ""
        lblVendedor.Text = ""
        lblTotalFactura.Text = ""
        lblInicial.Text = ""
        lblRestante.Text = ""
        lblBalanceFactura.Text = ""
        lblArticulos.Text = ""
        lblCantPago.Text = ""
        lblMontoPago.Text = ""
        lblAdicionalFecha.Text = ""
        lblAdicionalMonto.Text = ""
    End Sub

    Private Sub FillCalificacion()
        Try
            Ds1.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Calificacion FROM Calificacion ORDER BY IDCalificacion ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "Calificacion")
            cbxCalificacion.Items.Clear()
            cbxCalificacion.Tag = ""

            ConLibregco.Close()

            Dim Tabla As DataTable = Ds1.Tables("Calificacion")
            For Each Fila As DataRow In Tabla.Rows
                cbxCalificacion.Items.Add(Fila.Item("Calificacion"))
            Next

            If Tabla.Rows.Count > 0 Then
            Else
                MessageBox.Show("No se encontraron calificaciones hábiles en la base de datos. Inserte calificaciones hábiles para procesar los registros de los clientes.", "No se encontraron calificaciones", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Close()
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub FillCobrador()
        Try
            Ds1.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT Nombre,(select count(IDCliente) from Libregco.Clientes Where Clientes.IDEmpleado=Empleados.IDEmpleado and BalanceGeneral>0) as CantidadClientes FROM Empleados Where Nulo=0 ORDER BY CantidadClientes DESC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "Cobrador")
            cbxCobrador.Items.Clear()
            cbxCobrador.Tag = ""

            Con.Close()

            Dim Tabla As DataTable = Ds1.Tables("Cobrador")
            For Each Fila As DataRow In Tabla.Rows
                cbxCobrador.Items.Add(Fila.Item("Nombre"))
            Next

            If Tabla.Rows.Count > 0 Then
            Else
                MessageBox.Show("No se encontraron cobradores hábiles en la base de datos. Inserte estados cobradores hábiles para procesar los registros de los clientes.", "No se encontraron cobradores", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Close()
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub FillFacturas()
        Try
            Ds.Clear()
            cmd = New MySqlCommand("Select IDFacturaDatos,SecondID,FacturaDatos.NombreFactura from" & SysName.Text & "FacturaDatos Where Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and FacturaDatos.Balance>0 ORDER BY NombreFactura ASC", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Facturas")

            Bs.DataMember = "Facturas"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvFacturas.DataSource = Bs
            ProgressBar1.Maximum = DgvFacturas.Rows.Count - 1
            ShowCompleted()

            If DgvFacturas.Columns.Count > 0 Then
                DgvFacturas.Columns(0).Visible = False
                DgvFacturas.Columns(1).HeaderText = "Documento"
                DgvFacturas.Columns(1).Width = 90
                DgvFacturas.Columns(1).ReadOnly = True
                DgvFacturas.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
                DgvFacturas.Columns(2).HeaderText = "Nombre"
                DgvFacturas.Columns(2).Width = 300
                DgvFacturas.Columns(2).ReadOnly = True
                DgvFacturas.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
            End If

        Catch ex As Exception
            'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd.CommandText = Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub DgvFacturas_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DgvFacturas.RowPostPaint
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < DgvFacturas.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If DgvFacturas.RowHeadersWidth < CInt(size.Width + 20) Then
                DgvFacturas.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub ShowCompleted()
        ProgressBar1.Value = Bs.Position
        Label13.Text = Bs.Position + 1 & " de " & DgvFacturas.Rows.Count & "                      " & CInt((100 / DgvFacturas.Rows.Count) * (Bs.Position + 1)) & "%"
    End Sub

    Private Sub DgvFacturas_SelectionChanged(sender As Object, e As EventArgs) Handles DgvFacturas.SelectionChanged
        If ConMixta.State = ConnectionState.Open Then
            ConMixta.Close()
        End If

        FillCalificacion()
        FillInfo()
    End Sub

    Private Sub FillInfo()
        Try
            Dim IDFactura As New Label
            Dim DsTemp As New DataSet

            If DgvFacturas.Rows.Count > 0 Then
                IDFactura.Text = DgvFacturas.CurrentRow.Cells(0).Value

                DsTemp.Clear()
                ConMixta.Open()
                cmd = New MySqlCommand("SELECT FacturaDatos.IDFacturaDatos,FacturaDatos.SecondID as SecondIDFactura,FacturaDatos.NombreFactura,FacturaDatos.DireccionFactura,FacturaDatos.TelefonosFactura,FacturaDatos.IDCondicion,Condicion.Condicion,FacturaDatos.IDVendedor,Vendedor.Nombre as NombreVendedor,FacturaDatos.Fecha as FechaFactura,FacturaDatos.Hora as HoraFactura,FacturaDatos.CantidadPagos,FacturaDatos.MontoPagos,FacturaDatos.PagoAdicional,FacturaDatos.FechaAdicional,FacturaDatos.FechaVencimiento,FacturaDatos.NotaContado,FacturaDatos.CondicionContado,FacturaDatos.NetoFactura,FacturaDatos.TotalNeto,FacturaDatos.Inicial,FacturaDatos.Balance,FacturaDatos.IDUsuario,Usuario.Nombre as NombreUsuario,Clientes.IDCliente,Clientes.SecondID as SecondIDCliente,Clientes.IDTratamiento,Tratamiento.TratamientoAbreviado,Clientes.Nombre,Clientes.Apodo,Clientes.IDNacionalidad,Nacionalidad,Gentilicio,Clientes.IDTipoIdentificacion,Identificacion,TipoIdentificacion.Descripcion as TipoIdentificacion,Clientes.IDGenero,Genero,Clientes.FechaNacimiento,LugarNacimiento,Clientes.IDProvincia,Provincia,Clientes.IDMunicipio,Municipio,Clientes.Direccion,Referencia,Clientes.TelefonoPersonal,Clientes.TelefonoHogar,Clientes.Sueldo,Vivienda,Vehiculo,TrabajoActivo,SeguroMedico,CuentasBancaria,Tarjeta,Clientes.CorreoElectronico,Clientes.IDOcupacion,OcupacionCliente.Ocupacion as OcupacionCliente,LugarTrabajo,UbicacionTrabajo,TelefonoTrabajo,PadreCliente,MadreCliente,DomicilioPaternos,TelefonoPaternos,Clientes.IDCivil,Estadocivil,Conyuge,TelefonoConyuge,IDOcupacionConyuge,OcupacionConyuge.Ocupacion as OcupacionConyuge,LugarTrabajoConyuge,PadreConyuge,MadreConyuge,DomicilioPatConyuge,TelefonoPatConyuge,Clientes.IDCalificacion,Calificacion,ColorCalificacion,CalificacionAutonoma,LimiteCredito,Clientes.IDGrupocxc,Grupocxc.Descripcion as GrupoCxc,Clientes.IDTipoCredito,TipoCredito.Descripcion as TipoCredito,Clientes.IDEmpleado,Empleados.Nombre as NombreEmpleado,Clientes.IDComprobanteFiscal,ComprobanteFiscal.TipoComprobante,Precio,InformacionAdc,Clientes.Alertas,Clientes.FechaIngreso,NoRecibirCheques,CuentaIncobrable,GenerarCargo,CerrarCredito,BloqueoCobrador,BalanceGeneral,(SELECT Coalesce(Sum(Cargos),0) from" & SysName.Text & "FacturaDatos Where FacturaDatos.Balance>0 and FacturaDatos.Nulo=0 and IDCliente=Clientes.IDCliente) as CargosCliente,Desactivar,ifnull((Select Fecha from" & SysName.Text & "Abonos where IDCliente=Clientes.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago,ifnull((Select Total from" & SysName.Text & "Abonos where IDCliente=Clientes.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoMonto,(LimiteCredito-BalanceGeneral) as CreditoDisponible,(SELECT Ruta FROM Libregco.documentosclientes Where DocumentosClientes.IDCliente=Clientes.IDCliente and IDClase=1 LIMIT 1) as Foto,(SELECT group_concat(Cantidad,' ',Medida,' ',Descripcion) FROM libregco.facturaarticulos where IDFactura='" + IDFactura.Text + "') as Articulos,(Select count(IDContrato) from" & SysName.Text & "Contratos where Contratos.IDCliente=Clientes.IDCliente and FechaVencimiento>'" + Today.ToString("yyyy-MM-dd") + "') as Contrato FROM Libregco.clientes INNER JOIN Libregco.Calificacion on Clientes.IDCalificacion=Calificacion.IDCalificacion INNER JOIN" & SysName.Text & "Empleados on Clientes.IDEmpleado=Empleados.IDEmpleado INNER JOIN Libregco.Ocupacion as OcupacionConyuge on Clientes.IDOcupacionConyuge=OcupacionConyuge.IDOcupacion INNER JOIN Libregco.estadocivil on Clientes.IDCivil=EstadoCivil.IDCivil INNER JOIN Libregco.Ocupacion as OcupacionCliente on Clientes.IDOcupacion=OcupacionCliente.IDOcupacion INNER JOIN Libregco.Provincias on Clientes.IDProvincia=Provincias.IDProvincia INNER JOIN Libregco.Municipios on Clientes.IDMunicipio=Municipios.IDMunicipio INNER JOIN Libregco.genero on Clientes.IDGenero=Genero.IDGenero INNER JOIN Libregco.Nacionalidad on Clientes.IDNacionalidad=Nacionalidad.IDNacionalidad INNER JOIN Libregco.TipoIdentificacion on Clientes.IDTipoIdentificacion=TipoIdentificacion.IDTipoIdentificacion INNER JOIN Libregco.TipoCredito on Clientes.IDTipoCredito=TipoCredito.IDTipoCredito INNER JOIN Libregco.GrupoCxc on Clientes.IDGrupoCxc=GrupoCxc.IDGrupocxc INNER JOIN" & SysName.Text & "ComprobanteFiscal on Clientes.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN Libregco.Tratamiento on Clientes.IDTratamiento=Tratamiento.IDTratamiento INNER JOIN" & SysName.Text & "FacturaDatos on Clientes.IDCliente=FacturaDatos.IDCliente INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion INNER JOIN" & SysName.Text & "Empleados as Vendedor on FacturaDatos.IDVendedor=Vendedor.IDEmpleado INNER JOIN" & SysName.Text & "Empleados as Usuario on FacturaDatos.IDUsuario=Usuario.IDEmpleado Where IDFacturaDatos='" + IDFactura.Text + "'", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(DsTemp, "Factura")

                ConMixta.Close()

                Dim Tabla As DataTable = DsTemp.Tables("Factura")

                lblIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                lblSecondIDCliente.Text = (Tabla.Rows(0).Item("SecondIDCliente"))
                lblNombre.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Tabla.Rows(0).Item("Nombre").ToString.ToLower)

                If (Tabla.Rows(0).Item("Nombre")) = (Tabla.Rows(0).Item("NombreFactura")) Then
                    lblApodo.Text = (Tabla.Rows(0).Item("Apodo"))
                Else
                    lblApodo.Text = ""
                End If

                lblDireccion.Text = (Tabla.Rows(0).Item("Direccion"))
                lblReferencia.Text = (Tabla.Rows(0).Item("Referencia"))
                lblProvincia.Text = ((Tabla.Rows(0).Item("Municipio")) & ", " & (Tabla.Rows(0).Item("Provincia"))).ToString.ToUpper
                lblTelefonos.Text = (Tabla.Rows(0).Item("TelefonoPersonal")) & " " & (Tabla.Rows(0).Item("TelefonoHogar"))
                lblIngreso.Text = CDate(Tabla.Rows(0).Item("FechaIngreso")).ToString("dd ' de ' MMMM ' del ' yyyy")
                lblBalanceGeneral.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")

                cbxCalificacion.Tag = Tabla.Rows(0).Item("IDCalificacion")
                cbxCalificacion.Text = Tabla.Rows(0).Item("Calificacion")


                If IsDate(Tabla.Rows(0).Item("UltimoPago")) Then
                    lblUltimaFecha.Text = CDate(Tabla.Rows(0).Item("UltimoPago")).ToString("dd/MM/yyyy")
                Else
                    lblUltimaFecha.Text = (Tabla.Rows(0).Item("UltimoPago"))
                End If

                If IsNumeric(Tabla.Rows(0).Item("UltimoMonto")) Then
                    lblUltimoMonto.Text = CDbl(Tabla.Rows(0).Item("UltimoMonto")).ToString("C")
                Else
                    lblUltimoMonto.Text = (Tabla.Rows(0).Item("UltimoMonto"))
                End If

                If IsDBNull(Tabla.Rows(0).Item("Foto")) Then
                    MakeRoundedImage(My.Resources.no_photo, PicFoto)
                Else
                    Dim ExistFile As Boolean = System.IO.File.Exists(Tabla.Rows(0).Item("Foto"))
                    If ExistFile = True Then
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream(Tabla.Rows(0).Item("Foto"), FileMode.Open, FileAccess.Read)
                        MakeRoundedImage(System.Drawing.Image.FromStream(wFile), PicFoto)
                        wFile.Close()
                    Else
                        MakeRoundedImage(My.Resources.no_photo, PicFoto)
                        MessageBox.Show("Se ha encontrado un archivo que ha sido específicado como una foto de cliente. Sin embargo, el archivo ha sido movido o eliminado de la ruta de acceso suministrada a la base de datos." & vbNewLine & vbNewLine & "Por favor verifique la integridad de la ruta de acceso válida en '" & Tabla.Rows(0).Item("Foto") & "' en el directorio.", "Archivo no encontrado en el servidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If
                End If

                lblFactura.Text = (Tabla.Rows(0).Item("SecondIDFactura"))
                lblFechaFactura.Text = CDate(Tabla.Rows(0).Item("FechaFactura")).ToString("dd/MM/yyyy") & " " & CDate(Convert.ToString(Tabla.Rows(0).Item("HoraFactura"))).ToString("hh:mm:ss tt")
                lblVendedor.Text = "[" & (Tabla.Rows(0).Item("IDVendedor")) & "] " & (Tabla.Rows(0).Item("NombreVendedor"))
                lblUsuarioFactura.Text = "[" & (Tabla.Rows(0).Item("IDUsuario")) & "] " & (Tabla.Rows(0).Item("NombreUsuario"))

                lblTotalFactura.Text = CDbl(Tabla.Rows(0).Item("TotalNeto")).ToString("C")
                lblInicial.Text = CDbl(Tabla.Rows(0).Item("Inicial")).ToString("C")
                lblRestante.Text = CDbl(Tabla.Rows(0).Item("NetoFactura")).ToString("C")
                lblBalanceFactura.Text = CDbl(Tabla.Rows(0).Item("Balance")).ToString("C")

                lblMontoPago.Text = "de " & CDbl(Tabla.Rows(0).Item("MontoPagos")).ToString("C")

                If CDbl(Tabla.Rows(0).Item("PagoAdicional")) > 0 Then
                    lblCantPago.Text = CDbl(Tabla.Rows(0).Item("CantidadPagos")) - 1
                Else
                    lblCantPago.Text = CDbl(Tabla.Rows(0).Item("CantidadPagos"))
                End If

                If IsDate(Tabla.Rows(0).Item("FechaAdicional")) Then
                    lblAdicionalFecha.Text = CDate(Tabla.Rows(0).Item("FechaAdicional"))
                Else
                    lblAdicionalFecha.Text = ""
                End If
                lblAdicionalMonto.Text = CDbl(Tabla.Rows(0).Item("PagoAdicional")).ToString("C")
                cbxCobrador.Tag = (Tabla.Rows(0).Item("IDEmpleado"))
                cbxCobrador.Text = (Tabla.Rows(0).Item("NombreEmpleado"))
                lblArticulos.Text = (Tabla.Rows(0).Item("Articulos"))

                If CDbl(Tabla.Rows(0).Item("Balance")) < CDbl(Tabla.Rows(0).Item("NetoFactura")) Then
                    PictureBox2.Image = My.Resources.Addx24
                    Label8.Text = "Ha realizado pagos a la factura"
                Else
                    PictureBox2.Image = My.Resources.Minusx24
                    Label8.Text = "No ha realizado pagos a la factura"
                End If

                If (Tabla.Rows(0).Item("Identificacion")) = "" Then
                    PictureBox4.Image = My.Resources.Minusx24
                Else
                    PictureBox4.Image = My.Resources.Addx24
                End If

                If CDbl(Tabla.Rows(0).Item("Contrato")) > 0 Then
                    PictureBox3.Image = My.Resources.Addx24
                Else
                    PictureBox3.Image = My.Resources.Minusx24
                End If
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub


    Private Sub cbxCalificacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCalificacion.SelectedIndexChanged
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDCalificacion FROM Calificacion WHERE Calificacion= '" + cbxCalificacion.SelectedItem + "'", ConLibregco)
        cbxCalificacion.Tag = Convert.ToString(cmd.ExecuteScalar())

        sqlQ = "UPDATE Clientes SET IDCalificacion='" + cbxCalificacion.Tag.ToString + "' WHERE IDCliente='" + lblIDCliente.Text + "'"
        cmd = New MySqlCommand(sqlQ, ConLibregco)
        cmd.ExecuteNonQuery()

        ConLibregco.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea consultar los documentos" & vbNewLine & vbNewLine & "del" & vbNewLine & txtFechaInicial.Value.ToString("dd/MM/yyyy") & vbNewLine & "al" & vbNewLine & txtFechaFinal.Value.ToString("dd/MM/yyyy") & "?", "Consultar documentos pendientes", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If Result = MsgBoxResult.Yes Then
            FillFacturas()
            txtFechaInicial.Enabled = False
            txtFechaFinal.Enabled = False
            Button1.Enabled = False
            PictureBox5.Visible = False
            Label16.Visible = False
            DgvFacturas.Visible = True
        End If

    End Sub


    Private Sub cbxCobrador_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCobrador.SelectedIndexChanged
        Try

            Ds1.Clear()

            Con.Open()
            cmd = New MySqlCommand("SELECT IDEmpleado,RutaFoto from Empleados Where Nombre='" + cbxCobrador.SelectedItem + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "Cobrador")
            Con.Close()

            Dim Tabla As DataTable = Ds1.Tables("Cobrador")

            If Tabla.Rows.Count > 0 Then
                cbxCobrador.Tag = Tabla.Rows(0).Item("IDEmpleado")

                If IsDBNull(Tabla.Rows(0).Item("RutaFoto")) Then
                    MakeRoundedImage(My.Resources.no_photo, PictureBox1)
                Else
                    Dim ExistFile As Boolean = System.IO.File.Exists(Tabla.Rows(0).Item("RutaFoto"))
                    If ExistFile = True Then
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream(Tabla.Rows(0).Item("RutaFoto"), FileMode.Open, FileAccess.Read)
                        MakeRoundedImage(System.Drawing.Image.FromStream(wFile), PictureBox1)
                        wFile.Close()
                    Else
                        MakeRoundedImage(My.Resources.no_photo, PictureBox1)
                        MessageBox.Show("Se ha encontrado un archivo que ha sido específicado como una foto de cliente. Sin embargo, el archivo ha sido movido o eliminado de la ruta de acceso suministrada a la base de datos." & vbNewLine & vbNewLine & "Por favor verifique la integridad de la ruta de acceso válida en '" & Tabla.Rows(0).Item("Foto") & "' en el directorio.", "Archivo no encontrado en el servidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If
                End If

                ConLibregco.Open()
                sqlQ = "UPDATE Clientes SET IDEmpleado='" + cbxCobrador.Tag.ToString + "' WHERE IDCliente='" + lblIDCliente.Text + "'"
                cmd = New MySqlCommand(sqlQ, ConLibregco)
                cmd.ExecuteNonQuery()
                ConLibregco.Close()

            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Bs.Position > 0 Then
            DgvFacturas.Rows(Bs.Position).DefaultCellStyle.BackColor = SystemColors.Control
            BindingNavigatorMovePreviousItem.PerformClick()
            ShowCompleted()
            cbxCobrador.Focus()
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DgvFacturas.Rows(Bs.Position).DefaultCellStyle.BackColor = SystemColors.ControlDark
        BindingNavigatorMoveNextItem.PerformClick()
        ShowCompleted()
        cbxCobrador.Focus()
    End Sub

  
End Class