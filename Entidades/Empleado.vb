Namespace Entidades
    Public Class Empleado
        Public Property ID As Integer
        Public Property NombreCompleto As String
        Public Property FechaContratacion As Date
        Public Property Cargo As Integer
        Public Property Salario As Decimal
        Public Property Departamento As Integer
        Public Property login As String
        Public Property obs As String
        Public Property estado As Integer
    End Class

    Public Class Empleado_Leer
        Public Property ID As Integer
        Public Property NombreCompleto As String
        Public Property FechaContratacion As Date
        Public Property Cargo As String
        Public Property Salario As Decimal
        Public Property Departamento As String
        Public Property login As String
        Public Property obs As String
        Public Property estado As String
        Public Property CargoID As Integer
        Public Property DepartamentoID As Integer
    End Class

    Public Class Cargos
        Public Property ID As Integer
        Public Property NomCargo As String
    End Class

    Public Class Departamentos
        Public Property ID As Integer
        Public Property NomDep As String
    End Class

End Namespace
