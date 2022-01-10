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

Public Class frm_recibos_cobro_entrega_casa
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend IDCli, Nomb As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        IDCli = frm_registro_recibos_cobro.txtIDCliente.Text
        Nomb = frm_registro_recibos_cobro.txtNombre.Text
        frm_consulta_recibos_ingresos.ShowDialog(Me)
    End Sub

    Private Sub frm_recibos_cobro_entrega_casa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        CargarLibregco()
        txtNoRecibo.Clear()
        lblIDRecibo.Text = ""
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try

            If txtNoRecibo.Text = "" Then
                Exit Sub

            Else
                Dim Dstemp As New DataSet

                Dstemp.Clear()
                ConMixta.Open()
                cmd = New MySqlCommand("SELECT IDAbono,Abonos.IDSucursal,Abonos.IDAlmacen,Abonos.SecondID,Abonos.IDTipoDocumento,TipoDocumento.Letra,Abonos.IDCliente,Clientes.Nombre,Calificacion.Calificacion,Clientes.BalanceGeneral,(SELECT Coalesce(Sum(Cargos),0) from" & SysName.Text & "FacturaDatos Where FacturaDatos.Balance>0 and FacturaDatos.Nulo=0 and IDCliente=Clientes.IDCliente) as CargosCliente,ifnull((Select Fecha from" & SysName.Text & "Abonos where IDCliente=Clientes.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago,(SELECT Ruta FROM" & SysName.Text & "documentosclientes Where DocumentosClientes.IDCliente=Clientes.IDCliente and IDClase=1 LIMIT 1) as Foto,Clientes.IDEmpleado as IDCobrador,Cobrador.Nombre as NombreCobrador,IDTransaccion,Abonos.IDEmpleado as IDUsuario,Fecha,Hora,BalanceAnterior,Concepto,Debito,Descuento,Total,SumaLetra,Impreso,Abonos.Nulo FROM" & SysName.Text & "Abonos INNER JOIN Libregco.Clientes on Abonos.IDCliente=Clientes.IDCliente INNER JOIN Libregco.Calificacion on Clientes.IDCalificacion=Calificacion.IDCalificacion INNER JOIN" & SysName.Text & "Empleados as Cobrador on Clientes.IDEmpleado=Cobrador.IDEmpleado INNER JOIN" & SysName.Text & "TipoDocumento on Abonos.IDTipoDocumento=TipoDocumento.IDTipoDocumento Where IDAbono='" + lblIDRecibo.Text + "'", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Dstemp, "Abonos")
                ConMixta.Close()

                Dim Tabla As DataTable = Dstemp.Tables("Abonos")

                sqlQ = "INSERT INTO Reciboscobro (IDSucursal,IDGrupoRecibo,IDTalonario,IDEntregaCobro,EntregaString,Fecha,PreRecibo,NoRecibo,IDTipoRecibo,Comentario,Monto,IDCierre,Cierre,Nulo) VALUES ('" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','1','1','3','','" + CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd") + "','" + Tabla.Rows(0).Item("Letra").ToString + "','" + Replace(Tabla.Rows(0).Item("SecondID"), Tabla.Rows(0).Item("Letra"), "").ToString + "',1,'','" + Tabla.Rows(0).Item("Total").ToString + "',1,1,0)"
                Con.Open()
                cmd = New MySqlCommand(sqlQ, Con)
                cmd.ExecuteNonQuery()
                Con.Close()

                If Tabla.Rows.Count = 0 Then
                    MessageBox.Show("No se encontró el recibo de ingreso en la base de datos.", "No se encontró", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Else
                    frm_registro_recibos_cobro.AvoidUpdateCbx = 1
                    frm_registro_recibos_cobro.cbxNoRecibo.Items.Clear()

                    ConMixta.Open()
                    cmd = New MySqlCommand("SELECT NoRecibo from" & SysName.Text & "RecibosCobro where IDReciboCobro= (Select Max(IDReciboCobro) from" & SysName.Text & "reciboscobro)", ConMixta)
                    Dim LastNoRecibo As String = Convert.ToString(cmd.ExecuteScalar())
                    ConMixta.Close()

                    frm_registro_recibos_cobro.cbxNoRecibo.Items.Add(Tabla.Rows(0).Item("Letra") & "-" & LastNoRecibo)
                    frm_registro_recibos_cobro.cbxNoRecibo.Text = Tabla.Rows(0).Item("Letra") & "-" & LastNoRecibo
                    frm_registro_recibos_cobro.DtpFechaRecibo.Value = CDate(Tabla.Rows(0).Item("Fecha"))
                    frm_registro_recibos_cobro.cbxTipoRecibo.Text = "Efectivo"
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

                    frm_registro_recibos_cobro.txtIDCobradorC.Text = (Tabla.Rows(0).Item("IDCobrador"))
                    frm_registro_recibos_cobro.txtCobradorC.Text = (Tabla.Rows(0).Item("NombreCobrador"))

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
                                frm_registro_recibos_cobro.Panel1.BackgroundImage = frm_registro_recibos_cobro.PicCliente.BackgroundImage
                                wFile.Close()
                            Else
                                MessageBox.Show("Se ha encontrado un archivo que ha sido específicado como una foto de cliente. Sin embargo, el archivo ha sido movido o eliminado de la ruta de acceso suministrada a la base de datos." & vbNewLine & vbNewLine & "Por favor verifique la integridad de la ruta de acceso válida en '" & Tabla.Rows(0).Item("Foto") & "' en el directorio.", "Archivo no encontrado en el servidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            End If
                        End If
                    End If
                    frm_registro_recibos_cobro.GetInformation()
                    frm_registro_recibos_cobro.FillCbxFacturas()
                    frm_registro_recibos_cobro.VerificarCobrador()
                    frm_registro_recibos_cobro.Button2.PerformClick()
                    frm_registro_recibos_cobro.lblStatusBar.Text = "El recibo de cobro ha sido guardado satisfactoriamente."


                    Close()
                End If

            End If


        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub
End Class