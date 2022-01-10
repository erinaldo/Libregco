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
Imports DevExpress.XtraScheduler

Public Class frm_agenda_cheques
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim DsNew As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim Permisos As New ArrayList
    Dim dsTemp As New DataSet

    Private Sub frm_agenda_cheques_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        FillCuentasBancarias()
        Permisos = PasarPermisos(Me.Tag)
    End Sub

    Private Sub FillCuentasBancarias()
        Dim DsTemp As New DataSet

        cbxCuenta.DataSource = Nothing
        cbxCuenta.Items.Clear()

        ConMixta.Open()
        cmd = New MySqlCommand("SELECT IDCuenta,NoCuenta FROM" & SysName.Text & "cuentasbancarias ORDER BY Creacion ASC", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(DsTemp, "cuentasbancarias")
        cbxCuenta.ValueMember = "IDCuenta"
        cbxCuenta.DisplayMember = "NoCuenta"
        cbxCuenta.DataSource = DsTemp.Tables("cuentasbancarias")
        ConMixta.Close()

    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub cbxCuenta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCuenta.SelectedIndexChanged
        dsTemp.Clear()
        ConMixta.Open()
        cmd = New MySqlCommand("Select * from" & SysName.Text & "CuentasBancarias where IDCuenta='" + cbxCuenta.SelectedValue + "' ", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dsTemp, "CuentasBancarias")
        ConMixta.Close()

        Dim Tabla As DataTable = dsTemp.Tables("CuentasBancarias")

        If Tabla.Rows.Count > 0 Then

        End If
    End Sub
End Class