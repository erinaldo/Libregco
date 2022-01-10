Public Class frm_info_sys
    Dim TablaLicencia As DataTable
    Private Sub frm_info_sys_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TablaLicencia = New DataTable("Licencia")
        TablaLicencia.Columns.Add("Propiedades", System.Type.GetType("System.String"))
        TablaLicencia.Columns.Add("Valores", System.Type.GetType("System.String"))

        TablaLicencia.Rows.Add("Tipo de licencia", "")
        TablaLicencia.Rows.Add("Vencimiento", "")
        TablaLicencia.Rows.Add("Iguala", "")
        TablaLicencia.Rows.Add("Servicios", "")
        TablaLicencia.Rows.Add("Inicio de operaciones", "")
    End Sub
End Class