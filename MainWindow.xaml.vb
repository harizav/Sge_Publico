Imports Sge.Entidades
Imports Sge.Negocio
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Class MainWindow

    Private bl As New EmpleadoBL()
    Private ListaEmpleados As List(Of Empleado_Leer)
    Private ListaCargos As List(Of Cargos)
    Private ListaDepartamentos As List(Of Departamentos)

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)

        dpFecha.Text = Date.Now
        CargarEmpleados()
        CargarComboCargos()
        CargarComboDepartamentos()

        ' Desactivar controles
        ControlarBtn(False)
    End Sub

    Private Sub CargarEmpleados()
        ListaEmpleados = bl.Listar()
        dgEmpleados.ItemsSource = ListaEmpleados
    End Sub

    Private Sub CargarComboDepartamentos()
        Dim Departamentos = bl.CargarDepartamentos()
        cmbDepartamento.ItemsSource = Departamentos
        cmbDepartamento.SelectedIndex = 0
    End Sub
    Private Sub CargarComboCargos()
        Dim cargos = bl.CargarCargos()
        cmbCargo.ItemsSource = cargos
        cmbCargo.SelectedIndex = 0
    End Sub
    Private Sub btnCrear_Click(sender As Object, e As RoutedEventArgs)

        Try
            'Si falla alguna validación, sale del método
            If Not ValidarCampos() Then Exit Sub

            'Crear el objeto empleado
            Dim emp As New Empleado With {
            .ID = CInt(txtID.Text),
            .NombreCompleto = txtNombre.Text,
            .FechaContratacion = dpFecha.SelectedDate,
            .Cargo = CInt(cmbCargo.SelectedValue),
            .Salario = CDec(txtSalario.Text),
            .Departamento = CInt(cmbDepartamento.SelectedValue),
            .login = "HARIZA"
        }

            Dim resultado As Integer = New EmpleadoBL().Crear(emp)

            Select Case resultado
                Case 0
                    MessageBox.Show("Empleado creado correctamente.")
                    CargarEmpleados()

                Case 1
                    MessageBox.Show("Ya existe un empleado con ese mismo ID. No se creó el registro.")

                Case Else
                    MessageBox.Show("Error inesperado.")
            End Select

        Catch ex As Exception
            MessageBox.Show("Error al crear el empleado: " & ex.Message)
        End Try

    End Sub
    Private Sub btnActualizar_Click(sender As Object, e As RoutedEventArgs)

        Try
            ' Validar todos los campos
            If Not ValidarCampos() Then Exit Sub

            ' Crear objeto empleado
            Dim emp As New Empleado With {
            .ID = CInt(txtID.Text),
            .NombreCompleto = txtNombre.Text,
            .FechaContratacion = dpFecha.SelectedDate,
            .Cargo = CInt(cmbCargo.SelectedValue),
            .Salario = CDec(txtSalario.Text),
            .Departamento = CInt(cmbDepartamento.SelectedValue)
        }

            bl.Actualizar(emp)
            CargarEmpleados()

            MessageBox.Show("Registro actualizado correctamente.")

        Catch ex As Exception
            MessageBox.Show("Error al actualizar: " & ex.Message)
        End Try

    End Sub


    Private Sub btnEliminar_Click(sender As Object, e As RoutedEventArgs)

        Try
            ' Validación del ID
            If String.IsNullOrWhiteSpace(txtID.Text) Then
                MessageBox.Show("Señor(a) Usuario, el campo ID debe tener un valor.",
                            "Validación", MessageBoxButton.OK, MessageBoxImage.Warning)
                Exit Sub
            End If

            ' Conversión segura de ID
            Dim idEmpleado As Integer
            If Not Integer.TryParse(txtID.Text, idEmpleado) Then
                MessageBox.Show("El ID debe ser un número válido.",
                            "Error", MessageBoxButton.OK, MessageBoxImage.Error)
                Exit Sub
            End If

            ' Llamado a la lógica de negocio
            bl.Eliminar(idEmpleado)

            MessageBox.Show("Registro eliminado correctamente.",
                        "Información", MessageBoxButton.OK, MessageBoxImage.Information)

            ' Refrescar la grilla
            CargarEmpleados()

        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al intentar eliminar el empleado:" & vbCrLf &
                        ex.Message,
                        "Error", MessageBoxButton.OK, MessageBoxImage.Error)
        End Try

    End Sub
    Private Sub btnLimpiar_Click(sender As Object, e As RoutedEventArgs)

        LimpiarControles(GridPrincipal)

        dpFecha.SelectedDate = Date.Now

        ' Selecciona el primer valor de los combos
        cmbCargo.SelectedIndex = 0
        cmbDepartamento.SelectedIndex = 0

        ' Devuelve el foco al primer campo
        txtID.Focus()

        ' Desactivar controles
        ControlarBtn(False)
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As RoutedEventArgs)
        dgEmpleados.ItemsSource = bl.Buscar(txtBuscar.Text.Trim())
    End Sub
    Private Sub dgEmpleados_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)

        If dgEmpleados.SelectedItem Is Nothing Then Exit Sub

        Dim emp As Empleado_Leer = CType(dgEmpleados.SelectedItem, Empleado_Leer)

        ' Llenar TextBox
        txtID.Text = emp.ID
        txtNombre.Text = emp.NombreCompleto
        dpFecha.Text = emp.FechaContratacion
        txtSalario.Text = emp.Salario

        ' Seleccionar el Cargo en el ComboBox
        cmbCargo.SelectedValue = emp.CargoID

        ' Seleccionar el Departamento
        cmbDepartamento.SelectedValue = emp.DepartamentoID

        ' validar controles
        ControlarBtn(True)

    End Sub

    Private Sub ControlarBtn(Valor As Boolean)
        btnActualizar.IsEnabled = Valor
        btnEliminar.IsEnabled = Valor
        btnCrear.IsEnabled = Not Valor
        txtID.IsEnabled = Not Valor
    End Sub
    Private Sub LimpiarControles(parent As DependencyObject)

        For i As Integer = 0 To VisualTreeHelper.GetChildrenCount(parent) - 1

            Dim child = VisualTreeHelper.GetChild(parent, i)

            If TypeOf child Is TextBox Then
                CType(child, TextBox).Clear()

            ElseIf TypeOf child Is DatePicker Then
                CType(child, DatePicker).SelectedDate = Nothing

            ElseIf TypeOf child Is ComboBox Then
                CType(child, ComboBox).SelectedIndex = 0

            End If

            ' Recursivo → limpia controles dentro de otros contenedores
            LimpiarControles(child)

        Next

    End Sub

    Private Function ValidarCampos() As Boolean

        '=== Validar ID ==='
        If String.IsNullOrWhiteSpace(txtID.Text) Then
            MessageBox.Show("El campo ID es obligatorio.")
            txtID.Focus()
            Return False
        End If

        If Not IsNumeric(txtID.Text) Then
            MessageBox.Show("El campo ID debe ser numérico.")
            txtID.Focus()
            Return False
        End If

        '=== Validar Nombre ==='
        If String.IsNullOrWhiteSpace(txtNombre.Text) Then
            MessageBox.Show("Debe ingresar un nombre.")
            txtNombre.Focus()
            Return False
        End If

        '=== Validar Fecha ==='
        If dpFecha.SelectedDate Is Nothing Then
            MessageBox.Show("Debe seleccionar la fecha de contratación.")
            dpFecha.Focus()
            Return False
        End If

        '=== Validar Cargo ==='
        If cmbCargo.SelectedValue Is Nothing Then
            MessageBox.Show("Debe seleccionar un cargo.")
            cmbCargo.Focus()
            Return False
        End If

        '=== Validar Salario ==='
        If String.IsNullOrWhiteSpace(txtSalario.Text) Then
            MessageBox.Show("Debe ingresar un salario.")
            txtSalario.Focus()
            Return False
        End If

        If Not IsNumeric(txtSalario.Text) Then
            MessageBox.Show("El salario debe ser numérico.")
            txtSalario.Focus()
            Return False
        End If

        '=== Validar Departamento ==='
        If cmbDepartamento.SelectedValue Is Nothing Then
            MessageBox.Show("Debe seleccionar un departamento.")
            cmbDepartamento.Focus()
            Return False
        End If

        Return True
    End Function
    Private Sub txtNombre_TextChanged(sender As Object, e As TextChangedEventArgs)
        Dim tb = CType(sender, TextBox)
        Dim pos As Integer = tb.SelectionStart   ' Guardar posición del cursor

        tb.Text = tb.Text.ToUpper()             ' Convertir a MAYÚSCULAS
        tb.SelectionStart = pos                 ' Restaurar posición
    End Sub
    Private Sub txtSalario_PreviewTextInput(sender As Object, e As TextCompositionEventArgs)

        Dim txt As TextBox = CType(sender, TextBox)

        ' Expresión: números + opcional punto + máximo dos decimales
        Dim regex As New Regex("^[0-9]*(\.[0-9]{0,2})?$")

        Dim futuro As String = txt.Text.Insert(txt.SelectionStart, e.Text)

        e.Handled = Not regex.IsMatch(futuro)
    End Sub
    Private Sub txtSalario_LostFocus(sender As Object, e As RoutedEventArgs)
        Dim valor As Decimal

        If Decimal.TryParse(txtSalario.Text, valor) Then
            'txtSalario.Text = valor.ToString("N2")   ' 1.234,56 o 1,234.56 según configuración regional
            txtSalario.Text = valor.ToString("C2")  ' Si quieres $1.234,56
        End If
    End Sub
    Private Sub txtSalario_Pasting(sender As Object, e As DataObjectPastingEventArgs)
        If e.DataObject.GetDataPresent(GetType(String)) Then

            Dim textoPegado As String = CType(e.DataObject.GetData(GetType(String)), String)
            Dim regex As New Regex("^[0-9]*(\.[0-9]{0,2})?$")

            If Not regex.IsMatch(textoPegado) Then
                e.CancelCommand()
            End If

        Else
            e.CancelCommand()
        End If
    End Sub
    Private Sub ValidarConexion()
        Try
            Using cn As New SqlConnection("Data Source=JBR2304;Initial Catalog=Amaris;User ID=app_amaris;Password=AppAmaris2024*;")
                cn.Open()
                MessageBox.Show("Conexión OK a Amaris")
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            End
        End Try
    End Sub
End Class
