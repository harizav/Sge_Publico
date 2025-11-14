Imports System.Configuration
Imports System.Data.SqlClient

Namespace Datos
    Public Class Conexion

        Private Shared ReadOnly Cadena As String =
            ConfigurationManager.ConnectionStrings("CN_SGE").ConnectionString

        Public Shared Function ObtenerConexion() As SqlConnection
            Return New SqlConnection(Cadena)
        End Function

    End Class
End Namespace
