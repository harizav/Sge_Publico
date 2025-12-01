USE AMARIS
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
==================================================================================================================    
' Creación: Procedimiento para Actualizar en la tabla Empleados"  
' Fecha Creación: 14/11/2025                     
' Autor: Humberto R. Ariza V. - XXXXX  
' Proyecto: SGE  
' Solicitud: RRHH
==================================================================================================================    
*/   
IF OBJECT_ID (N'sp_Empleado_Actualizar', N'P') IS NOT NULL
    DROP PROCEDURE sp_Empleado_Actualizar;
GO 

CREATE PROCEDURE sp_Empleado_Actualizar
(
    @ID INT,
    @Nombre NVARCHAR(200),
    @Fecha DATE,
    @Cargo INTEGER,
    @Salario DECIMAL(18,2),
    @Departamento INTEGER
)
AS
BEGIN
    UPDATE Empleados
    SET NombreCompleto = @Nombre,
        FechaContratacion = @Fecha,
        Cargo = @Cargo,
        Salario = @Salario,
        Departamento = @Departamento
    WHERE ID = @ID;
END;
GO

IF OBJECT_ID (N'sp_Empleado_Actualizar', N'P') IS NOT NULL
    PRINT 'sp_Empleado_Actualizar se creo con exito';
ELSE
    PRINT 'sp_Empleado_Actualizar no se creo el procedimiento';
GO 