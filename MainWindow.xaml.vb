Imports Sge.Negocio
Imports Sge.Entidades

Class MainWindow

    Private bl As New EmpleadoBL()
    Private ListaEmpleados As List(Of Empleado)

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        CargarEmpleados()
    End Sub

    Private Sub CargarEmpleados()
        ListaEmpleados = bl.Listar()
        dgEmpleados.ItemsSource = ListaEmpleados
    End Sub

    Private Sub btnCrear_Click(sender As Object, e As RoutedEventArgs)
        Dim emp As New Empleado With {
            .ID = Integer.Parse(txtID.Text),
            .NombreCompleto = txtNombre.Text,
            .FechaContratacion = dpFecha.SelectedDate,
            .Cargo = txtCargo.Text,
            .Salario = Decimal.Parse(txtSalario.Text),
            .Departamento = txtDepartamento.Text,
            .login = "HARIZA",
            .estado = 1
        }

        bl.Crear(emp)
        CargarEmpleados()
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As RoutedEventArgs)
        Dim emp As New Empleado With {
            .ID = Integer.Parse(txtID.Text),
            .NombreCompleto = txtNombre.Text,
            .FechaContratacion = dpFecha.SelectedDate,
            .Cargo = txtCargo.Text,
            .Salario = Decimal.Parse(txtSalario.Text),
            .Departamento = txtDepartamento.Text
        }

        bl.Actualizar(emp)
        CargarEmpleados()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As RoutedEventArgs)
        bl.Eliminar(Integer.Parse(txtID.Text))
        CargarEmpleados()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As RoutedEventArgs)
        dgEmpleados.ItemsSource = bl.Buscar(txtBuscar.Text.Trim())
    End Sub

End Class
