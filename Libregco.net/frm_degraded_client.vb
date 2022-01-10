Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO

Public Class frm_degraded_client
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend IDCliente As New Label
    Private Sub frm_degraded_client_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        FillCustomer()
    End Sub

    Private Sub FillCustomer()
        Try
            Dim DsTemp, DsTemp1 As New DataSet

            ConLibregco.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT IDCliente,Nombre,BalanceGeneral,CerrarCredito,CalificacionAutonoma,Calificacion.Calificacion,(SELECT Ruta FROM Libregco.documentosclientes Where DocumentosClientes.IDCliente=Clientes.IDCliente and IDClase=1 LIMIT 1) as Foto FROM libregco.clientes inner join Libregco.Calificacion on Calificacion.IDCalificacion=Clientes.IDCalificacion where IDCliente='" + IDCliente.Text + "'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "Clientes")
            ConLibregco.Close()

            Dim Tabla As DataTable = DsTemp.Tables("Clientes")

            If Tabla.Rows.Count = 0 Then
            Else
                lblNombre.Text = Tabla.Rows(0).Item("Nombre")
                lblCalificacion.Text = Tabla.Rows(0).Item("Calificacion")
                lblBalanceGeneral.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")
                lblCalificacionAutonoma.Text = Tabla.Rows(0).Item("CalificacionAutonoma")

                If Tabla.Rows(0).Item("CerrarCredito") = 1 Then
                    lblEstadoCredito.Text = "Desactivado"
                Else
                    lblEstadoCredito.Text = "Activo"
                End If


                If TypeConnection.Text = 1 Then
                    If IsDBNull(Tabla.Rows(0).Item("Foto")) Then
                        PicImagen.Image = My.Resources.No_Image
                    Else
                        Dim ExistFile As Boolean = System.IO.File.Exists(Tabla.Rows(0).Item("Foto"))
                        If ExistFile = True Then
                            Dim wFile As System.IO.FileStream
                            wFile = New FileStream(Tabla.Rows(0).Item("Foto"), FileMode.Open, FileAccess.Read)
                            PicImagen.Image = System.Drawing.Image.FromStream(wFile)
                            wFile.Close()
                        Else
                            MessageBox.Show("Se ha encontrado un archivo que ha sido específicado como una foto de cliente. Sin embargo, el archivo ha sido movido o eliminado de la ruta de acceso suministrada a la base de datos." & vbNewLine & vbNewLine & "Por favor verifique la integridad de la ruta de acceso válida en '" & Tabla.Rows(0).Item("Foto") & "' en el directorio.", "Archivo no encontrado en el servidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        End If
                    End If
                End If

                ConMixta.Open()
                DsTemp1.Clear()
                cmd = New MySqlCommand("SELECT SecondID,Fecha,Balance,if (fechavencimiento>now(),0,datediff(now(),fechavencimiento)) as DiasVencidos,if (balance=0,concat(datediff(now(),fecha),' días'),'N/A') as Diasdurados FROM" & SysName.Text & "facturadatos where IDCliente='" + IDCliente.Text + "'", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(DsTemp1, "FacturaDatos")
                ConMixta.Close()

                Dim Tabla1 As DataTable = DsTemp1.Tables("FacturaDatos")

                For Each dtrow As DataRow In Tabla1.Rows
                    DgvFacturas.Rows.Add(dtrow.Item(0), CDate(dtrow.Item(1)).ToString("dd/MM/yyyy"), CDbl(dtrow.Item(2)).ToString("C"), dtrow.Item(3), dtrow.Item(4))
                Next

                DgvFacturas.ClearSelection()

            End If
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub


End Class