--USE AMARIS
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
==================================================================================================================    
' Creación: Consultar la tabla Departamentos"  
' Fecha Creación: 14/11/2025                     
' Autor: Humberto R. Ariza V. - XXXXX  
' Proyecto: SGE  
' Solicitud: RRHH
==================================================================================================================    
*/   
IF OBJECT_ID (N'dbo.sp_Departamentos_Listar', N'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_Departamentos_Listar;
GO 

CREATE PROCEDURE dbo.sp_Departamentos_Listar
AS
BEGIN 
    SELECT 
	   dp.ID,
       dp.NomDep
    FROM dbo.Departamento dp 
	ORDER BY NomDep
END
GO

IF OBJECT_ID (N'dbo.sp_Departamentos_Listar', N'P') IS NOT NULL
    PRINT 'dbo.sp_Departamentos_Listar se creo con exito';
ELSE
    PRINT 'dbo.sp_Departamentos_Listar no se creo el procedimiento';
GO 
