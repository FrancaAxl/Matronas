Imports System.Data.SqlClient

Public Class Consulta_Clase
    Private conexion As SqlConnection
    Private comando As SqlCommand

    Private Sub Consulta_Clase_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Asignar los manejadores de eventos manualmente
        AddHandler Button1.Click, AddressOf Button1_Click
        AddHandler Button2.Click, AddressOf Button2_Click
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        ' Aquí va el código para ejecutar el procedimiento almacenado y llenar el DataGridView
        Dim idClase As Integer
        If Integer.TryParse(TextBox1.Text, idClase) Then
            Try
                ' Cadena de conexión
                conexion = New SqlConnection("server=AXELFRANCA\SQLEXPRESS;database=FPEA_Proyecto;integrated security=true")
                conexion.Open()
                MessageBox.Show("Conexión exitosa!") ' Mensaje de depuración

                ' Comando SQL
                comando = New SqlCommand("CP_FPEA_Select_Clase", conexion)
                comando.CommandType = CommandType.StoredProcedure
                comando.Parameters.AddWithValue("@ID_clase", idClase)

                ' Adaptador de datos y DataTable
                Dim adapter As New SqlDataAdapter(comando)
                Dim table As New DataTable()
                adapter.Fill(table)

                ' Asignar DataSource
                DataGridView1.DataSource = table
            Catch ex As SqlException
                MessageBox.Show("Error de SQL: " & ex.Message)
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
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        ' Código para manejar eventos de clic en el Label1
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        ' Código para manejar eventos de clic en el Label2
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        ' Código para manejar eventos de cambio de texto en el TextBox1
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        ' Código para manejar eventos de clic en el DataGridView1
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        ' Código para manejar eventos de clic en el PictureBox1
    End Sub
End Class



