--USE AMARIS
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
==================================================================================================================    
' Creación: Procedimiento para crear en la tabla Empleados"  
' Fecha Creación: 14/11/2025                     
' Autor: Humberto R. Ariza V. - XXXXX  
' Proyecto: SGE  
' Solicitud: RRHH
==================================================================================================================    
*/   
IF OBJECT_ID (N'sp_Empleado_Crear', N'P') IS NOT NULL
    DROP PROCEDURE sp_Empleado_Crear;
GO 

CREATE PROCEDURE sp_Empleado_Crear
(
    @ID INT,
    @Nombre NVARCHAR(200),
    @Fecha DATE,
    @Cargo NVARCHAR(100),
    @Salario DECIMAL(18,2),
    @Departamento NVARCHAR(100),
	@login NVARCHAR(10),
	@obs NVARCHAR (200)= 'Creación desde la App'
)
AS
BEGIN
    SET NOCOUNT ON;
    -- Validar duplicidad por ID
    IF EXISTS(SELECT 1 FROM Empleados 
              WHERE ID = @ID)
    BEGIN
        SELECT 1 AS Resultado;  -- 1 = DUPLICADO
        RETURN;
	END

    INSERT INTO Empleados (ID, NombreCompleto, FechaContratacion, Cargo, Salario, Departamento, login, obs, fec_con, estado)
    VALUES (@ID, @Nombre, @Fecha, @Cargo, @Salario, @Departamento, @login, @obs, GETDATE(), 1);

	SELECT 0 AS Resultado;
END;
GO

IF OBJECT_ID (N'sp_Empleado_Crear', N'P') IS NOT NULL
    PRINT 'sp_Empleado_Crear se creo con exito';
ELSE
    PRINT 'sp_Empleado_Crear no se creo el procedimiento';
GO 
