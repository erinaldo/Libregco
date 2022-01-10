Public Class frm_questions_facturacion
    Friend IDQuestion, IDArticulo, Abierta As Integer
    Friend Opciones As String
    Friend ArOpciones() As String

    Private Sub btnSi_Click(sender As Object, e As EventArgs) Handles btnSi.Click
        frm_facturacion.TablaQuestions.Rows.Add(IDQuestion, IDArticulo, GCTitulo.Text, Descripcion.Text, Abierta, Opciones, "Sí")
        Me.Close()
    End Sub

    Private Sub frm_questions_facturacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Opciones = "" Then
            If Abierta = 1 Then
                txtRepuestaAbierta.Focus()

            ElseIf Abierta = 0 Then
                btnSi.Focus()
            End If
        Else
            ArOpciones = Opciones.Split(",")

            FlowLayoutPanel1.Controls.Clear()

            For Each s As String In ArOpciones
                Dim nbtn As New XtraEditors.SimpleButton

                nbtn.Text = s
                nbtn.Size = New Size(113, 50)

                FlowLayoutPanel1.Controls.Add(nbtn)
                AddHandler nbtn.Click, AddressOf nbtnEventClick

            Next
        End If
    End Sub

    Private Sub nbtnEventClick(Sendr As Object, e As EventArgs)

        Dim Nfth As New XtraEditors.SimpleButton
        Nfth = CType(Sendr, XtraEditors.SimpleButton)

        frm_facturacion.TablaQuestions.Rows.Add(IDQuestion, IDArticulo, GCTitulo.Text, Descripcion.Text, Abierta, Opciones, Nfth.Text)

        Me.Close()
    End Sub
    Private Sub btnNo_Click(sender As Object, e As EventArgs) Handles btnNo.Click
        frm_facturacion.TablaQuestions.Rows.Add(IDQuestion, IDArticulo, GCTitulo.Text, Descripcion.Text, Abierta, Opciones, "No")
        Me.Close()
    End Sub

    Private Sub btnFinalizarAbierta_Click(sender As Object, e As EventArgs) Handles btnFinalizarAbierta.Click
        frm_facturacion.TablaQuestions.Rows.Add(IDQuestion, IDArticulo, GCTitulo.Text, Descripcion.Text, Abierta, Opciones, txtRepuestaAbierta.Text)
        Me.Close()
    End Sub
End Class