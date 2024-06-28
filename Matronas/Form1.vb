Imports System.Data.SqlClient

Public Class Form1
    Dim conexion As SqlConnection
    Dim comando As New SqlCommand

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            conexion = New SqlConnection("server=AXELFRANCA\SQLEXPRESS;database=FPEA_Proyecto;integrated security=true")
            conexion.Open()
            MessageBox.Show("Conexión a la base de datos exitosa")
            conexion.Close()
        Catch ex As Exception
            MessageBox.Show("Error al conectar a la base de datos en Form1_Load: " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Supongamos que TextBox1 es para el nombre de usuario y TextBox2 para la contraseña
        Dim nombreUsuario As String = TextBox1.Text
        Dim contrasenaUsuario As String = TextBox2.Text

        ' Consulta SQL para verificar las credenciales
        Dim consulta As String = "SELECT COUNT(*) FROM FPEA_usuario WHERE nombre_usuario = @nombreUsuario AND contrasena_usuario = @contrasenaUsuario"

        Try
            conexion.Open()

            comando = New SqlCommand(consulta, conexion)
            comando.Parameters.AddWithValue("@nombreUsuario", nombreUsuario)
            comando.Parameters.AddWithValue("@contrasenaUsuario", contrasenaUsuario)

            Dim resultado As Integer = Convert.ToInt32(comando.ExecuteScalar())

            If resultado > 0 Then
                MessageBox.Show("Inicio de sesión exitoso")
                ' Crear una nueva instancia de MenuPrincipal y mostrarla
                Dim menu As New MenuPrincipal()
                menu.Show()
                ' Ocultar el formulario actual
                Me.Hide()
            Else
                MessageBox.Show("Nombre de usuario o contraseña incorrectos")
            End If

        Catch ex As Exception
            MessageBox.Show("Error al conectar a la base de datos en Button1_Click: " & ex.Message)
        Finally
            If conexion.State = ConnectionState.Open Then
                conexion.Close()
            End If
        End Try
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        ' Código para manejar eventos de clic en el Label1
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        ' Código para manejar eventos de clic en el Label2
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        ' Código para manejar eventos de clic en el PictureBox1
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Cerrar la aplicación
        Application.Exit()
    End Sub
End Class




