Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports DevExpress.Utils

Public Class frm_mant_medidas
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim Permisos As New ArrayList
    Dim sqlQ As String = ""
    Dim TablaArticulo As DataTable
    Dim RepositorySecondID As New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit() With {.LinkColor = SystemColors.Highlight}
    Dim RepositoryDescrip As New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit() With {.WordWrap = True, .AcceptsReturn = False, .AcceptsTab = False}

    Private Sub frm_mant_medidas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        SetTablaArticulos()
        LimpiarDatos()
        ActualizarTodo()
        Permisos = PasarPermisos(Me.Tag)
    End Sub

    Private Sub SetTablaArticulos()
        TablaArticulo = New DataTable("Articulos")

        ' Create DataColumn objects of data types.
        TablaArticulo.Columns.Add("IDPrecio", System.Type.GetType("System.String"))
        TablaArticulo.Columns.Add("IDArticulo", System.Type.GetType("System.String"))
        TablaArticulo.Columns.Add("Descripcion", System.Type.GetType("System.String"))
        TablaArticulo.Columns.Add("Referencia", System.Type.GetType("System.String"))
        TablaArticulo.Columns.Add("Piezaje", System.Type.GetType("System.Double"))
        TablaArticulo.Columns.Add("Precio A", System.Type.GetType("System.Double"))
        TablaArticulo.Columns.Add("Precio B", System.Type.GetType("System.Double"))
        TablaArticulo.Columns.Add("Precio C", System.Type.GetType("System.Double"))
        TablaArticulo.Columns.Add("Precio D", System.Type.GetType("System.Double"))

        GridArticulos.DataSource = TablaArticulo
        GridView1.Columns(1).ColumnEdit = RepositorySecondID
        GridView1.Columns(2).ColumnEdit = RepositoryDescrip
        GridView1.Columns("IDPrecio").Visible = False
        GridView1.Columns("IDArticulo").Width = 60
        GridView1.Columns("IDArticulo").Caption = "Código"
        GridView1.Columns("Descripcion").Width = 180
        GridView1.Columns("Descripcion").Caption = "Descripción"
        GridView1.Columns("Referencia").Width = 80
        GridView1.Columns("Piezaje").Width = 60
        GridView1.Columns("Precio A").Width = 80
        GridView1.Columns("Precio A").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("Precio A").DisplayFormat.FormatString = "C2"
        GridView1.Columns("Precio B").Width = 80
        GridView1.Columns("Precio B").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("Precio B").DisplayFormat.FormatString = "C2"
        GridView1.Columns("Precio C").Width = 80
        GridView1.Columns("Precio C").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("Precio C").DisplayFormat.FormatString = "C2"
        GridView1.Columns("Precio D").Width = 80
        GridView1.Columns("Precio D").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("Precio D").DisplayFormat.FormatString = "C2"

        For i = 0 To 8
            GridView1.Columns(i).OptionsColumn.ReadOnly = True
            GridView1.Columns(i).OptionsColumn.AllowEdit = False
        Next

    End Sub

    Sub RefrescarTabla()
        Try
            Dim dstemp As New DataSet
            TablaArticulo.Rows.Clear()

            ConMixta.Open()
            cmd = New MySqlCommand("SELECT IDPrecios,PrecioArticulo.IDArticulo,Articulos.Descripcion,Articulos.Referencia,Piezaje,PrecioCredito,PrecioContado,Precio3,Precio4 FROM libregco.precioarticulo INNER JOIN Libregco.Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida where PrecioArticulo.IDMedida='" + txtIDMedida.Text + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(dstemp, "Articulos")
            ConMixta.Close()

            For Each dt As DataRow In dstemp.Tables("Articulos").Rows
                TablaArticulo.Rows.Add(dt.Item(0), dt.Item(1), dt.Item(2), dt.Item(3), dt.Item(4), dt.Item(5), dt.Item(6), dt.Item(7), dt.Item(8))
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()

        Con.Open()

        'Redondear al entero mas cercano
        cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=186", Con)
        chkRedondearPrecios.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))


        Con.Close()
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Sub FillMedidas()
        Ds.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Abreviatura FROM Medida Where Desactivar=0 and IDMedida<>'" + txtIDMedida.Text + "' ORDER BY Medida ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Medida")
        cbxMedida.Items.Clear()
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("Medida")
        For Each Fila As DataRow In Tabla.Rows
            cbxMedida.Items.Add(Fila.Item("Abreviatura"))
        Next

    End Sub

    Private Sub chkDesactivar_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesactivar.CheckedChanged
        If chkDesactivar.Checked = True Then
            InhabilitarMedida()
        Else
            HabilitarMedida()
        End If
    End Sub

    Private Sub HabilitarMedida()
        txtIDMedida.Enabled = True
        txtMedida.Enabled = True
    End Sub

    Private Sub InhabilitarMedida()
        txtIDMedida.Enabled = False
        txtMedida.Enabled = False
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub ActualizarTodo()
        FillMedidas()
        FillTipoMoneda()
    End Sub

    Private Sub LimpiarDatos()
        txtIDMedida.Clear()
        txtMedida.Clear()
        txtAbreviatura.Clear()
        chkDesactivar.Checked = False
        chkFraccionamiento.Checked = False
        txtPrecioA.EditValue = 0
        txtPrecioB.EditValue = 0
        txtPrecioC.EditValue = 0
        txtPrecioD.EditValue = 0
        txtCosto.EditValue = 0
        rdbConstante.Checked = True
        Groupbox3.Enabled = False
        TablaArticulo.Rows.Clear()
        txtMedida.Focus()
    End Sub

    Private Sub GuardarDatos()
        Try
            ConLibregco.Open()
            cmd = New MySqlCommand(sqlQ, ConLibregco)
            cmd.ExecuteNonQuery()
            ConLibregco.Close()
        Catch ex As Exception
            ConLibregco.Close()
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub UltMedida()
        If txtIDMedida.Text = "" Then
            ConLibregco.Open()
            cmd = New MySqlCommand("Select IDMedida from Medida where IDMedida= (Select Max(IDMedida) from Medida)", ConLibregco)
            txtIDMedida.Text = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_medidas.ShowDialog(Me)
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarRegistroToolStripMenuItem.Click
        btnGuardarC.PerformClick()
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnEliminar.PerformClick()
    End Sub

    Private Sub frm_mant_medidas_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        If Me.Owner.Name = frm_mant_articulos.Name Then
            frm_mant_articulos.cbxMedida.Items.Clear()
            frm_mant_articulos.FillMedidas()
            frm_mant_articulos.RefrescarTablaPrecios()
        End If
        txtIDMedida.Clear()
        txtMedida.Clear()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If chkDesactivar.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("La Medida " & txtMedida.Text & "  ya está desactivado del sistema. Desea volver a activarlo?", "Activar Medida", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                chkDesactivar.Checked = False
                sqlQ = "UPDATE Medida SET Medida='" + txtMedida.Text + "',Abreviatura='" + txtAbreviatura.Text + "',Fraccionamiento='" + Convert.ToInt16(chkFraccionamiento.Checked).ToString + "',Desactivar='" + Convert.ToInt16(chkDesactivar.Checked).ToString + "',TipoMedida='" + If(rdbConstante.Checked = True, 0, 1).ToString + "',IDMoneda='" + cbxMoneda.EditValue.ToString + "',PrecioAMedida='" + CDbl(txtPrecioA.EditValue).ToString + "',PrecioBMedida='" + CDbl(txtPrecioB.EditValue).ToString + "',PrecioCMedida='" + CDbl(txtPrecioC.EditValue).ToString + "',PrecioDMedida='" + CDbl(txtPrecioD.EditValue).ToString + "',CostoMedida='" + CDbl(txtCosto.EditValue).ToString + "',MedidaDinamica='" + cbxMedida.Text.ToString + "' WHERE IDMedida= (" + txtIDMedida.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                chkDesactivar.Checked = False
            End If
        ElseIf txtIDMedida.Text = "" Then
            MessageBox.Show("No hay un registro de medidas abierto para desactivar", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            frm_buscar_medidas.ShowDialog(Me)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea desactivar el registro de la medida " & txtMedida.Text & " del sistema?", "Desactivar Medida", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                chkDesactivar.Checked = True
                sqlQ = "UPDATE Medida SET Medida='" + txtMedida.Text + "',Abreviatura='" + txtAbreviatura.Text + "',Fraccionamiento='" + Convert.ToInt16(chkFraccionamiento.Checked).ToString + "',Desactivar='" + Convert.ToInt16(chkDesactivar.Checked).ToString + "',TipoMedida='" + If(rdbConstante.Checked = True, 0, 1).ToString + "',IDMoneda='" + cbxMoneda.EditValue.ToString + "',PrecioAMedida='" + CDbl(txtPrecioA.EditValue).ToString + "',PrecioBMedida='" + CDbl(txtPrecioB.EditValue).ToString + "',PrecioCMedida='" + CDbl(txtPrecioC.EditValue).ToString + "',PrecioDMedida='" + CDbl(txtPrecioD.EditValue).ToString + "',CostoMedida='" + CDbl(txtCosto.EditValue).ToString + "',MedidaDinamica='" + cbxMedida.Text.ToString + "' WHERE IDMedida= (" + txtIDMedida.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                chkDesactivar.Checked = True
            End If
        End If
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub chkFraccionamiento_CheckedChanged(sender As Object, e As EventArgs) Handles chkFraccionamiento.CheckedChanged
        If chkFraccionamiento.Checked = True Then
            lblMensajeFraccionamiento.Text = "Los artículos que utilicen esta medida podrán ser manipulados a través de números enteros y racionales."
        Else
            lblMensajeFraccionamiento.Text = "Los artículos que utilicen esta medida sólo podrán ser manipulados a través de números enteros."
        End If
    End Sub

    Private Sub btnGuardarC_Click(sender As Object, e As EventArgs) Handles btnGuardarC.Click
        If txtMedida.Text = "" Then
            MessageBox.Show("Escriba el nombre de la medida a procesar.", "Nombre de la Medida", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtMedida.Focus()
            Exit Sub
        ElseIf txtAbreviatura.Text = "" Then
            MessageBox.Show("Escriba la abreviatura de la medida a procesar.", "Nombre de la abreviatura", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtAbreviatura.Focus()
            Exit Sub
        End If

        If txtIDMedida.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea agregar la medida " & txtMedida.Text & " en la base de datos?", "Guardar Nueva Medida", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO Medida (Medida,Abreviatura,Fraccionamiento,Desactivar,TipoMedida,IDMoneda,PrecioAMedida,PrecioBMedida,PrecioCMedida,PrecioDMedida,CostoMedida,MedidaDinamica) VALUES ('" + txtMedida.Text + "','" + txtAbreviatura.Text + "','" + Convert.ToInt16(chkFraccionamiento.Checked).ToString + "','" + Convert.ToInt16(chkDesactivar.Checked).ToString + "','" + If(rdbConstante.Checked = True, 0, 1).ToString + "','" + cbxMoneda.EditValue.ToString + "','" + CDbl(txtPrecioA.EditValue).ToString + "','" + CDbl(txtPrecioB.EditValue).ToString + "','" + CDbl(txtPrecioC.EditValue).ToString + "','" + CDbl(txtPrecioD.EditValue).ToString + "','" + CDbl(txtCosto.EditValue).ToString + "','" + cbxMedida.Text.ToString + "')"
                GuardarDatos()
                UltMedida()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar los cambios realizados en el registro?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE Medida SET Medida='" + txtMedida.Text + "',Abreviatura='" + txtAbreviatura.Text + "',Fraccionamiento='" + Convert.ToInt16(chkFraccionamiento.Checked).ToString + "',Desactivar='" + Convert.ToInt16(chkDesactivar.Checked).ToString + "',TipoMedida='" + If(rdbConstante.Checked = True, 0, 1).ToString + "',IDMoneda='" + cbxMoneda.EditValue.ToString + "',PrecioAMedida='" + CDbl(txtPrecioA.EditValue).ToString + "',PrecioBMedida='" + CDbl(txtPrecioB.EditValue).ToString + "',PrecioCMedida='" + CDbl(txtPrecioC.EditValue).ToString + "',PrecioDMedida='" + CDbl(txtPrecioD.EditValue).ToString + "',CostoMedida='" + CDbl(txtCosto.EditValue).ToString + "',MedidaDinamica='" + cbxMedida.Text.ToString + "' WHERE IDMedida= (" + txtIDMedida.Text + ")"
                GuardarDatos()
                CalcularNuevosPrecios
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub CalcularNuevosPrecios()
        If rdbDinamica.Checked = True Then
            If CDbl(txtCosto.EditValue) > 0 And CDbl(txtPrecioA.EditValue) > 0 And CDbl(txtPrecioB.EditValue) > 0 And CDbl(txtPrecioC.EditValue) > 0 And CDbl(txtPrecioD.EditValue) > 0 Then
                ConLibregco.Open()
                Con.Open()

                For Each dt As DataRow In TablaArticulo.Rows
                    If CDbl(dt.Item("Piezaje")) > 0 Then
                        cmd = New MySqlCommand("UPDATE Libregco.PrecioArticulo SET Costo='" + RoundUp(CDbl(CDbl(txtCosto.EditValue) * CDbl(dt.Item("Piezaje"))), Convert.ToInt16(chkRedondearPrecios.Checked)).ToString + "',CostoFinal='" + RoundUp(CDbl(CDbl(txtCosto.EditValue) * CDbl(dt.Item("Piezaje"))), Convert.ToInt16(chkRedondearPrecios.Checked)).ToString + "',PrecioContado='" + RoundUp(CDbl(CDbl(txtPrecioB.EditValue) * CDbl(dt.Item("Piezaje"))), Convert.ToInt16(chkRedondearPrecios.Checked)).ToString + "',PrecioCredito='" + RoundUp(CDbl(CDbl(txtPrecioA.EditValue) * CDbl(dt.Item("Piezaje"))), Convert.ToInt16(chkRedondearPrecios.Checked)).ToString + "',Precio3='" + RoundUp(CDbl(CDbl(txtPrecioC.EditValue) * CDbl(dt.Item("Piezaje"))), Convert.ToInt16(chkRedondearPrecios.Checked)).ToString + "',Precio4='" + RoundUp(CDbl(CDbl(txtPrecioD.EditValue) * CDbl(dt.Item("Piezaje"))), Convert.ToInt16(chkRedondearPrecios.Checked)).ToString + "',CostoClave='" + ConvertCostKey(DTConfiguracion.Rows(78 - 1).Item("Value1Var").ToString, CInt(CDbl(CDbl(txtCosto.EditValue) * CDbl(dt.Item("Piezaje"))))).ToString + "' WHERE IDPrecios= '" + dt.Item(0).ToString + "'", ConLibregco)
                        cmd.ExecuteNonQuery()

                        UpdateLastUpdatePrices(dt.Item(0).ToString)
                    End If
                Next

                ConLibregco.Close()
                Con.Close()

                RefrescarTabla()
            End If
        End If

    End Sub

    Private Sub FillTipoMoneda()
        ConLibregco.Open()
        Ds.Clear()
        cbxMoneda.Properties.Items.Clear()
        cmd = New MySqlCommand("SELECT IDTipoMoneda,Texto FROM tipomoneda order by IDTipoMoneda ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "tipomoneda")
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("tipomoneda")

        For Each Fila As DataRow In Tabla.Rows
            Dim nvmoneda As New DevExpress.XtraEditors.Controls.ImageComboBoxItem

            nvmoneda.Description = Fila.Item("Texto")
            nvmoneda.Value = Fila.Item("IDTipoMoneda")

            If Fila.Item("IDTipoMoneda") = 1 Then
                nvmoneda.ImageIndex = 0
            ElseIf Fila.Item("IDTipoMoneda") = 2 Then
                nvmoneda.ImageIndex = 1
            ElseIf Fila.Item("IDTipoMoneda") = 3 Then
                nvmoneda.ImageIndex = 2
            End If

            cbxMoneda.Properties.Items.Add(nvmoneda)
        Next

        cbxMoneda.SelectedIndex = 0
    End Sub

    Private Sub rdbConstante_CheckedChanged(sender As Object, e As EventArgs) Handles rdbConstante.CheckedChanged
        If rdbConstante.Checked = True Then
            Groupbox3.Enabled = False
        Else
            Groupbox3.Enabled = True
        End If

        If txtPrecioA.Text = "" Then
            txtPrecioA.EditValue = CDbl(0).ToString("C")
        End If
        If txtCosto.Text = "" Then
            txtCosto.EditValue = CDbl(0).ToString("C")
        End If
    End Sub

    Private Sub cbxMedida_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxMedida.SelectedIndexChanged
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDMedida FROM Medida WHERE Abreviatura= '" + cbxMedida.SelectedItem + "'", ConLibregco)
        cbxMedida.Tag = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
    End Sub

End Class