Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_autorizacion_acciones

    Dim sqlQ As String = ""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Private Hora As Integer = 0
    Private Minuto As Integer = 0
    Private Segundo As Integer = 0
    Private Milisegundo As Integer = 0
    Private IsAproved As String = 0
    Friend IDPermiso, IDAccion, IDEmpleadoAvisa, Descripcion As New Label

    Private Sub frm_autorizacion_ventas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarLibregco()
        LimpiarDatos()
        GetIDForm()
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub LimpiarDatos()
        IsAproved = 0
        lblModulo.Text = ""
        IDPermiso.Text = ""
        btnContinuar.Enabled = False
        btnContinuar.Text = "Esperando aprobación..."
        PictureBox1.Image = My.Resources.Square_Loading
        btnContinuar.ForeColor = Color.Black
        ControlSuperClave = 0
        Timer2.Enabled = False
        Timer1.Enabled = True
        lblUsuarioSolicitante.Text = ""
        lblIDAutorizacion.Text = ""
        lblTiempoenEspera.Text = ""
        Hora = 0
        Minuto = 0
        Segundo = 0
        Milisegundo = 0
        IsAproved = 0
        Me.Text = "Esperando autorización..."
    End Sub

    Sub GetIDForm()

        Dim TruthOwner As String
        Dim Dstemp As New DataSet

        If frm_superclave.Visible = True Then
            TruthOwner = frm_superclave.Owner.Name
        Else
            TruthOwner = Me.Owner.Name
        End If

        ConMixta.Open()
        Dstemp.Clear()
        cmd = New MySqlCommand("SELECT IDPermisos,Descripcion,Modulos.IDModulo,Modulo,Proceso FROM" & SysName.Text & "permisos inner join libregco.modulos on permisos.idmodulo=modulos.idmodulo inner join libregco.procesosmodulo on permisos.idproceso=procesosmodulo.idProcesosModulo where FormName='" + TruthOwner + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Dstemp, "Modulo")
        ConMixta.Close()

        Dim Tabla As DataTable = Dstemp.Tables("Modulo")
        If Tabla.Rows.Count = 0 Then
            MessageBox.Show("No se encontró el módulo correspondiente al formulario de autorización de procedimientos.", "No se encontró módulo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            lblModulo.Text = "[" & Tabla.Rows(0).Item("IDPermisos") & "] " & Tabla.Rows(0).Item("Modulo") & "/" & Tabla.Rows(0).Item("Proceso") & "/" & Tabla.Rows(0).Item("Descripcion")
            IDPermiso.Text = Tabla.Rows(0).Item("IDPermisos")
        End If

        lblUsuarioSolicitante.Text = "[" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "] " & frm_inicio.lblNombre.Text


        sqlQ = "INSERT INTO" & SysName.Text & "SolicitudAutorizacion (IDEquipo,IDPermiso,IDAccion,IDUsuarioSolicitud,Fecha,Aprobado,Avisado,IDEmpleadoEnviado,Descripcion) VALUES ('" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "','" + IDPermiso.Text + "','" + IDAccion.Text + "','" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "','" + Today.ToString("yyyy-MM-dd") & " " & TimeOfDay.ToString("HH:mm:ss") + "',0,0,'" + IDEmpleadoAvisa.Text + "','" + Descripcion.Text + "')"
        GuardarDatos()
        UltSolicitud()

        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Private Sub UltSolicitud()
        If lblIDAutorizacion.Text = "" Then
            ConMixta.Open()
            cmd = New MySqlCommand("Select IDSolicitudAutorizacion from" & SysName.Text & "solicitudautorizacion where IDSolicitudAutorizacion= (Select Max(IDSolicitudAutorizacion) from " & SysName.Text & "solicitudautorizacion)", ConMixta)
            lblIDAutorizacion.Text = Convert.ToString(cmd.ExecuteScalar())
            ConMixta.Close()
        End If
    End Sub

    Sub MostrarTiempo()
        lblTiempoenEspera.Text = Hora.ToString.PadLeft(2, "0") & ":"
        lblTiempoenEspera.Text &= Minuto.ToString.PadLeft(2, "0") & ":"
        lblTiempoenEspera.Text &= Segundo.ToString.PadLeft(2, "0") & ":"
        lblTiempoenEspera.Text &= Milisegundo.ToString.PadLeft(1, "0") & ":"
        lblTiempoenEspera.Refresh()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Milisegundo += 1
        If Milisegundo = 9 Then
            Milisegundo = 0
            Segundo += 1
            If Segundo = 59 Then
                Segundo = 0
                Minuto += 1
                If Minuto = 59 Then
                    Minuto += 1
                    Hora += 1
                End If
            End If
        End If
        MostrarTiempo()
    End Sub

    Private Sub frm_autorizacion_acciones_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If IsAproved = 0 Then
            Dim result = MessageBox.Show("En estos momentos se encuentra a la espera de una aprobación." & vbNewLine & vbNewLine & "Está seguro que desea cerrar/cancelar la aprobación?", "Cancelar aprobación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                e.Cancel = False
                ControlSuperClave = 1
            Else
                e.Cancel = True
                ControlSuperClave = 1
            End If
        Else
            e.Cancel = False
        End If
    End Sub

    Private Sub GuardarDatos()
        Try
            ConMixta.Open()
            cmd = New MySqlCommand(sqlQ, ConMixta)
            cmd.ExecuteNonQuery()
            ConMixta.Close()
        Catch ex As Exception
            ConMixta.Close()
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        ConMixta.Open()
        cmd = New MySqlCommand("SELECT IFNULL((SELECT Aprobado FROM" & SysName.Text & "SolicitudAutorizacion WHERE IDSolicitudAutorizacion='" + lblIDAutorizacion.Text + "'),2)", ConMixta)
        IsAproved = Convert.ToDouble(cmd.ExecuteScalar())
        ConMixta.Close()


        If IsAproved = 1 Then
            btnContinuar.Enabled = True
            btnContinuar.Text = "Solicitud aprobada"
            btnContinuar.ForeColor = Color.Blue
            Timer2.Enabled = False
            Timer1.Enabled = False
            PictureBox1.Image = My.Resources.Check_Gif
            Me.Text = "La solicitud ha sido aprobada satisfactoriamente"

        ElseIf IsAproved = 2 Then
            Timer2.Enabled = False
            Timer1.Enabled = False

            'For Each formLabel As Label In Me.Controls.OfType(Of Label)()
            '    formLabel.ForeColor = Color.White
            'Next
            'Me.BackColor = Color.FromArgb(-13158084)

            ControlSuperClave = 1
            btnContinuar.Enabled = True
            btnContinuar.Text = "La solicitud ha sido cancelada."
            btnContinuar.ForeColor = Color.Red
            PictureBox1.Image = My.Resources.Closed_GIF
            Me.Text = "La solicitud ha sido cancelada"
        End If
    End Sub

    Private Sub btnContinuar_Click(sender As Object, e As EventArgs) Handles btnContinuar.Click
        If IsAproved = 1 Then
            ControlSuperClave = 0

            If Me.Owner.Name = frm_superclave.Name Then
                If Me.Owner.Owner.Name = frm_facturacion.Name Then
                    frm_facturacion.AccionesModulosAutorizadas.Add(IDAccion.Text)
                End If
            ElseIf Me.Owner.Name = frm_facturacion.name Then
                frm_facturacion.AccionesModulosAutorizadas.Add(IDAccion.Text)
            End If

            If frm_superclave.Visible = True Then
                frm_superclave.Close()
            End If

        End If

        Close()
    End Sub

End Class