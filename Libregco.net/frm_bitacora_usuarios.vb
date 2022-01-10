Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.Drawing.Printing
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportAppServer
Imports System.Windows.Forms.DataVisualization.Charting

Public Class frm_bitacora_usuarios
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As New MySqlDataAdapter
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim Permisos As New ArrayList
    Dim lblIDEmpleado As New Label

    Private Sub frm_bitacora_usuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        FillEmpleado()
        FillPermisos()
        DgvPermisosOtorgados.Rows.Clear()
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub FillPermisos()
        Try
            Dim DsTemp As New DataSet

            cbxPermiso.DataSource = Nothing
            cbxPermiso.Items.Clear()

            ConMixta.Open()
            cmd = New MySqlCommand("SELECT IDPermisos,Concat(Modulos.Modulo,'->',ProcesosModulo.Proceso,'->',Permisos.Descripcion)  as Permi FROM" & SysName.Text & "permisos inner join" & SysName.Text & "procesosmodulo on permisos.IDProceso=ProcesosModulo.IDProcesosmodulo Inner join" & SysName.Text & "Modulos on Permisos.IDModulo=Modulos.IDModulo ORDER BY Permisos.IDModulo, Permisos.IDProceso", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "Permisos")

            cbxPermiso.ValueMember = "IDPermisos"
            cbxPermiso.DisplayMember = "Permi"
            cbxPermiso.DataSource = DsTemp.Tables("Permisos")
            ConMixta.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub FillEmpleado()
        Try

            Ds.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Nombre FROM Empleados ORDER BY Nombre ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Empleados")
            cbxEmpleado.Items.Clear()
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("Empleados")

            For Each Fila As DataRow In Tabla.Rows
                cbxEmpleado.Items.Add(Fila.Item("Nombre"))
            Next

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub cbxEmpleado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxEmpleado.SelectedIndexChanged
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDEmpleado FROM Empleados WHERE Nombre= '" + cbxEmpleado.SelectedItem + "'", ConLibregco)
        lblIDEmpleado.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()

        FillBitacora()
    End Sub

    Private Sub FillBitacora()
        Try
            DgvAccesos.Rows.Clear()
            ConLibregco.Open()

            If CheckBox1.Checked = False Then
                Dim Consulta As New MySqlCommand("SELECT Fecha,AreaImpresion.ComputerName,IF(Permisos.IDPermisos=1, 'Entrada al Sistema',concat(Modulos.Modulo,'->',ProcesosModulo.Proceso,'->',Permisos.Descripcion)) AS Entrada,Permisos.FormName FROM Libregco.bitacora INNER JOIN Libregco.AreaImpresion on Bitacora.IDEquipo=AreaImpresion.IDEquipo INNER JOIN Libregco.Permisos on Bitacora.IDPermiso=Permisos.IDPermisos INNER JOIN Libregco.Modulos on Permisos.IDModulo=Modulos.IDModulo INNER JOIN Libregco.ProcesosModulo on Permisos.IDProceso=ProcesosModulo.IDProcesosModulo Where Bitacora.IDEmpleado='" + lblIDEmpleado.Text + "' ORDER BY FECHA ASC", ConLibregco)
                Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

                While LectorDocumentos.Read
                    DgvAccesos.Rows.Add(LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), LectorDocumentos.GetValue(2), LectorDocumentos.GetValue(3))
                End While
                LectorDocumentos.Close()

            Else

                Dim Consulta As New MySqlCommand("SELECT Fecha,AreaImpresion.ComputerName,IF(Permisos.IDPermisos=1, 'Entrada al Sistema',concat(Modulos.Modulo,'->',ProcesosModulo.Proceso,'->',Permisos.Descripcion)) AS Entrada,Permisos.FormName FROM Libregco.bitacora INNER JOIN Libregco.AreaImpresion on Bitacora.IDEquipo=AreaImpresion.IDEquipo INNER JOIN Libregco.Permisos on Bitacora.IDPermiso=Permisos.IDPermisos INNER JOIN Libregco.Modulos on Permisos.IDModulo=Modulos.IDModulo INNER JOIN Libregco.ProcesosModulo on Permisos.IDProceso=ProcesosModulo.IDProcesosModulo Where Bitacora.IDEmpleado='" + lblIDEmpleado.Text + "' and Fecha between  '" + dtpInicial.Value.ToString("yyyy-MM-dd 00:00:00") + "' and '" + dtpFinal.Value.ToString("yyyy-MM-dd 23:59:59") + "' ORDER BY FECHA ASC", ConLibregco)
                Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

                While LectorDocumentos.Read
                    DgvAccesos.Rows.Add(LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), LectorDocumentos.GetValue(2), LectorDocumentos.GetValue(3))
                End While
                LectorDocumentos.Close()
            End If

            ConLibregco.Close()

        Catch ex As Exception
  InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Label2.Enabled = True
            Label3.Enabled = True
            dtpInicial.Enabled = True
            dtpFinal.Enabled = True
        Else
            Label2.Enabled = False
            Label3.Enabled = False
            dtpInicial.Enabled = False
            dtpFinal.Enabled = False
        End If

        FillBitacora()
    End Sub

    Private Sub dtpInicial_ValueChanged(sender As Object, e As EventArgs) Handles dtpInicial.ValueChanged
        FillBitacora()
        GetInformation()
    End Sub

    Private Sub dtpFinal_ValueChanged(sender As Object, e As EventArgs) Handles dtpFinal.ValueChanged
        FillBitacora()
        GetInformation()
    End Sub

    Private Sub GetInformation()
        Try
            If cbxPermiso.Text = "" Then
            Else
                Dim DsTemp As New DataSet

                If ConMixta.State = ConnectionState.Open Then
                    ConMixta.Close()
                End If

                Chart1.Series.Clear()
                ConMixta.Open()
                cmd = New MySqlCommand("SELECT ComputerName,count(identrada),date(bitacora.fecha) FROM" & SysName.Text & "bitacora inner join" & SysName.Text & "areaimpresion on bitacora.idequipo=areaimpresion.idequipo where idpermiso='" + cbxPermiso.SelectedValue.ToString() + "' and Bitacora.Fecha Between '" + dtpInicial.Value.ToString("yyyy-MM-dd 00:00:00") + "' and '" + dtpFinal.Value.ToString("yyyy-MM-dd 23:59:59") + "' group by bitacora.idequipo,day(bitacora.fecha) order by bitacora.fecha desc", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(DsTemp, "Bitacora")
                ConMixta.Close()

                Dim Tabla As DataTable = DsTemp.Tables("Bitacora")
                If Tabla.Rows.Count > 0 Then

                    For Each row As DataRow In Tabla.Rows
                        If Chart1.Series.Contains(Chart1.Series.FindByName(row.Item(0))) Then
                        Else
                            Dim Dataseries As Series = New Series()
                            Dataseries = Chart1.Series.Add(row.Item(0).ToString)
                            Dataseries.Name = row.Item(0).ToString
                            Dataseries.IsValueShownAsLabel = True
                            Dataseries.LabelBorderColor = Color.Black
                            Dataseries.LabelBorderDashStyle = ChartDashStyle.Solid
                            Dataseries.Font = New Font("Segoe UI", 9, FontStyle.Regular)

                        End If

                        Chart1.Series(row.Item(0).ToString).Points.AddXY(row.Item(2), row.Item(1))


                    Next
                End If

            End If


        Catch ex As Exception
            'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd.CommandText = Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub cbxPermiso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPermiso.SelectedIndexChanged
        GetInformation()
    End Sub

    Private Sub DgvPermisosOtorgados_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DgvPermisosOtorgados.CellValueChanged
        If e.RowIndex >= 0 Then
            If e.ColumnIndex > 1 Then
                Con.Open()
                sqlQ = "UPDATE PermisosEmpleados SET Acceso='" + Convert.ToInt16(CBool(DgvPermisosOtorgados.CurrentRow.Cells(3).Value)).ToString + "',Crear='" + Convert.ToInt16(CBool(DgvPermisosOtorgados.CurrentRow.Cells(4).Value)).ToString + "',Modificar='" + Convert.ToInt16(CBool(DgvPermisosOtorgados.CurrentRow.Cells(5).Value)).ToString + "',Imprimir='" + Convert.ToInt16(CBool(DgvPermisosOtorgados.CurrentRow.Cells(6).Value)).ToString + "' WHERE IDPermisoEmpleado='" + DgvPermisosOtorgados.CurrentRow.Cells(0).Value.ToString + "'"
                cmd = New MySqlCommand(sqlQ, Con)
                cmd.ExecuteNonQuery()
                Con.Close()
            End If
        End If
    End Sub

    Private Sub DgvPermisosOtorgados_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DgvPermisosOtorgados.CellEndEdit
        DgvPermisosOtorgados.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub DgvPermisosOtorgados_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DgvPermisosOtorgados.CurrentCellDirtyStateChanged
        If DgvPermisosOtorgados.IsCurrentCellDirty Then
            DgvPermisosOtorgados.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub


    Private Sub chkAcceso_CheckedChanged(sender As Object, e As EventArgs) Handles chkAcceso.CheckedChanged
        ConMixta.Open()

        For Each row As DataGridViewRow In DgvPermisosOtorgados.Rows
            row.Cells(3).Value = chkAcceso.Checked

            sqlQ = "UPDATE" & SysName.Text & "PermisosEmpleados SET Acceso='" + Convert.ToInt16(CBool(chkAcceso.Checked)).ToString + "' WHERE IDPermisoEmpleado='" + row.Cells(0).Value.ToString + "'"
            cmd = New MySqlCommand(sqlQ, ConMixta)
            cmd.ExecuteNonQuery()
        Next

        ConMixta.Close()
    End Sub

    Private Sub chkCrear_CheckedChanged(sender As Object, e As EventArgs) Handles chkCrear.CheckedChanged
        ConMixta.Open()

        For Each row As DataGridViewRow In DgvPermisosOtorgados.Rows
            row.Cells(4).Value = chkCrear.Checked

            sqlQ = "UPDATE" & SysName.Text & "PermisosEmpleados SET Crear='" + Convert.ToInt16(CBool(chkCrear.Checked)).ToString + "' WHERE IDPermisoEmpleado='" + row.Cells(0).Value.ToString + "'"
            cmd = New MySqlCommand(sqlQ, ConMixta)
            cmd.ExecuteNonQuery()
        Next

        ConMixta.Close()
    End Sub

    Private Sub chkModificar_CheckedChanged(sender As Object, e As EventArgs) Handles chkModificar.CheckedChanged
        ConMixta.Open()

        For Each row As DataGridViewRow In DgvPermisosOtorgados.Rows
            row.Cells(5).Value = chkModificar.Checked

            sqlQ = "UPDATE" & SysName.Text & "PermisosEmpleados SET Modificar='" + Convert.ToInt16(CBool(chkModificar.Checked)).ToString + "' WHERE IDPermisoEmpleado='" + row.Cells(0).Value.ToString + "'"
            cmd = New MySqlCommand(sqlQ, ConMixta)
            cmd.ExecuteNonQuery()
        Next

        ConMixta.Close()
    End Sub

    Private Sub chkImprimir_CheckedChanged(sender As Object, e As EventArgs) Handles chkImprimir.CheckedChanged
        ConMixta.Open()

        For Each row As DataGridViewRow In DgvPermisosOtorgados.Rows
            row.Cells(6).Value = chkImprimir.Checked

            sqlQ = "UPDATE" & SysName.Text & "PermisosEmpleados SET Imprimir='" + Convert.ToInt16(CBool(chkImprimir.Checked)).ToString + "' WHERE IDPermisoEmpleado='" + row.Cells(0).Value.ToString + "'"
            cmd = New MySqlCommand(sqlQ, ConMixta)
            cmd.ExecuteNonQuery()
        Next

        ConMixta.Close()
    End Sub

    Private Sub DgvPermisosOtorgados_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvPermisosOtorgados.CellMouseUp
        If e.RowIndex >= 0 Then
            If e.Button = Windows.Forms.MouseButtons.Right Then
                DgvPermisosOtorgados.Rows(e.RowIndex).Selected = True
                DgvPermisosOtorgados.CurrentCell = DgvPermisosOtorgados.Rows(e.RowIndex).Cells(0)
                CMenuPermisos.Show(DgvPermisosOtorgados, e.Location)
                CMenuPermisos.Show(Cursor.Position)
            End If
        End If
    End Sub

    Private Sub bt_Click(sender As Object, e As EventArgs) Handles bt.Click
        If DgvPermisosOtorgados.Rows.Count > 0 Then
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea descartar el permiso " & vbNewLine & vbNewLine & lblModulo.Text & "->" & lblProceso.Text & "->" & lblPermiso.Text & vbNewLine & vbNewLine & " del empleado " & DgvPermisosOtorgados.CurrentRow.Cells(2).Value.ToString & "?", "Descartar permisos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "Delete from" & SysName.Text & "PermisosEmpleados Where IDPermisoEmpleado=(" + DgvPermisosOtorgados.CurrentRow.Cells(0).Value.ToString + ")"

                ConMixta.Open()
                cmd = New MySqlCommand(sqlQ, ConMixta)
                cmd.ExecuteNonQuery()
                ConMixta.Close()

                DgvPermisosOtorgados.Rows.Remove(DgvPermisosOtorgados.CurrentRow)
            End If
        End If
    End Sub

    Private Sub btnAprobar_Click(sender As Object, e As EventArgs) Handles btnAprobar.Click
        Dim AccesoL, CrearL, ModificarL, ImprimirL As String

        If DgvPermisosOtorgados.Columns(3).ReadOnly = False Then
            DgvPermisosOtorgados.CurrentRow.Cells(3).Value = True
            AccesoL = 1
        Else
            AccesoL = 0
        End If
        If DgvPermisosOtorgados.Columns(4).ReadOnly = False Then
            DgvPermisosOtorgados.CurrentRow.Cells(4).Value = True
            CrearL = 1
        Else
            CrearL = 0
        End If

        If DgvPermisosOtorgados.Columns(5).ReadOnly = False Then
            DgvPermisosOtorgados.CurrentRow.Cells(5).Value = True
            ModificarL = 1
        Else
            ModificarL = 0
        End If

        If DgvPermisosOtorgados.Columns(6).ReadOnly = False Then
            DgvPermisosOtorgados.CurrentRow.Cells(6).Value = True
            ImprimirL = 1
        Else
            ImprimirL = 0
        End If


        ConMixta.Open()
        sqlQ = "UPDATE" & SysName.Text & "PermisosEmpleados SET Acceso='" + AccesoL + "',Crear='" + CrearL + "',Modificar='" + ModificarL + "',Imprimir='" + ImprimirL + "' WHERE IDPermisoEmpleado='" + DgvPermisosOtorgados.CurrentRow.Cells(0).Value.ToString + "'"
        cmd = New MySqlCommand(sqlQ, ConMixta)
        cmd.ExecuteNonQuery()
        ConMixta.Close()

    End Sub

    Private Sub btnNegar_Click(sender As Object, e As EventArgs) Handles btnNegar.Click
        DgvPermisosOtorgados.CurrentRow.Cells(3).Value = False
        DgvPermisosOtorgados.CurrentRow.Cells(4).Value = False
        DgvPermisosOtorgados.CurrentRow.Cells(5).Value = False
        DgvPermisosOtorgados.CurrentRow.Cells(6).Value = False

        ConMixta.Open()
        sqlQ = "UPDATE" & SysName.Text & "PermisosEmpleados SET Acceso='0',Crear='0',Modificar='0',Imprimir='0' WHERE IDPermisoEmpleado='" + DgvPermisosOtorgados.CurrentRow.Cells(0).Value.ToString + "'"
        cmd = New MySqlCommand(sqlQ, ConMixta)
        cmd.ExecuteNonQuery()
        ConMixta.Close()
    End Sub

    Private Sub frm_bitacora_usuarios_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            e.Handled = True
            Me.Close()
        End If
    End Sub

    Private Sub DgvPermisosOtorgados_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvPermisosOtorgados.CellContentClick
        If DgvPermisosOtorgados.Rows.Count > 0 Then
            If e.RowIndex >= 0 Then
                If e.ColumnIndex = 1 Or e.ColumnIndex = 2 Then
                    cbxEmpleado.Text = DgvPermisosOtorgados.Rows(e.RowIndex).Cells(2).Value
                    TabControl1.SelectedIndex = 0
                End If
            End If
        End If
    End Sub

    Private Sub DgvPermisosOtorgados_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvPermisosOtorgados.RowHeaderMouseClick
        If DgvPermisosOtorgados.Columns(3).ReadOnly = False Then
            DgvPermisosOtorgados.CurrentRow.Cells(3).Value = True
        End If
        If DgvPermisosOtorgados.Columns(4).ReadOnly = False Then
            DgvPermisosOtorgados.CurrentRow.Cells(4).Value = True
        End If
        If DgvPermisosOtorgados.Columns(5).ReadOnly = False Then
            DgvPermisosOtorgados.CurrentRow.Cells(5).Value = True
        End If
        If DgvPermisosOtorgados.Columns(6).ReadOnly = False Then
            DgvPermisosOtorgados.CurrentRow.Cells(6).Value = True
        End If
    End Sub

    Private Sub DgvPermisosOtorgados_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvPermisosOtorgados.RowHeaderMouseDoubleClick
        If DgvPermisosOtorgados.Columns(3).ReadOnly = False Then
            DgvPermisosOtorgados.CurrentRow.Cells(3).Value = False
        End If
        If DgvPermisosOtorgados.Columns(4).ReadOnly = False Then
            DgvPermisosOtorgados.CurrentRow.Cells(4).Value = False
        End If
        If DgvPermisosOtorgados.Columns(5).ReadOnly = False Then
            DgvPermisosOtorgados.CurrentRow.Cells(5).Value = False
        End If
        If DgvPermisosOtorgados.Columns(6).ReadOnly = False Then
            DgvPermisosOtorgados.CurrentRow.Cells(6).Value = False
        End If
    End Sub
End Class