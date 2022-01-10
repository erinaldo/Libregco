Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.Net
Imports System.IO
Public Class frm_autorizacion_equipos
    'Database references
    '
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    'Tools references
    Dim Ds As New DataSet
    Dim IDPuntoVenta, Nulo As New Label
    Dim AutorizedPoint As New Boolean
    Dim TypeofMetode As String
    Private Sub frm_autorizacion_equipos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CheckIfExists()
    End Sub

    Private Sub CheckIfExists()
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT IDEquipo,AreaImpresion.IDAlmacen,Almacen.Almacen,Almacen.IDSucursal,Sucursal.Sucursal,ComputerNAme,UsuarioPC,SistemaOperativo,NodeImpresion,Observacion,IPPrivada,IPPublica,FechaIngreso,WindowsUser,WindowsPassword,AreaImpresion.Nulo FROM areaimpresion INNER JOIN Almacen on AreaImpresion.IDAlmacen=Almacen.IDAlmacen INNER JOIN Sucursal on Almacen.IDSucursal=Sucursal.IDSucursal Where ComputerName='" + My.Computer.Name + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "AreaImpresion")
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("AreaImpresion")
            Dim ComputerName As String

            If Tabla.Rows.Count > 0 Then
                ComputerName = Tabla.Rows(0).Item("ComputerName")
            End If

            Con.Open()
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=75", Con)
            TypeofMetode = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()

            If TypeofMetode <> 2 Then
                GroupBox2.Visible = False
            End If

            If ComputerName = "" Then
                lblStatus.Text = "Este equipo no está autorizado para el acceso al sistema."
                lblStatus.ForeColor = Color.Red
                lblFechaRegistro.Text = Today.ToLongDateString
                AutorizedPoint = False
                btnAutorizar.Visible = True
                txtSuperClave.Visible = True
                Label5.Visible = True
                LinkLabel1.Visible = False
            Else
                AutorizedPoint = True
                IDPuntoVenta.Text = (Tabla.Rows(0).Item("IDEquipo"))
                lblFechaRegistro.Text = (Tabla.Rows(0).Item("FechaIngreso"))
                txtIDAlmacen.Text = (Tabla.Rows(0).Item("IDAlmacen"))
                txtAlmacen.Text = (Tabla.Rows(0).Item("Almacen"))
                lblSucursal.Text = (Tabla.Rows(0).Item("Sucursal"))
                txtNoEmision.Text = CStr(Tabla.Rows(0).Item("NodeImpresion")).PadLeft(3, "0")
                txtUserWindows.Text = Environment.UserName
                txtPasswordWindows.Text = Tabla.Rows(0).Item("WindowsPassword")

                Nulo.Text = (Tabla.Rows(0).Item("Nulo"))

                If Nulo.Text = 0 Then
                    lblStatus.Text = "El equipo está autorizado para ingresar y realizar operaciones en el sistema."
                    lblStatus.ForeColor = Color.Green
                    btnAutorizar.Visible = True
                    txtSuperClave.Visible = False
                    Label5.Visible = False
                    LinkLabel1.Visible = True
                    btnAutorizar.Text = "Actualizar terminal"
                Else
                    lblStatus.Text = "El equipo está desactivado para el ingreso en el sistema. Para seguir utilizando este punto de impresión active su autorización."
                    lblStatus.ForeColor = Color.Brown
                    btnAutorizar.Visible = True
                    txtSuperClave.Visible = True
                    Label5.Visible = True
                    LinkLabel1.Visible = False
                    btnAutorizar.Text = "Autorizar terminal"
                End If
            End If

            lblNombreEquipo.Text = My.Computer.Name
            lblSistemaOperativo.Text = My.Computer.Info.OSFullName.ToString
            lblPlataforma.Text = My.Computer.Info.OSPlatform.ToString
            lblIPPrivado.Text = Dns.GetHostEntry(My.Computer.Name).AddressList.FirstOrDefault(Function(i) i.AddressFamily = Sockets.AddressFamily.InterNetwork).ToString()

            Try
                If My.Computer.Network.IsAvailable = True Then
                    Dim Client As New WebClient
                    lblIPPublico.Text = Client.DownloadString("http://icanhazip.com")
                    If lblIDPublicoString.Text.Length > 20 Then
                        lblIDPublicoString.Text = ""
                    End If
                    lblIPPublico.Visible = True
                    lblIDPublicoString.Visible = True
                Else
                    lblIPPublico.Text = "No se encontró acceso a Internet"
                    lblIPPublico.Visible = False
                    lblIDPublicoString.Visible = False
                End If
            Catch ex As Exception
                lblIPPublico.Text = "Se ha encontrado un problema persistente para el acceso al internet."
            End Try


        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub Fecha_Tick(sender As Object, e As EventArgs) Handles Fecha.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub

    Private Sub txtIDAlmacen_Leave(sender As Object, e As EventArgs) Handles txtIDAlmacen.Leave
        Con.Open()
        cmd = New MySqlCommand("Select Almacen from Almacen Where IDAlmacen='" + txtIDAlmacen.Text + "'", Con)
        txtAlmacen.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
        If txtAlmacen.Text = "" Then txtIDAlmacen.Clear()

        If txtIDAlmacen.Text <> "" Then
            Con.Open()
            cmd = New MySqlCommand("SELECT Sucursal.Sucursal FROM almacen INNER JOIN Sucursal on Almacen.IDSucursal=Sucursal.IDSucursal Where IDAlmacen='" + txtIDAlmacen.Text + "'", Con)
            lblSucursal.Text = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()
        End If
    End Sub

    Private Sub btnAlmacen_Click(sender As Object, e As EventArgs) Handles btnAlmacen.Click
        frm_buscar_almacen_mant.ShowDialog(Me)
    End Sub

    Private Sub InsertNCFs()
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT * FROM comprobantefiscal", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Comprobantefiscal")
            Con.Close()

            Dim TablaNCF As DataTable = Ds.Tables("Comprobantefiscal")

            For Each Fila As DataRow In TablaNCF.Rows
                Dim IDComprobante As New Label
                IDComprobante.Text = Fila.Item("IDComprobanteFiscal")

                sqlQ = "INSERT INTO AreaImpresionNCF (IDAreaImpresion,IDNCF,Inicial,Final,Actual) VALUES ('" + IDPuntoVenta.Text + "','" + IDComprobante.Text + "','0','0','0')"
                GuardarDatos()
            Next

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub UpdateNCFs()
        Try
            Dim DSPcs, DSNFs As New DataSet

            DSPcs.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT * FROM AreaImpresion", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DSPcs, "AreaImpresion")
            Con.Close()

            'Lleno otra tabla con cada uno de los terminales autorizados previamente
            Dim TablaPCs As DataTable = DSPcs.Tables("AreaImpresion")

            For Each FilaAreaImpresion As DataRow In TablaPCs.Rows
                Dim IDEquipo As New Label
                IDEquipo.Text = FilaAreaImpresion.Item("IDEquipo")

                DSNFs.Clear()
                Con.Open()
                cmd = New MySqlCommand("SELECT * FROM comprobantefiscal", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(DSNFs, "Comprobantefiscal")
                Con.Close()

                'Lleno una tabla con los tipos de comprobantes fiscales
                Dim TablaNCF As DataTable = DSNFs.Tables("Comprobantefiscal")

                For Each Fila As DataRow In TablaNCF.Rows
                    Dim IDComprobante, IDAreaImpresionNCF As New Label
                    IDComprobante.Text = Fila.Item("IDComprobanteFiscal")

                    Con.Open()
                    cmd = New MySqlCommand("SELECT IDAreaImpresionNCF FROM areaimpresionncf Where IDAreaImpresion='" + IDEquipo.Text + "' and IDNCF='" + IDComprobante.Text + "'", Con)
                    IDAreaImpresionNCF.Text = Convert.ToString(cmd.ExecuteScalar())
                    Con.Close()

                    If IDAreaImpresionNCF.Text = "" Then
                        sqlQ = "INSERT INTO AreaImpresionNCF (IDAreaImpresion,IDNCF,Inicial,Final,Actual) VALUES ('" + IDEquipo.Text + "','" + IDComprobante.Text + "','0','0','0')"
                        GuardarDatos()
                    End If
                Next
            Next


        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub GetLastID()
        If IDPuntoVenta.Text = "" Then
            Con.Open()
            cmd = New MySqlCommand("Select IDEquipo from Areaimpresion where IDEquipo= (Select Max(IDEquipo) from Areaimpresion)", Con)
            IDPuntoVenta.Text = Convert.ToString(cmd.ExecuteScalar())
            frm_LoginSistema.lblEquipo.Visible = True
            frm_LoginSistema.lblEquipo.Text = My.Computer.Name
            frm_LoginSistema.lblDesktopAccess.Visible = True
            frm_LoginSistema.lblInformacion.Text = "El equipo ya está autorizado para el acceso al sistema."
            frm_LoginSistema.lblInformacion.ForeColor = Color.Blue
            Con.Close()
        End If
    End Sub

    Private Sub btnAutorizar_Click(sender As Object, e As EventArgs) Handles btnAutorizar.Click
        Dim NoEmisionString As String
        NoEmisionString = txtNoEmision.Text.Replace("_", "")

        If txtIDAlmacen.Text = "" Then
            MessageBox.Show("Seleccione el almacén donde se encuentra este equipo.", "Seleccionar almacén", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnAlmacen.PerformClick()
            Exit Sub
        ElseIf txtSuperClave.Text = "" And IDPuntoVenta.Text = "" Then
            MessageBox.Show("Escriba la superclave de configuración para continuar la autorización del equipo.", "Super clave de autorización", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtSuperClave.Focus()
            Exit Sub
        ElseIf TypeofMetode = 2 Then
            If NoEmisionString.Length < 3 Then
                MessageBox.Show("Complete el No. de punto de venta para la creación de estructuras NCF.", "Escriba el Punto de Emision", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtNoEmision.Focus()
                Exit Sub
            End If
        End If

        Dim SuperClave As String
        Con.Open()
        cmd = New MySqlCommand("SELECT Clave FROM modulos where idmodulo=13", Con)
        SuperClave = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()

        If IDPuntoVenta.Text = "" Then
            If txtSuperClave.Text <> SuperClave Then
                MessageBox.Show("La super clave es incorrecta." & vbNewLine & vbNewLine & "Por favor verifique la contraseña y vuelta a intentarlo. De lo contrario, comuníquese con el soporte técnico del sistema.", "SuperClave Incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                Dim isServerValue As String
                ConMixta.Open()
                cmd = New MySqlCommand("Select count(IDEquipo) from" & SysName.Text & "AreaImpresion", ConMixta)
                Dim CantidadEquipos As Integer = Convert.ToString(cmd.ExecuteScalar())
                ConMixta.Close()

                If CantidadEquipos = 0 Then
                    isServerValue = 1
                Else
                    isServerValue = 0
                End If

                sqlQ = "INSERT INTO AreaImpresion (IDAlmacen,ComputerName,UsuarioPC,SistemaOperativo,NodeImpresion,Observacion,IPPrivada,IPPublica,FechaIngreso,Nulo,SizeMode,SizeIndex,AutomaticStartUp,MuteApp,WindowsUser,WindowsPassword,PrinterMode,Suspender,isServer,PreviewMode,LiteMode) VALUES ('" + txtIDAlmacen.Text + "','" + lblNombreEquipo.Text + "','" + lblPlataforma.Text + "','" + lblSistemaOperativo.Text + "','" + txtNoEmision.Text + "','" + txtObservacion.Text + "','" + lblIPPrivado.Text + "','" + lblIPPublico.Text + "','" + (CDate(lblFechaRegistro.Text).ToString("yyyy-MM-dd")) + "',0,0,1,0,0,'" + txtUserWindows.Text + "','" + txtPasswordWindows.Text + "',1,0,'" + isServerValue.ToString + "',0,0)"
                GuardarDatos()
                GetLastID()
                InsertNCFs()
                frm_LoginSistema.CargarEquipo()
                MessageBox.Show("Se ha guardado exitosamente el equipo en la base de datos.", "Autorización Procesada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            End If
        Else
            If Nulo.Text = 1 Then
                If txtSuperClave.Text <> SuperClave Then
                    MessageBox.Show("La super clave es incorrecta." & vbNewLine & vbNewLine & "Por favor verifique la contraseña y vuelta a intentarlo. De lo contrario, comuníquese con el soporte técnico del sistema.", "SuperClave Incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                sqlQ = "UPDATE AreaImpresion SET Nulo='0' WHERE IDEquipo= (" + IDPuntoVenta.Text + ")"
                GuardarDatos()
                UpdateNCFs()
                MessageBox.Show("El equipo ha sido activado satisfactoriamente.", "Se ha activado el equipo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                sqlQ = "UPDATE AreaImpresion SET IDAlmacen='" + txtIDAlmacen.Text + "',ComputerName='" + lblNombreEquipo.Text + "',UsuarioPC='" + lblPlataforma.Text + "',SistemaOperativo='" + lblSistemaOperativo.Text + "',NodeImpresion='" + txtNoEmision.Text + "',Observacion='" + txtObservacion.Text + "',IPPrivada='" + lblIPPrivado.Text + "',FechaIngreso='" + CDate(lblFechaRegistro.Text).ToString("yyyy-MM-dd") + "',WindowsUser='" + txtUserWindows.Text + "',WindowsPassword='" + txtPasswordWindows.Text + "',Nulo='" + Nulo.Text + "' WHERE IDEquipo= (" + IDPuntoVenta.Text + ")"
                GuardarDatos()
                UpdateNCFs()
                MessageBox.Show("Se han actualizado los datos del equipo satisfactoriamente.", "Se han actualizado los datos del equipo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If

        CheckIfExists()
    End Sub

    Private Sub GuardarDatos()
        Try
            ConLibregco.Open()
            cmd = New MySqlCommand(sqlQ, ConLibregco)
            cmd.ExecuteNonQuery()
            ConLibregco.Close()

            ConLibregcoMain.Open()
            cmd = New MySqlCommand(sqlQ, ConLibregcoMain)
            cmd.ExecuteNonQuery()
            ConLibregcoMain.Close()

        Catch ex As Exception
            ConLibregco.Close()
            ConLibregcoMain.Close()
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim Result1 As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar el punto de impresión o el equipo " & My.Computer.Name & " como equipo autorizado del sistema?", "Desactivar Punto de Impresión", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

        If Result1 = MsgBoxResult.Yes Then
            sqlQ = "UPDATE AreaImpresion SET Nulo='1' WHERE IDEquipo= (" + IDPuntoVenta.Text + ")"
            GuardarDatos()
            MessageBox.Show("El equipo ha sido desactivado satisfactoriamente.", "Se ha desactivado el equipo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Close()
        End If
    End Sub



End Class