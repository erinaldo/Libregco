Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_contraseña_empleado

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend SolicitarConfirmEmpleados As Integer

    Private Sub frm_contraseña_empleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetConfiguracion()
        FillVendedores()

        SearchControl1.Text = ""

        If txtUsuario.Tag.ToString <> "" Then
            Con.Open()
            cmd = New MySqlCommand("Select Nombre from Empleados where IDEmpleado='" + txtUsuario.Tag.ToString + "'", Con)
            txtUsuario.Text = Convert.ToString(cmd.ExecuteScalar())

            cmd = New MySqlCommand("Select RutaFoto from Empleados where IDEmpleado='" + txtUsuario.Tag.ToString + "'", Con)
            Dim Rut As String = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()

            If Rut <> "" Then
                If System.IO.File.Exists(Rut) Then
                    PictureBox1.Image = Image.FromFile(Rut)
                Else
                    PictureBox1.Image = My.Resources.no_photo
                End If
            End If
        End If


        If SolicitarConfirmEmpleados = 1 Then
            SplitContainer1.Panel2Collapsed = False

            txtPassword.Clear()
            txtPassword.Focus()

        Else
            SplitContainer1.Panel2Collapsed = True

        End If
    End Sub

    Private Sub SetConfiguracion()
        Con.Open()

        If Me.Owner.Name = frm_registro_compras.Name Then
            'Solicitar confirmacion de vendedor en facturacion
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=183", Con)
            SolicitarConfirmEmpleados = Convert.ToInt16(cmd.ExecuteScalar())
        Else
            'Solicitar confirmacion de vendedor en facturacion
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=181", Con)
            SolicitarConfirmEmpleados = Convert.ToInt16(cmd.ExecuteScalar())

        End If

        Con.Close()
    End Sub

    Private Sub txtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress
        Try
            If e.KeyChar = ChrW(Keys.Enter) Then
                SimpleButton1.PerformClick()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & "txtPassword_KeyPress")
        End Try
    End Sub

    Private Sub FillVendedores()
        Try
            Dim SizeT As Integer = 80
            Dim dstemp As New DataSet

            Con.Open()

            If Me.Owner.Name = frm_facturacion.Name Then
                cmd = New MySqlCommand("SELECT IDEmpleado,Nombre,Puesto,RutaFoto,ImagenChat FROM Empleados WHERE Nulo=0 and EsVendedor=1 ORDER BY Nombre ASC", Con)
                Me.Text = "Seleccione el vendedor"
            ElseIf Me.Owner.Name = frm_cotizacion.Name Then
                cmd = New MySqlCommand("SELECT IDEmpleado,Nombre,Puesto,RutaFoto,ImagenChat FROM Empleados WHERE Nulo=0 and EsVendedor=1 ORDER BY Nombre ASC", Con)
                Me.Text = "Seleccione el vendedor"
            ElseIf Me.Owner.Name = frm_punto_venta_lite.Name Then
                cmd = New MySqlCommand("SELECT IDEmpleado,Nombre,Puesto,RutaFoto,ImagenChat FROM Empleados WHERE Nulo=0 and EsVendedor=1 ORDER BY Nombre ASC", Con)
                Me.Text = "Seleccione el vendedor"
            Else
                cmd = New MySqlCommand("SELECT IDEmpleado,Nombre,Puesto,RutaFoto,ImagenChat,Coalesce((SELECT count(IDEmpleadoRec) FROM Compras Where Empleados.IDEmpleado=Compras.IDEmpleadoRec GROUP BY IDEmpleadoREC),0) as Cantidad From Empleados Where Empleados.Nulo=0    Order by Cantidad DESC", Con)
                Me.Text = "Seleccione el empleado"
            End If

            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(dstemp, "Empleados")
            ImageListBoxControl1.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = dstemp.Tables("Empleados")

            For Each Fila As DataRow In Tabla.Rows
                Dim itm As New DevExpress.XtraEditors.Controls.ImageListBoxItem
                Dim wFile As System.IO.FileStream

                itm.Value = Fila.Item("IDEmpleado")
                itm.Description = Fila.Item("Nombre")

                If Fila.Item("RutaFoto") <> "" Then
                    If System.IO.File.Exists(Fila.Item("RutaFoto")) Then
                        wFile = New FileStream(Fila.Item("RutaFoto"), FileMode.Open, FileAccess.Read)
                        itm.ImageOptions.Image = ResizeImageWXH(System.Drawing.Image.FromStream(wFile), SizeT, SizeT)

                    Else

                        itm.ImageOptions.Image = ResizeImageWXH(My.Resources.no_photo, SizeT, SizeT)
                    End If

                Else

                    itm.ImageOptions.Image = ResizeImageWXH(My.Resources.no_photo, SizeT, SizeT)

                End If

                ImageListBoxControl1.Items.Add(itm)
            Next


            If Tabla.Rows.Count = 0 Then
                MessageBox.Show("No se pudieron cargar los empleados para definirlos en los registros." & vbNewLine & vbNewLine & "El registro no se podrá generar hasta que se cumpla la condición.", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Close()
            End If

        Catch ex As Exception
            'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub frm_contraseña_empleado_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If ImageListBoxControl1.SelectedIndex < 0 Then
            MessageBox.Show("Seleccione el vendedor que efectúa la venta.", "Elija el vendedor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            ImageListBoxControl1.Focus()
            Exit Sub
        End If

        If Me.Owner.Name = frm_cotizacion.Name Then
            If SolicitarConfirmEmpleados = 1 Then
                If txtUsuario.Tag.ToString = "" Then
                    MessageBox.Show("Escriba el código del empleado para autorizar el proceso.", "Código del empleado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Close()
                    Exit Sub
                End If

                If txtPassword.Text = "" Then
                    MessageBox.Show("Escriba la clave o contraseña del vendedor para autorizar el proceso.", "Credenciales del vendedor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    txtPassword.Focus()
                    Exit Sub
                Else
                    Con.Open()
                    cmd = New MySqlCommand("Select Password from Empleados Where IDEmpleado='" + txtUsuario.Tag.ToString + "'", Con)
                    Dim Password As String = Convert.ToString(cmd.ExecuteScalar())

                    cmd = New MySqlCommand("Select FactorNumerico from Empleados Where IDEmpleado='" + txtUsuario.Tag.ToString + "'", Con)
                    Dim FactorNumerico As String = Convert.ToString(cmd.ExecuteScalar())
                    Con.Close()

                    If Password = txtPassword.Text Or FactorNumerico = txtPassword.Text Then
                        frm_cotizacion.txtVendedor.Tag = ImageListBoxControl1.SelectedValue.ToString
                        frm_cotizacion.txtVendedor.Text = ImageListBoxControl1.SelectedItem.ToString
                        frm_cotizacion.ChangedCodeEmployee = False
                    Else
                        MessageBox.Show("La contraseña es incorrecta. Por favor vuelva a intentarlo.", "Contraseña Incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        frm_cotizacion.txtVendedor.Tag = ""
                        frm_cotizacion.txtVendedor.Text = ""
                        frm_cotizacion.txtVendedor.Focus()
                        Exit Sub
                    End If
                End If

            Else
                frm_cotizacion.txtVendedor.Tag = ImageListBoxControl1.SelectedValue.ToString
                frm_cotizacion.txtVendedor.Text = ImageListBoxControl1.SelectedItem.ToString
            End If

        ElseIf Me.Owner.Name = frm_punto_venta_lite.Name Then
            If SolicitarConfirmEmpleados = 1 Then
                If txtUsuario.Tag.ToString = "" Then
                    MessageBox.Show("Escriba el código del empleado para autorizar el proceso.", "Código del empleado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Close()
                    Exit Sub
                End If

                If txtPassword.Text = "" Then
                    MessageBox.Show("Escriba la clave o contraseña del vendedor para autorizar el proceso.", "Credenciales del vendedor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    txtPassword.Focus()
                    Exit Sub
                Else
                    Con.Open()
                    cmd = New MySqlCommand("Select Password from Empleados Where IDEmpleado='" + txtUsuario.Tag.ToString + "'", Con)
                    Dim Password As String = Convert.ToString(cmd.ExecuteScalar())

                    cmd = New MySqlCommand("Select FactorNumerico from Empleados Where IDEmpleado='" + txtUsuario.Tag.ToString + "'", Con)
                    Dim FactorNumerico As String = Convert.ToString(cmd.ExecuteScalar())
                    Con.Close()

                    If Password = txtPassword.Text Or FactorNumerico = txtPassword.Text Then
                        If txtUsuario.Tag.ToString <> frm_punto_venta_lite.lblIDUsuario.Text Then
                            frm_punto_venta_lite.lblIDUsuario.Text = txtUsuario.Tag.ToString
                            frm_punto_venta_lite.lblStatusBar.Text = "El código de usuario ha cambiado temporalmente a [" & txtUsuario.Tag.ToString & "] " & txtUsuario.Text & "."
                        End If
                        frm_punto_venta_lite.txtIDVendedor.Text = ImageListBoxControl1.SelectedValue.ToString
                        frm_punto_venta_lite.txtVendedor.Text = ImageListBoxControl1.SelectedItem.ToString
                        frm_punto_venta_lite.ChangedCodeEmployee = False
                    Else
                        MessageBox.Show("La contraseña es incorrecta. Por favor vuelva a intentarlo.", "Contraseña Incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        frm_punto_venta_lite.txtIDVendedor.Clear()
                        frm_punto_venta_lite.txtVendedor.Clear()
                        frm_punto_venta_lite.txtIDVendedor.Focus()
                        Exit Sub
                    End If
                End If

            Else
                frm_punto_venta_lite.txtIDVendedor.Text = ImageListBoxControl1.SelectedValue.ToString
                frm_punto_venta_lite.txtVendedor.Text = ImageListBoxControl1.SelectedItem.ToString
            End If

        ElseIf Me.Owner.Name = frm_facturacion.Name Then
            If SolicitarConfirmEmpleados = 1 Then

                If txtUsuario.Tag.ToString = "" Then
                    MessageBox.Show("Escriba el código del empleado para autorizar el proceso.", "Código del empleado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Close()
                    Exit Sub
                End If

                If txtPassword.Text = "" Then
                    MessageBox.Show("Escriba la clave o contraseña del vendedor para autorizar el proceso.", "Credenciales del vendedor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    txtPassword.Focus()
                    Exit Sub
                Else
                    Con.Open()
                    cmd = New MySqlCommand("Select Password from Empleados Where IDEmpleado='" + txtUsuario.Tag.ToString + "'", Con)
                    Dim Password As String = Convert.ToString(cmd.ExecuteScalar())

                    cmd = New MySqlCommand("Select FactorNumerico from Empleados Where IDEmpleado='" + txtUsuario.Tag.ToString + "'", Con)
                    Dim FactorNumerico As String = Convert.ToString(cmd.ExecuteScalar())

                    Con.Close()

                    If Password = txtPassword.Text Or FactorNumerico = txtPassword.Text Then

                        If txtUsuario.Tag.ToString <> DtEmpleado.Rows(0).item("IDEmpleado").ToString() Then
                            frm_facturacion.lblUsuario.Text = txtUsuario.Text.ToString
                            frm_facturacion.lblIDUsuario.Text = txtUsuario.Tag.ToString
                            frm_facturacion.lblStatusBar.Text = "El código de usuario ha cambiado temporalmente a [" & txtUsuario.Tag.ToString & "] " & txtUsuario.Text & "."

                        End If

                        frm_facturacion.txtVendedor.Tag = ImageListBoxControl1.SelectedValue.ToString
                        frm_facturacion.txtVendedor.Text = ImageListBoxControl1.SelectedItem.ToString
                        frm_facturacion.txtCodigoArticulo.Focus()
                    Else
                        MessageBox.Show("La contraseña es incorrecta. Por favor vuelva a intentarlo.", "Contraseña Incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        frm_facturacion.txtVendedor.Tag = ""
                        frm_facturacion.txtVendedor.Text = ""
                        txtPassword.Focus()
                        Exit Sub
                    End If
                End If

            Else
                frm_facturacion.txtVendedor.Tag = ImageListBoxControl1.SelectedValue.ToString
                frm_facturacion.txtVendedor.Text = ImageListBoxControl1.SelectedItem.ToString
            End If

        ElseIf Me.Owner.Name = frm_registro_factura_sd.Name Then
            If SolicitarConfirmEmpleados = 1 Then
                If txtUsuario.Tag.ToString = "" Then
                    MessageBox.Show("Escriba el código del empleado para autorizar el proceso.", "Código del empleado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Close()
                    Exit Sub
                End If

                If txtPassword.Text = "" Then
                    MessageBox.Show("Escriba la clave o contraseña del vendedor para autorizar el proceso.", "Credenciales del vendedor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    txtPassword.Focus()
                    Exit Sub
                Else
                    Con.Open()
                    cmd = New MySqlCommand("Select Password from Empleados Where IDEmpleado='" + txtUsuario.Tag.ToString + "'", Con)
                    Dim Password As String = Convert.ToString(cmd.ExecuteScalar())

                    cmd = New MySqlCommand("Select FactorNumerico from Empleados Where IDEmpleado='" + txtUsuario.Tag.ToString + "'", Con)
                    Dim FactorNumerico As String = Convert.ToString(cmd.ExecuteScalar())

                    Con.Close()

                    If Password = txtPassword.Text Or FactorNumerico = txtPassword.Text Then

                        If txtUsuario.Tag.ToString <> DtEmpleado.Rows(0).item("IDEmpleado").ToString() Then
                            frm_registro_factura_sd.lblIDUsuario.Text = txtUsuario.Tag.ToString
                            frm_registro_factura_sd.lblStatusBar.Text = "El código de usuario ha cambiado temporalmente a [" & txtUsuario.Tag.ToString & "] " & txtUsuario.Text & "."
                        End If

                        frm_registro_factura_sd.txtIDVendedor.Text = ImageListBoxControl1.SelectedValue.ToString
                        frm_registro_factura_sd.txtVendedor.Text = ImageListBoxControl1.SelectedItem.ToString
                        frm_registro_factura_sd.ChangedCodeEmployee = False
                    Else
                        MessageBox.Show("La contraseña es incorrecta. Por favor vuelva a intentarlo.", "Contraseña Incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        frm_registro_factura_sd.txtIDVendedor.Clear()
                        frm_registro_factura_sd.txtVendedor.Clear()
                        frm_registro_factura_sd.txtIDVendedor.Focus()
                        Exit Sub
                    End If
                End If
            Else
                frm_registro_factura_sd.txtIDVendedor.Text = ImageListBoxControl1.SelectedValue.ToString
                frm_registro_factura_sd.txtVendedor.Text = ImageListBoxControl1.SelectedItem.ToString
            End If


        ElseIf Me.Owner.Name = frm_pedidos.Name Then
            If SolicitarConfirmEmpleados = 1 Then
                If txtUsuario.Tag.ToString = "" Then
                    MessageBox.Show("Escriba el código del empleado para autorizar el proceso.", "Código del empleado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Close()
                    Exit Sub
                End If

                If txtPassword.Text = "" Then
                    MessageBox.Show("Escriba la clave o contraseña del vendedor para autorizar el proceso.", "Credenciales del vendedor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    txtPassword.Focus()
                    Exit Sub
                Else
                    Con.Open()
                    cmd = New MySqlCommand("Select Password from Empleados Where IDEmpleado='" + txtUsuario.Tag.ToString + "'", Con)
                    Dim Password As String = Convert.ToString(cmd.ExecuteScalar())

                    cmd = New MySqlCommand("Select FactorNumerico from Empleados Where IDEmpleado='" + txtUsuario.Tag.ToString + "'", Con)
                    Dim FactorNumerico As String = Convert.ToString(cmd.ExecuteScalar())

                    Con.Close()

                    If Password = txtPassword.Text Or FactorNumerico = txtPassword.Text Then

                        If txtUsuario.Tag.ToString <> DtEmpleado.Rows(0).item("IDEmpleado").ToString() Then
                            frm_pedidos.lblIDUsuario.Text = txtUsuario.Tag.ToString
                            frm_pedidos.lblStatusBar.Text = "El código de usuario ha cambiado temporalmente a [" & txtUsuario.Tag.ToString & "] " & txtUsuario.Text & "."
                        End If

                        frm_pedidos.txtIDVendedor.Text = ImageListBoxControl1.SelectedValue.ToString
                        frm_pedidos.txtVendedor.Text = ImageListBoxControl1.SelectedItem.ToString
                        frm_pedidos.ChangedCodeEmployee = False
                    Else
                        MessageBox.Show("La contraseña es incorrecta. Por favor vuelva a intentarlo.", "Contraseña Incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        frm_pedidos.txtIDVendedor.Clear()
                        frm_pedidos.txtVendedor.Clear()
                        frm_pedidos.txtIDVendedor.Focus()
                        Exit Sub
                    End If
                End If

            Else
                frm_pedidos.txtIDVendedor.Text = ImageListBoxControl1.SelectedValue.ToString
                frm_pedidos.txtVendedor.Text = ImageListBoxControl1.SelectedItem.ToString
            End If

        ElseIf Me.Owner.Name = frm_registro_compras.Name Then
            If SolicitarConfirmEmpleados = 1 Then
                If txtUsuario.Tag.ToString = "" Then
                    MessageBox.Show("Escriba el código del empleado para autorizar el proceso.", "Código del empleado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Close()
                    Exit Sub
                End If

                If txtPassword.Text = "" Then
                    MessageBox.Show("Escriba la clave o contraseña del vendedor para autorizar el proceso.", "Credenciales del vendedor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    txtPassword.Focus()
                    Exit Sub
                Else
                    Con.Open()
                    cmd = New MySqlCommand("Select Password from Empleados Where IDEmpleado='" + txtUsuario.Tag.ToString + "'", Con)
                    Dim Password As String = Convert.ToString(cmd.ExecuteScalar())

                    cmd = New MySqlCommand("Select FactorNumerico from Empleados Where IDEmpleado='" + txtUsuario.Tag.ToString + "'", Con)
                    Dim FactorNumerico As String = Convert.ToString(cmd.ExecuteScalar())

                    Con.Close()

                    If Password = txtPassword.Text Or FactorNumerico = txtPassword.Text Then
                        frm_registro_compras.txtRecepcion.Tag = ImageListBoxControl1.SelectedValue.ToString
                        frm_registro_compras.txtRecepcion.Text = ImageListBoxControl1.SelectedItem.ToString
                    Else
                        MessageBox.Show("La contraseña es incorrecta. Por favor vuelva a intentarlo.", "Contraseña Incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        frm_registro_compras.txtRecepcion.Tag = ""
                        frm_registro_compras.txtRecepcion.Text = ""
                        frm_registro_compras.txtRecepcion.Focus()
                        Exit Sub
                    End If
                End If

            Else
                frm_registro_compras.txtRecepcion.Tag = ImageListBoxControl1.SelectedValue.ToString
                frm_registro_compras.txtRecepcion.Text = ImageListBoxControl1.SelectedItem.ToString
            End If

        End If


        Close()
    End Sub

    Private Sub txtUsuario_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtUsuario.ButtonClick
        frm_buscar_mant_empleados.ShowDialog(Me)
    End Sub

    Private Sub ImageListBoxControl1_MouseDown(sender As Object, e As MouseEventArgs) Handles ImageListBoxControl1.MouseDown
        Try
            If SolicitarConfirmEmpleados = 0 Then
                If e.Button = System.Windows.Forms.MouseButtons.Left AndAlso e.Clicks = 2 Then
                    SimpleButton1.PerformClick()
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ImageListBoxControl1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ImageListBoxControl1.KeyPress
        SimpleButton1.PerformClick()
    End Sub
End Class