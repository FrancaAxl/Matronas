Public Class Consulta
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        ' Código para manejar eventos de clic en el Label1
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' Ir a Consulta_Paciente
        Dim consultaPaciente As New Consulta_Paciente()
        consultaPaciente.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Ir a Consulta_Matrona
        Dim consultaMatrona As New Consulta_Matrona()
        consultaMatrona.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Ir a Consulta_Clase
        Dim consultaClase As New Consulta_Clase()
        consultaClase.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Ir a Consulta_Centro
        Dim consultaCentro As New Consulta_Centro()
        consultaCentro.Show()
        Me.Hide()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ' Regresar al MenuPrincipal
        Dim menu As New MenuPrincipal()
        menu.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        ' Código para manejar eventos de clic en el PictureBox1
    End Sub
End Class



