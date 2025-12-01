--USE AMARIS
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
==================================================================================================================    
' Creación: Consultar la tabla Cargos"  
' Fecha Creación: 14/11/2025                     
' Autor: Humberto R. Ariza V. - XXXXX  
' Proyecto: SGE  
' Solicitud: RRHH
==================================================================================================================    
*/   
IF OBJECT_ID (N'dbo.sp_Cargos_Listar', N'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_Cargos_Listar;
GO 

CREATE PROCEDURE dbo.sp_Cargos_Listar
AS
BEGIN 
    SELECT 
	   ca.ID,
       ca.NomCargo
    FROM dbo.Cargos ca 
	ORDER BY NomCargo
END
GO

IF OBJECT_ID (N'dbo.sp_Cargos_Listar', N'P') IS NOT NULL
    PRINT 'dbo.sp_Cargos_Listar se creo con exito';
ELSE
    PRINT 'dbo.sp_Cargos_Listar no se creo el procedimiento';
GO 
