Imports System.Data.SqlClient

Public Class Consulta_Matrona
    Private conexion As SqlConnection
    Private comando As SqlCommand

    Private Sub Consulta_Matrona_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Asignar los manejadores de eventos manualmente
        AddHandler Button1.Click, AddressOf Button1_Click
        AddHandler Button2.Click, AddressOf Button2_Click
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        ' Aquí va el código para ejecutar el procedimiento almacenado y llenar el DataGridView
        Dim idMatrona As Integer
        If Integer.TryParse(TextBox1.Text, idMatrona) Then
            Try
                MessageBox.Show("Intentando conectar con la base de datos...") ' Mensaje de depuración

                ' Cadena de conexión
                conexion = New SqlConnection("server=AXELFRANCA\SQLEXPRESS;database=FPEA_Proyecto;integrated security=true")
                conexion.Open()

                MessageBox.Show("Conexión exitosa!") ' Mensaje de depuración

                ' Comando SQL
                comando = New SqlCommand("CP_FPEA_Select_Matrona", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@ID_MATRONA", idMatrona)

                ' Adaptador de datos y DataTable
                Dim adapter As New SqlDataAdapter(comando)
                Dim table As New DataTable()
                adapter.Fill(table)

                ' Asignar DataSource
                DataGridView1.DataSource = table
            Catch ex As Exception
                MessageBox.Show("Error al conectar a la base de datos: " & ex.Message)
            Finally
                ' Cerrar conexión
                If conexion IsNot Nothing AndAlso conexion.State = ConnectionState.Open Then
                    conexion.Close()
                    MessageBox.Show("Conexión cerrada.") ' Mensaje de depuración
                End If
            End Try
        Else
            MessageBox.Show("Por favor ingrese un ID válido.")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Dim consulta As New Consulta()
        consulta.Show()
        Me.Hide()
    End Sub


End Class


