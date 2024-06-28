Public Class MenuPrincipal
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        ' Código para manejar eventos de clic en el PictureBox1
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Código para manejar eventos de clic en el Button3 consulta
        Dim formConsulta As New Consulta()
        formConsulta.Show()
        Me.Hide() ' Oculta el formulario actual
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Código para manejar eventos de clic en el Button1 alta
        Dim formAlta As New alta()
        formAlta.Show()
        Me.Hide() ' Oculta el formulario actual
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Código para manejar eventos de clic en el Button2 actualizar
        Dim formActualizar As New Actualizar()
        formActualizar.Show()
        Me.Hide() ' Oculta el formulario actual
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' Código para manejar eventos de clic en el Button4 eliminar
        Dim formEliminar As New Eliminar()
        formEliminar.Show()
        Me.Hide() ' Oculta el formulario actual
    End Sub
End Class
