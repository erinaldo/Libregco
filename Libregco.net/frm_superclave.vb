Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_superclave

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet
    Dim Contraseña As New Label
    Friend IDAccion As New Label

    Private Sub frm_superclave_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ControlSuperClave = 1
        CargarLibregco()
        txtClave.Clear()
        txtClave.Focus()
        WhilesForms()
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub WhilesForms()
        Try
            Dim DsTemp As New DataSet

            ConMixta.Open()
            Dstemp.Clear()
            cmd = New MySqlCommand("SELECT IDPermisos,Descripcion,Modulos.IDModulo,Modulo,Proceso FROM" & SysName.Text & "permisos inner join" & SysName.Text & "modulos on permisos.idmodulo=modulos.idmodulo inner join" & SysName.Text & "procesosmodulo on permisos.idproceso=procesosmodulo.idProcesosModulo where FormName='" + Me.Owner.Name.ToString + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Dstemp, "Modulo")
            ConMixta.Close()

            Dim tmpTable As DataTable = DsTemp.Tables("Modulo")

            If tmpTable.Rows.Count = 0 Then
                btnSolicitarAutorizacion.Visible = False
            Else
                btnSolicitarAutorizacion.Visible = True
            End If


            Ds.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("SELECT * FROM" & SysName.Text & "accionesmodulos INNER JOIN" & SysName.Text & "Modulos on AccionesModulos.IDModulo=Modulos.IDModulo where idaccionesSuperClave='" + IDAccion.Text + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "accionesmodulos")
            ConMixta.Close()

            Dim Tabla As DataTable = Ds.Tables("accionesmodulos")

            Contraseña.Text = (Tabla.Rows(0).Item("Clave"))
            lblDescrpModulo.Text = "[" & Tabla.Rows(0).Item("Modulo") & "] " & (Tabla.Rows(0).Item("Descripcion"))

            Con.Open()
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=135", Con)
            Dim ClavesDesactivadas As String = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()

            If ClavesDesactivadas = 1 Then
                txtClave.Text = (Tabla.Rows(0).Item("Clave"))
                SendKeys.Send("{ENTER}")
            Else
                If Tabla.Rows(0).Item("Activo") = 0 Then
                    txtClave.Text = (Tabla.Rows(0).Item("Clave"))
                    SendKeys.Send("{ENTER}")
                End If
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " Desde WhilesForm")
        End Try
    End Sub

    Private Sub txtClave_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtClave.KeyPress
        Try
            If e.KeyChar = ChrW(Keys.Escape) Then
                ControlSuperClave = 1
                Close()
            End If

            If e.KeyChar = ChrW(Keys.Enter) Then
                If txtClave.Text = Contraseña.Text Then
                    ControlSuperClave = 0

                    If Me.Owner.Name = frm_facturacion.Name Then
                        frm_facturacion.AccionesModulosAutorizadas.Add(IDAccion.Text)

                    ElseIf Me.Owner.Name = frm_financiamiento.name Then
                        frm_financiamiento.AccionesModulosAutorizadas.Add(IDAccion.Text)

                    ElseIf Me.Owner.Name = frm_mant_clientes.name Then
                        frm_mant_clientes.AccionesModulosAutorizadas.Add(IDAccion.Text)

                    ElseIf Me.Owner.Name = frm_recibo_pagos.name Then
                        frm_recibo_pagos.AccionesModulosAutorizadas.Add(IDAccion.Text)

                    ElseIf Me.Owner.Name = frm_registro_compras.name Then
                        frm_registro_compras.AccionesModulosAutorizadas.Add(IDAccion.Text)
                    End If

                Else
                    ControlSuperClave = 1
                    MessageBox.Show("Contraseña incorrecta, inténtelo de nuevo.", "Contraseña Errónea", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                End If
                Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & "txtClaveKeyPress")
        End Try
    End Sub


    Private Sub btnSolicitarAutorizacion_Click(sender As Object, e As EventArgs) Handles btnSolicitarAutorizacion.Click
        frm_usuarios_recepcion_solicitud.ShowDialog(Me)

        If ControlSuperClave = 0 Then
            Exit Sub
        End If

        ControlSuperClave = 1
        frm_autorizacion_acciones.IDAccion = IDAccion
        frm_autorizacion_acciones.lblAccion.Text = lblDescrpModulo.Text
        frm_autorizacion_acciones.ShowDialog(Me)
    End Sub

    Private Sub frm_superclave_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        CType(Me.Owner, Form).Activate()
    End Sub
End Class