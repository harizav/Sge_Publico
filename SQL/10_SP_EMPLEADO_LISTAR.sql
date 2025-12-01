--USE AMARIS
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
==================================================================================================================    
' Creación: Consultar la tabla Empleados"  
' Fecha Creación: 14/11/2025                     
' Autor: Humberto R. Ariza V. - XXXXX  
' Proyecto: SGE  
' Solicitud: RRHH
==================================================================================================================    
*/   
IF OBJECT_ID (N'dbo.sp_Empleado_Listar', N'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_Empleado_Listar;
GO 

CREATE PROCEDURE dbo.sp_Empleado_Listar
AS
BEGIN 
    SELECT 
	   em.ID AS id,
       em.NombreCompleto,
       em.FechaContratacion,
       ca.NomCargo AS Cargo,
       em.Salario,
       dp.NomDep AS Departamento,
	   em.fec_con,
	   em.login,
	   COALESCE(em.obs,'') AS obs,
	   (CASE 
            WHEN em.estado = 0 THEN 'Inactivo'
            WHEN em.estado = 1 THEN 'Activo'
          ELSE 'Desconocido'
        END) AS estado,
		ca.id AS CodCar,
		dp.id AS CodDep
    FROM dbo.Empleados em 
	INNER JOIN dbo.Cargos ca ON em.cargo = ca.id
	INNER JOIN dbo.Departamento dp ON em.departamento = dp.id 
	ORDER BY NombreCompleto;
END
GO

IF OBJECT_ID (N'dbo.sp_Empleado_Listar', N'P') IS NOT NULL
    PRINT 'dbo.sp_Empleado_Listar se creo con exito';
ELSE
    PRINT 'dbo.sp_Empleado_Listar no se creo el procedimiento';
GO 
