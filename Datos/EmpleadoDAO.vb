Imports System.Data
Imports System.Data.SqlClient
Imports Sge.Entidades

Namespace Datos
    Public Class EmpleadoDAO

        Public Function Listar() As List(Of Empleado_Leer)
            Dim lista As New List(Of Empleado_Leer)

            Using cn = Conexion.ObtenerConexion()
                cn.Open()
                Using cmd As New SqlCommand("sp_Empleado_Listar", cn)
                    cmd.CommandType = CommandType.StoredProcedure

                    Using dr = cmd.ExecuteReader()
                        While dr.Read()
                            lista.Add(New Empleado_Leer With {
                                .ID = dr("ID"),
                                .NombreCompleto = dr("NombreCompleto"),
                                .FechaContratacion = dr("FechaContratacion"),
                                .Cargo = dr("Cargo"),
                                .Salario = dr("Salario"),
                                .Departamento = dr("Departamento"),
                                .login = dr("login"),
                                .estado = dr("estado"),
                                .CargoID = CInt(dr("CodCar")),
                                .DepartamentoID = CInt(dr("CodDep"))
                            })
                        End While
                    End Using
                End Using
            End Using

            Return lista
        End Function

        Public Function Crear(emp As Empleado) As Integer
            Dim resultado As Integer = -1
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
                    cmd.Parameters.AddWithValue("@login", emp.login)

                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        If dr.Read() Then
                            resultado = Convert.ToInt32(dr("Resultado"))
                        End If
                    End Using

                End Using
            End Using
            Return resultado
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

        Public Function Buscar(criterio As String) As List(Of Empleado_Leer)
            Dim lista As New List(Of Empleado_Leer)

            Using cn = Conexion.ObtenerConexion()
                cn.Open()
                Using cmd As New SqlCommand("sp_Empleado_Buscar", cn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@Buscar", criterio)

                    Using dr = cmd.ExecuteReader()
                        While dr.Read()
                            lista.Add(New Empleado_Leer With {
                                .ID = dr("ID"),
                                .NombreCompleto = dr("NombreCompleto"),
                                .FechaContratacion = dr("FechaContratacion"),
                                .Cargo = dr("Cargo"),
                                .Salario = dr("Salario"),
                                .Departamento = dr("Departamento"),
                                .login = dr("login"),
                                .estado = dr("estado"),
                                .CargoID = CInt(dr("CodCar")),
                                .DepartamentoID = CInt(dr("CodDep"))})
                        End While
                    End Using
                End Using
            End Using

            Return lista
        End Function

        Public Function BuscarCargos() As List(Of Cargos)
            Dim lista As New List(Of Cargos)

            Using cn = Conexion.ObtenerConexion()
                cn.Open()
                Using cmd As New SqlCommand("sp_Cargos_Listar", cn)
                    cmd.CommandType = CommandType.StoredProcedure

                    Using dr = cmd.ExecuteReader()
                        While dr.Read()
                            lista.Add(New Cargos With {
                                .ID = dr("ID"),
                                .NomCargo = dr("nomCargo")
                            })
                        End While
                    End Using
                End Using
            End Using
            Return lista
        End Function

        Public Function BuscarDepartamentos() As List(Of Departamentos)
            Dim lista As New List(Of Departamentos)

            Using cn = Conexion.ObtenerConexion()
                cn.Open()
                Using cmd As New SqlCommand("sp_Departamentos_Listar", cn)
                    cmd.CommandType = CommandType.StoredProcedure

                    Using dr = cmd.ExecuteReader()
                        While dr.Read()
                            lista.Add(New Departamentos With {
                                .ID = dr("ID"),
                                .NomDep = dr("nomDep")
                            })
                        End While
                    End Using
                End Using
            End Using
            Return lista
        End Function
    End Class
End Namespace
