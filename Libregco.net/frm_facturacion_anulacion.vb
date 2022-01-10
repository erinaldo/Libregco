Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportAppServer
Imports System.Drawing.Printing

Public Class frm_facturacion_anulacion
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim AnulacionAprobada As Boolean = False

    Private Sub frm_facturacion_anulacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        FillTipoAnulacion
        CargarLibregco()
        lblNombre.Text = ""
        lblFecha.Text = ""
        lblFactura.Text = ""
        lblTotal.Text = ""

        If Me.Owner.Name = frm_facturacion.Name Then
            Me.Text = "Anulación de factura"
            Label1.Text = "Factura"
            lblFactura.Text = frm_facturacion.txtSecondID.Text
            lblNombre.Text = frm_facturacion.txtNombre.Text
            lblFecha.Text = frm_facturacion.txtFecha.Text & " " & frm_facturacion.txtHora.Text
            lblTotal.Text = CDbl(frm_facturacion.txtNeto.Text).ToString("C")
            txtMotivos.Clear()

            txtUsuario.Text = frm_inicio.lblNombre.Text
            txtUsuario.Tag = DtEmpleado.Rows(0).item("IDEmpleado").ToString()

            If frm_facturacion.chkDesactivar.Checked = True Then
                ConMixta.Open()
                cmd = New MySqlCommand("SELECT TipoAnulacion.TipoAnulacion FROM" & SysName.Text & "facturadatos inner join Libregco.TipoAnulacion on FacturaDatos.ClasificacionAnulacion=tipoanulacion.idTipoAnulacion Where IDFacturaDatos='" + frm_facturacion.txtIDFactura.Text + "'", ConMixta)
                cbxClasificacion.Text = Convert.ToString(cmd.ExecuteScalar())

                cmd = New MySqlCommand("SELECT MotivoAnulacion FROM" & SysName.Text & "facturadatos where IDFacturaDatos='" + frm_facturacion.txtIDFactura.Text + "'", ConMixta)
                txtMotivos.Text = Convert.ToString(cmd.ExecuteScalar())

                ConMixta.Close()
            End If


        ElseIf Me.Owner.Name = frm_cierre_facturas.name Then
            Me.Text = "Anulación de prefactura"
            Label1.Text = "Prefactura"

            lblFactura.Text = frm_cierre_facturas.GridView1.GetFocusedRowCellValue("SecondID")
            lblNombre.Text = frm_cierre_facturas.GridView1.GetFocusedRowCellValue("NoombreFactura")
            lblFecha.Text = frm_cierre_facturas.GridView1.GetFocusedRowCellValue("FechaHora")
            lblTotal.Text = CDbl(frm_cierre_facturas.GridView1.GetFocusedRowCellValue("TotalNeto")).ToString("C")
            txtMotivos.Clear()

            txtUsuario.Text = frm_inicio.lblNombre.Text
            txtUsuario.Tag = DtEmpleado.Rows(0).item("IDEmpleado").ToString()
        End If
    End Sub

    Private Sub FillTipoAnulacion()
        Try
            Ds.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT idTipoAnulacion,TipoAnulacion FROM libregco.tipoanulacion", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "tipoanulacion")
            cbxClasificacion.Items.Clear()
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("tipoanulacion")

            For Each Fila As DataRow In Tabla.Rows
                cbxClasificacion.Items.Add(Fila.Item("TipoAnulacion"))
            Next

            If Tabla.Rows.Count > 0 Then
            Else
                MessageBox.Show("No se encontraron tipos de anulaciones hábiles en la base de datos. Inserte tipos de anulaciones hábiles para procesar los registros de los clientes.", "No se encontraron tipos de anulaciones", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Close()
            End If
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If cbxClasificacion.Text = "" Then
            MessageBox.Show("Seleccione una clasificación de anulación.")
            cbxClasificacion.Focus()
            Exit Sub
        ElseIf txtMotivos.Text = "" Then
            MessageBox.Show("Especique los motivos de la anulación de la " & Label1.Text.ToLower & ".")
            txtMotivos.Focus()
            Exit Sub
        ElseIf Len(txtMotivos.Text) < 20 Then
            MessageBox.Show("Haga una explicación más detallada de los motivos de la anulación.")
            txtMotivos.Focus()
            Exit Sub
        End If

        Dim Result As MsgBoxResult = MessageBox.Show("Está seguro anular la " & Label1.Text.ToLower & " " & lblFactura.Text & "?", "Anular " & Label1.Text.ToLower, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If Result = MsgBoxResult.Yes Then
            frm_superclave.IDAccion.Text = 44
            frm_superclave.ShowDialog(Me)
            If ControlSuperClave = 1 Then
                Exit Sub
            Else
                Me.Close()
            End If
        End If
    End Sub

    Private Sub cbxClasificacion_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbxClasificacion.SelectionChangeCommitted
        txtMotivos.Focus()
    End Sub

    Private Sub cbxClasificacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxClasificacion.SelectedIndexChanged
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT idTipoAnulacion FROM Libregco.tipoanulacion where idTipoAnulacion='" + cbxClasificacion.Text + "'", ConLibregco)
        cbxClasificacion.Tag = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
    End Sub

End Class