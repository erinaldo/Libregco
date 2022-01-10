Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_consulta_rapida_no_factura
    Dim sqlQ As String=""
    Dim cmd, cmd1 As MySqlCommand
    Dim Adaptador As MySqlDataAdapter

    Private Sub frm_consulta_rapida_no_factura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        txtBuscar.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        Try
            Dim DsTemp As New DataSet

            If txtBuscar.Text = "" Then
                MessageBox.Show("No se especificó un número de factura en la consulta.", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else

                DsTemp.Clear()
                ConMixta.Open()
                cmd = New MySqlCommand("Select Clientes.IDCliente,Clientes.Nombre from" & SysName.Text & "FacturaDatos INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente Where FacturaDatos.SecondID='" + txtBuscar.Text + "'", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(DsTemp, "Clientes")
                ConMixta.Close()

                Dim Tabla As DataTable = DsTemp.Tables("Clientes")

                If Tabla.Rows.Count = 0 Then
                    MessageBox.Show("No se encontraron resultados con el valor '" & txtBuscar.Text & "'.", "No se encontraron resultados", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    txtBuscar.Focus()

                ElseIf Tabla.Rows.Count = 1 Then
                    frm_buscar_clientes.txtBuscar.Text = (Tabla.Rows(0).Item("Nombre"))
                    Close()

                ElseIf Tabla.Rows.Count > 1 Then
                    Dim Stringer As String

                    For Each row As DataRow In Tabla.Rows
                        Stringer = "[" & row.Item("IDCliente") & "] " & row.Item("Nombre") & vbNewLine & Stringer
                    Next

                    MessageBox.Show("Se encontraron múltiples clientes con el número de factura " & txtBuscar.Text & "." & vbNewLine & vbNewLine & "Los resultados son los siguientes:" & vbNewLine & vbNewLine & Stringer, "Múltiples resultados", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                    Close()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show("Se ha producido un error al intentar consultar con el valor específicado.", "Error en consulta", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub frm_consulta_rapida_no_factura_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnConsultar.PerformClick()
        End If
    End Sub

End Class