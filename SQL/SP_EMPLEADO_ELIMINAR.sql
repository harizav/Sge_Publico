USE AMARIS
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
==================================================================================================================    
' Creación: Procedimiento para Eliminar en la tabla Empleados"  
' Fecha Creación: 14/11/2025                     
' Autor: Humberto R. Ariza V. - XXXXX  
' Proyecto: SGE  
' Solicitud: RRHH
==================================================================================================================    
*/
IF OBJECT_ID (N'sp_Empleado_Eliminar', N'P') IS NOT NULL
    DROP PROCEDURE sp_Empleado_Eliminar;
GO 

CREATE PROCEDURE sp_Empleado_Eliminar
(
    @ID INT
)
AS
BEGIN
    DELETE FROM Empleados WHERE ID = @ID;
END;
GO

IF OBJECT_ID (N'sp_Empleado_Eliminar', N'P') IS NOT NULL
    PRINT 'sp_Empleado_Eliminar se creo con exito';
ELSE
    PRINT 'sp_Empleado_Eliminar no se creo el procedimiento';
GO 