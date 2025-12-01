Imports Sge.Entidades
Imports Sge.Datos

Namespace Negocio
    Public Class EmpleadoBL

        Private dao As New EmpleadoDAO()

        Public Function Listar() As List(Of Empleado_Leer)
            Return dao.Listar()
        End Function

        Public Function Crear(emp As Empleado) As Integer
            Return New EmpleadoDAO().Crear(emp)
        End Function

        Public Function Actualizar(emp As Empleado) As Boolean
            Return dao.Actualizar(emp)
        End Function

        Public Function Eliminar(id As Integer) As Boolean
            Return dao.Eliminar(id)
        End Function

        Public Function Buscar(criterio As String) As List(Of Empleado_Leer)
            Return dao.Buscar(criterio)
        End Function
        Public Function CargarCargos() As List(Of Cargos)
            Return dao.BuscarCargos()
        End Function
        Public Function CargarDepartamentos() As List(Of Departamentos)
            Return dao.BuscarDepartamentos()
        End Function
    End Class
End Namespace

