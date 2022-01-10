Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_consulta_rnc

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim TxtBuscarClean As New Label

    Private Sub frm_cons_rnc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        Label11.Text = "RNC\Cédula"
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If txtBuscar.Text = "" Then
        Else

            TxtBuscarClean.Text = (Replace(txtBuscar.Text, "-", ""))

            DgvResultados.Rows.Clear()
            ConUtilitarios.Open()

            If RadioButton1.Checked = True Then
                Dim QuerySql As New MySqlCommand("SELECT * FROM Libregco_Utilitarios.RncDgii WHERE RNC like '%" + TxtBuscarClean.Text + "%'", ConUtilitarios)
                Dim LectorDGII As MySqlDataReader = QuerySql.ExecuteReader

                While LectorDGII.Read
                    DgvResultados.Rows.Add(LectorDGII.GetValue(0), LectorDGII.GetValue(1), LectorDGII.GetValue(2), LectorDGII.GetValue(3), LectorDGII.GetValue(4), LectorDGII.GetValue(5), LectorDGII.GetValue(6), LectorDGII.GetValue(7), LectorDGII.GetValue(8), LectorDGII.GetValue(9), LectorDGII.GetValue(10))
                End While
                LectorDGII.Close()

            Else
                Dim QuerySql As New MySqlCommand("SELECT * FROM Libregco_Utilitarios.RncDgii WHERE Nombre like '%" + TxtBuscarClean.Text + "%'", ConUtilitarios)
                Dim LectorDGII As MySqlDataReader = QuerySql.ExecuteReader

                While LectorDGII.Read
                    DgvResultados.Rows.Add(LectorDGII.GetValue(0), LectorDGII.GetValue(1), LectorDGII.GetValue(2), LectorDGII.GetValue(3), LectorDGII.GetValue(4), LectorDGII.GetValue(5), LectorDGII.GetValue(6), LectorDGII.GetValue(7), LectorDGII.GetValue(8), LectorDGII.GetValue(9), LectorDGII.GetValue(10))
                End While
                LectorDGII.Close()
            End If

            ConUtilitarios.Close()

            If DgvResultados.Rows.Count = 0 Then
                MessageBox.Show("El Registro Nacional del Contribuyente [RNC] introducido no se encuentra en la base de datos de la DGII.", "No hubieron resultados", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtBuscar.Focus()
            End If
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            Label11.Text = RadioButton1.Text
            txtBuscar.Location = New Point(85, 31)
            btnBuscar.Location = New Point(351, 31)

        Else
            Label11.Text = RadioButton2.Text
            txtBuscar.Location = New Point(134, 31)
            btnBuscar.Location = New Point(400, 31)
        End If
    End Sub

    Private Sub DgvResultados_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvResultados.CellDoubleClick
        frm_rnc_detalle.ShowDialog(Me)
    End Sub
End Class