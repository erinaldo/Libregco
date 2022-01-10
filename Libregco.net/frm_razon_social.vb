Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO

Public Class frm_razon_social

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter

    Private Sub frm_razon_social_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
    End Sub

    Private Sub CargarLibregco()
        PicLogoLibregco.Image = ConseguirLogoSistema()
    End Sub

    Private Sub CambiarRutasImagenes()
        Try
            Dim ExistFile As Boolean
            Dim FileName As String

            If TypeConnection.Text = 1 Then
                'Modificando ruta de logo
                ExistFile = System.IO.File.Exists(txtRutaLogo.Text)
                FileName = Path.GetFileName(txtRutaLogo.Text)

                If ExistFile = True Then
                    Dim RutaDestino As String = "\\" & PathServidor.Text & "\Libregco\Files\Empresa\" & FileName

                    If RutaDestino <> txtRutaLogo.Text Then
                        My.Computer.FileSystem.CopyFile(txtRutaLogo.Text, RutaDestino, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)

                        txtRutaLogo.Text = RutaDestino
                    End If

                Else
                    MessageBox.Show("El archivo " & txtRutaLogo.Text & " ha sido movido o eliminado antes de ser guardado en la base de datos.", "Archivo no disponible", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

                'Modificando ruta de logo de reportes
                ExistFile = System.IO.File.Exists(txtRutaLogoReporte.Text)
                FileName = Path.GetFileName(txtRutaLogoReporte.Text)

                If ExistFile = True Then
                    Dim RutaDestino As String = "\\" & PathServidor.Text & "\Libregco\Files\Empresa\" & FileName

                    If RutaDestino <> txtRutaLogoReporte.Text Then
                        My.Computer.FileSystem.CopyFile(txtRutaLogoReporte.Text, RutaDestino, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
                        txtRutaLogoReporte.Text = RutaDestino
                    End If


                Else
                    MessageBox.Show("El archivo " & txtRutaLogoReporte.Text & " ha sido movido o eliminado antes de ser guardado en la base de datos.", "Archivo no disponible", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

            End If
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub CargarEmpresa()
        Try
            Dim wFile As System.IO.FileStream

            Ds.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("Select * from" & SysName.Text & "razonsocial where IDRazon= (Select Max(IDRazon) from" & SysName.Text & "razonsocial)", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "razonsocial")
            ConMixta.Close()

            Dim Tabla As DataTable = Ds.Tables("razonsocial")

            If Tabla.Rows.Count > 0 Then
                txtID.Text = (Tabla.Rows(0).Item("IDRazon"))
                txtRazon.Text = (Tabla.Rows(0).Item("NombreEmpresa"))
                txtEslogan.Text = (Tabla.Rows(0).Item("Eslogan"))
                txtDireccion.Text = (Tabla.Rows(0).Item("Direccion"))
                txtTelefono.Text = (Tabla.Rows(0).Item("Telefono"))
                txtTelefono1.Text = (Tabla.Rows(0).Item("Telefono1"))
                txtTelefono2.Text = (Tabla.Rows(0).Item("Telefono2"))
                txtFax.Text = (Tabla.Rows(0).Item("Fax"))
                txtRNC.Text = (Tabla.Rows(0).Item("RNC"))
                txtAncho.Text = (Tabla.Rows(0).Item("Ancho"))
                txtAlto.Text = (Tabla.Rows(0).Item("Alto"))
                txtAltoReporte.Text = (Tabla.Rows(0).Item("AltoReporte"))
                txtAnchoReporte.Text = (Tabla.Rows(0).Item("AnchoReporte"))
                chkShowLogoSys.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("MostrarLogoSistema"))
                chkShowLogoReport.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("MostrarLogoReporte"))
                chkMarcasAgua.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("MostrarWatermark"))
                txtAutorizacionDGII.Text = (Tabla.Rows(0).Item("AutorizacionDGII"))
                txtAutorizacionFecha.Text = (Tabla.Rows(0).Item("FechaDGII"))
                txtRPE.Text = (Tabla.Rows(0).Item("RPE"))

                If (Tabla.Rows(0).Item("RutaLogo")) = "" Then
                    ResetPicImage()
                Else
                    If TypeConnection.Text = 1 Then
                        wFile = New FileStream(Tabla.Rows(0).Item("RutaLogo"), FileMode.Open, FileAccess.Read)
                        PicLogo.Image = System.Drawing.Image.FromStream(wFile)
                        wFile.Close()
                    End If

                    txtRutaLogo.Text = (Tabla.Rows(0).Item("RutaLogo"))
                    VisualizarLogo()
                End If

                If (Tabla.Rows(0).Item("RutaLogoReporte")) = "" Then
                    PicLogoReporte.Image = Nothing
                Else

                    If TypeConnection.Text = 1 Then
                        wFile = New FileStream(Tabla.Rows(0).Item("RutaLogoReporte"), FileMode.Open, FileAccess.Read)
                        PicLogoReporte.Image = System.Drawing.Image.FromStream(wFile)
                        wFile.Close()
                    End If

                    txtRutaLogoReporte.Text = (Tabla.Rows(0).Item("RutaLogoReporte"))
                End If

                Try
                    ColorPickEdit1.Color = Color.FromArgb(255, Tabla.Rows(0).Item("CER"), Tabla.Rows(0).Item("CEG"), Tabla.Rows(0).Item("CEB"))
                    ColorPickEdit2.Color = Color.FromArgb(255, Tabla.Rows(0).Item("CE1R"), Tabla.Rows(0).Item("CE1G"), Tabla.Rows(0).Item("CE1B"))

                Catch ex As Exception
                    MessageBox.Show("Ocurrió un error al cargar los colores de la base de datos.")
                End Try
            Else
                txtAlto.Text = 0
                txtAncho.Text = 0
                txtAltoReporte.Text = 0
                txtAnchoReporte.Text = 0
            End If


        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnCargarLogo_Click(sender As Object, e As EventArgs) Handles btnCargarLogo.Click
        If TypeConnection.Text = 1 Then
            Dim OfdRutaLogo As New OpenFileDialog
            Dim wFile As System.IO.FileStream

            OfdRutaLogo.RestoreDirectory = True
            OfdRutaLogo.Title = ("Seleccionar Logo")
            OfdRutaLogo.Filter = "Imágenes(*.bmp;*.jpg;*.gif;*.png)|*.bmp;*.jpg;*.gif;*.png"
            OfdRutaLogo.FileName = ""

            If OfdRutaLogo.ShowDialog = Windows.Forms.DialogResult.OK Then
                txtRutaLogo.Text = OfdRutaLogo.FileName
                wFile = New FileStream(OfdRutaLogo.FileName, FileMode.Open, FileAccess.Read)
                PicLogo.Image = System.Drawing.Image.FromStream(wFile)
                wFile.Close()
                VisualizarLogo()
            End If
        End If
    End Sub

    Private Sub ResetPicImage()
        PicLogo.Width = 388
        PicLogo.Height = 128
        PicLogo.Image = My.Resources.no_photo
    End Sub

    Private Sub btn_SalvarCambios_Click(sender As Object, e As EventArgs) Handles btn_SalvarCambios.Click
        If txtRazon.Text = "" Then
            MessageBox.Show("Necesita escribir el nombre del negocio para continuar.", "Nombre comercial o razón social de la empresa", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtRazon.Focus()
            Exit Sub
        ElseIf txtDireccion.Text = "" Then
            MessageBox.Show("Esriba la dirección de su negocio.", "Domicilio comercial", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtDireccion.Focus()
            Exit Sub
        ElseIf txtRNC.Text = "" Then
            MessageBox.Show("Escriba el No. de registro nacional del contribuyente o la cédula para registros como persona física.", "No. de identificación de su negocio", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtRNC.Focus()
            Exit Sub
        ElseIf txtRutaLogo.Text = "" Then
            MessageBox.Show("Seleccione un logo representativo de su negocio.", "Seleccionar logo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf txtRutaLogoReporte.Text = "" Then
            MessageBox.Show("Seleccione un logo representativo de su negocio para su utilización en sus reportes.", "Seleccionar logo para reportes", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf txtAncho.Text = "" Or txtAlto.Text = "" Then
            MessageBox.Show("Especifique el alto y ancho ideal predeterminado del logo de su negocio.", "Ancho y largo no válido", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf txtAnchoReporte.Text = "" Or txtAltoReporte.Text = "" Then
            MessageBox.Show("Especifique el alto y ancho ideal predeterminado del logo de reportes para su negocio.", "Ancho y largo no válido para reportes", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub

        End If

        If txtID.Text = "" Then
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los datos suministrados para la creación de la empresa en el sistema?", "Guardar Nueva Empresa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                VerificarLogo()
                CambiarRutasImagenes()
                sqlQ = "INSERT INTO RazonSocial (NombreEmpresa,Eslogan,Direccion,Telefono,Telefono1,Telefono2,Fax,RNC,Email,RutaLogo,Ancho,Alto,RutaLogoReporte,AltoReporte,AnchoReporte,MostrarLogoSistema,MostrarLogoReporte,AutorizacionDGII,FechaDGII,Municipio,Provincia,RPE,MostrarWatermark,CER,CEG,CEB,CE1R,CE1G,CE1B,OcultarIdentidad) VALUES ('" + txtRazon.Text + "','" + txtEslogan.Text + "','" + txtDireccion.Text + "','" + txtTelefono.Text + "','" + txtTelefono1.Text + "','" + txtTelefono2.Text + "','" + txtFax.Text + "','" + txtRNC.Text + "','" + txtCorreo.Text + "','" + (Replace(txtRutaLogo.Text, "\", "\\")) + "','" + txtAncho.Text + "','" + txtAlto.Text + "','" + (Replace(txtRutaLogoReporte.Text, "\", "\\")) + "','" + txtAltoReporte.Text + "','" + txtAnchoReporte.Text + "','" + Convert.ToInt16(chkShowLogoSys.Checked).ToString + "','" + Convert.ToInt16(chkShowLogoReport.Checked).ToString + "','" + txtAutorizacionDGII.Text + "','" + txtAutorizacionFecha.Text + "','" + txtMunicipio.Text + "','" + txtProvincia.Text + "','" + txtRPE.Text + "','" + Convert.ToInt16(chkMarcasAgua.Checked).ToString + "','" + ColorPickEdit1.Color.R.ToString + "','" + ColorPickEdit1.Color.G.ToString + "','" + ColorPickEdit1.Color.B.ToString + "','" + ColorPickEdit2.Color.R.ToString + "','" + ColorPickEdit2.Color.G.ToString + "','" + ColorPickEdit2.Color.B.ToString + "','" + Convert.ToInt16(chkOcultarCredenciales.Checked).ToString + "')"
                GuardarDatos()
                BlobPicture()
                UltRazon()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar los cambios realizados en la empresa?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                VerificarLogo()
                CambiarRutasImagenes()
                sqlQ = "UPDATE RazonSocial SET NombreEmpresa='" + txtRazon.Text + "',Eslogan='" + txtEslogan.Text + "',Direccion='" + txtDireccion.Text + "',Telefono='" + txtTelefono.Text + "',Telefono1='" + txtTelefono1.Text + "',Telefono2='" + txtTelefono2.Text + "',Fax='" + txtFax.Text + "',Rnc='" + txtRNC.Text + "',Email='" + txtCorreo.Text + "',RutaLogo='" + (Replace(txtRutaLogo.Text, "\", "\\")) + "',Ancho='" + txtAncho.Text + "',Alto='" + txtAlto.Text + "',RutaLogoReporte='" + (Replace(txtRutaLogoReporte.Text, "\", "\\")) + "',AltoReporte='" + txtAltoReporte.Text + "',AnchoReporte='" + txtAnchoReporte.Text + "',MostrarLogoSistema='" + Convert.ToInt16(chkShowLogoSys.Checked).ToString + "',MostrarLogoReporte='" + Convert.ToInt16(chkShowLogoReport.Checked).ToString + "',AutorizacionDGII='" + txtAutorizacionDGII.Text + "',FechaDGII='" + txtAutorizacionFecha.Text + "',Municipio='" + txtMunicipio.Text + "',Provincia='" + txtProvincia.Text + "',RPE='" + txtRPE.Text + "',MostrarWaterMark='" + Convert.ToInt16(chkMarcasAgua.Checked).ToString + "',CER='" + ColorPickEdit1.Color.R.ToString + "',CEG='" + ColorPickEdit1.Color.G.ToString + "',CEB='" + ColorPickEdit1.Color.B.ToString + "',CE1R='" + ColorPickEdit2.Color.R.ToString + "',CE1G='" + ColorPickEdit2.Color.G.ToString + "',CE1B='" + ColorPickEdit2.Color.B.ToString + "',OcultarIdentidad='" + Convert.ToInt16(chkOcultarCredenciales.Checked).ToString + "' WHERE IDRazon= '" + txtID.Text + "'"
                GuardarDatos()
                BlobPicture()
                MessageBox.Show("Los cambios se efectuaran la próxima vez que se inicie el sistema.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub BlobPicture()
        Try
            If txtRutaLogo.Text <> "" Then
                Dim mSTream As New System.IO.MemoryStream()
                PicLogo.Image.Save(mSTream, System.Drawing.Imaging.ImageFormat.Png)
                Dim ArrImage() As Byte = mSTream.GetBuffer()
                mSTream.Close()

                Con.Open()
                sqlQ = "UPDATE RazonSocial SET LogoBlob=@Photo WHERE IDRazon= '" + txtID.Text + "'"
                cmd = New MySqlCommand(sqlQ, Con)
                cmd.Parameters.AddWithValue("@Photo", ArrImage)
                cmd.ExecuteNonQuery()
                Con.Close()

            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub UltRazon()
        Con.Open()
        cmd = New MySqlCommand("Select IDRazon from razonsocial where IDRazon= (Select Max(IDRazon) from razonsocial)", Con)
        txtID.Text = Convert.ToDouble(cmd.ExecuteScalar)
        Con.Close()
    End Sub

    Private Sub GuardarDatos()
        'Try
        Con.Open()
        cmd = New MySqlCommand(sqlQ, Con)
        cmd.ExecuteNonQuery()
        Con.Close()

        '  Catch ex As Exception
        '      Con.Close()
        'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        '  End Try

    End Sub

    Private Sub VisualizarLogo()
        Try
            Dim x, y As Integer
            x = txtAncho.Text
            y = txtAlto.Text

            PicLogo.Size = New System.Drawing.Size(x, y)

        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub txtAncho_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAncho.KeyPress, txtAlto.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtAlto_TextChanged(sender As Object, e As EventArgs) Handles txtAlto.TextChanged
        VisualizarLogo()
    End Sub

    Private Sub txtAncho_TextChanged(sender As Object, e As EventArgs) Handles txtAncho.TextChanged
        VisualizarLogo()
    End Sub

    Private Sub VerificarLogo()
        If txtRutaLogo.Text = "" Then
            txtAlto.Text = 0
            txtAncho.Text = 0
        End If
        If txtRutaLogoReporte.Text = "" Then
            txtAltoReporte.Text = 0
            txtAnchoReporte.Text = 0
        End If
    End Sub

    Private Sub btnLoadLogoReporte_Click(sender As Object, e As EventArgs) Handles btnLoadLogoReporte.Click
        If TypeConnection.Text = 1 Then
            Dim OfdRutaLogo As New OpenFileDialog
            Dim wFile As System.IO.FileStream

            OfdRutaLogo.RestoreDirectory = True
            OfdRutaLogo.Title = ("Seleccionar Logo para Reportes")
            OfdRutaLogo.Filter = "Imágenes(*.bmp;*.jpg;*.jpeg)|*.bmp;*.jpg;*.jpeg"
            OfdRutaLogo.FileName = ""

            If OfdRutaLogo.ShowDialog = Windows.Forms.DialogResult.OK Then
                txtRutaLogoReporte.Text = OfdRutaLogo.FileName
                wFile = New FileStream(OfdRutaLogo.FileName, FileMode.Open, FileAccess.Read)
                PicLogoReporte.Image = System.Drawing.Image.FromStream(wFile)
                wFile.Close()
            End If
        End If
    End Sub

   
    Private Sub txtAutorizacionFecha_Leave(sender As Object, e As EventArgs) Handles txtAutorizacionFecha.Leave
        If IsDate(txtAutorizacionFecha.Text) Then
        Else
            txtAutorizacionFecha.Clear()
        End If
    End Sub

End Class