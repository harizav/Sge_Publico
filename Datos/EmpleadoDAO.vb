Imports System.Data
Imports System.Data.SqlClient
Imports Sge.Entidades

Namespace Datos
    Public Class EmpleadoDAO

        Public Function Listar() As List(Of Empleado)
            Dim lista As New List(Of Empleado)

            Using cn = Conexion.ObtenerConexion()
                cn.Open()
                Using cmd As New SqlCommand("sp_Empleado_Listar", cn)
                    cmd.CommandType = CommandType.StoredProcedure

                    Using dr = cmd.ExecuteReader()
                        While dr.Read()
                            lista.Add(New Empleado With {
                                .ID = dr("ID"),
                                .NombreCompleto = dr("NombreCompleto"),
                                .FechaContratacion = dr("FechaContratacion"),
                                .Cargo = dr("Cargo"),
                                .Salario = dr("Salario"),
                                .Departamento = dr("Departamento")
                            })
                        End While
                    End Using
                End Using
            End Using

            Return lista
        End Function


        Public Function Crear(emp As Empleado) As Boolean
            Using cn = Conexion.ObtenerConexion()
                cn.Open()
                Using cmd As New SqlCommand("sp_Empleado_Crear", cn)
                    cmd.CommandType = CommandType.StoredProcedure

                    cmd.Parameters.AddWithValue("@ID", emp.ID)
                    cmd.Parameters.AddWithValue("@Nombre", emp.NombreCompleto)
                    cmd.Parameters.AddWithValue("@Fecha", emp.FechaContratacion)
                    cmd.Parameters.AddWithValue("@Cargo", emp.Cargo)
                    cmd.Parameters.AddWithValue("@Salario", emp.Salario)
                    cmd.Parameters.AddWithValue("@Departamento", emp.Departamento)

                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        End Function


        Public Function Actualizar(emp As Empleado) As Boolean
            Using cn = Conexion.ObtenerConexion()
                cn.Open()
                Using cmd As New SqlCommand("sp_Empleado_Actualizar", cn)
                    cmd.CommandType = CommandType.StoredProcedure

                    cmd.Parameters.AddWithValue("@ID", emp.ID)
                    cmd.Parameters.AddWithValue("@Nombre", emp.NombreCompleto)
                    cmd.Parameters.AddWithValue("@Fecha", emp.FechaContratacion)
                    cmd.Parameters.AddWithValue("@Cargo", emp.Cargo)
                    cmd.Parameters.AddWithValue("@Salario", emp.Salario)
                    cmd.Parameters.AddWithValue("@Departamento", emp.Departamento)

                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        End Function


        Public Function Eliminar(id As Integer) As Boolean
            Using cn = Conexion.ObtenerConexion()
                cn.Open()
                Using cmd As New SqlCommand("sp_Empleado_Eliminar", cn)
                    cmd.CommandType = CommandType.StoredProcedure

                    cmd.Parameters.AddWithValue("@ID", id)

                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        End Function

        Public Function Buscar(criterio As String) As List(Of Empleado)
            Dim lista As New List(Of Empleado)

            Using cn = Conexion.ObtenerConexion()
                cn.Open()
                Using cmd As New SqlCommand("sp_Empleado_Buscar", cn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@Buscar", criterio)

                    Using dr = cmd.ExecuteReader()
                        While dr.Read()
                            lista.Add(New Empleado With {
                                .ID = dr("ID"),
                                .NombreCompleto = dr("NombreCompleto"),
                                .FechaContratacion = dr("FechaContratacion"),
                                .Cargo = dr("Cargo"),
                                .Salario = dr("Salario"),
                                .Departamento = dr("Departamento")
                            })
                        End While
                    End Using
                End Using
            End Using

            Return lista
        End Function

    End Class
End Namespace
