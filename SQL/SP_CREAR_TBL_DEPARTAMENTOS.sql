USE AMARIS
/*
==================================================================================================================    
' Creación: Se crea la tabla Departamento"  
' Fecha Creación: 14/11/2025                     
' Autor: Humberto R. Ariza V. - XXXXX  
' Proyecto: SGE  
' Solicitud: RRHH
==================================================================================================================    
*/   
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Departamento]') AND type in (N'U'))
DROP TABLE [dbo].[Departamento]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE Departamento (
	ID INT PRIMARY KEY,
    NomDep NVARCHAR(200),
	fec_con DATETIME NOT NULL,
	login NVARCHAR (10) NOT NULL,
	obs NVARCHAR (200) NULL,
	estado NVARCHAR (1) NULL
);
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', 
                                @value=N'ID de la tabla', 
								@level0type=N'SCHEMA',
								@level0name=N'dbo', 
								@level1type=N'TABLE',
								@level1name=N'Departamento', 
								@level2type=N'COLUMN',
								@level2name=N'ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
                                @value=N'Nombre Departamento ', 
                                @level0type=N'SCHEMA',
								@level0name=N'dbo', 
								@level1type=N'TABLE',
								@level1name=N'Departamento', 
								@level2type=N'COLUMN',
								@level2name=N'NomDep'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', 
                                @value=N'Fecha de guardado', 
								@level0type=N'SCHEMA',
								@level0name=N'dbo', 
								@level1type=N'TABLE',
								@level1name=N'Departamento', 
								@level2type=N'COLUMN',
								@level2name=N'fec_con'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', 
                                @value=N'Usuario', 
								@level0type=N'SCHEMA',
								@level0name=N'dbo', 
								@level1type=N'TABLE',
								@level1name=N'Departamento', 
								@level2type=N'COLUMN',
								@level2name=N'login'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', 
                                @value=N'Observacion adicional' , 
								@level0type=N'SCHEMA',
								@level0name=N'dbo', 
								@level1type=N'TABLE',
								@level1name=N'Departamento', 
								@level2type=N'COLUMN',
								@level2name=N'obs'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', 
                                @value=N'Estado', 
								@level0type=N'SCHEMA',
								@level0name=N'dbo', 
								@level1type=N'TABLE',
								@level1name=N'Departamento', 
								@level2type=N'COLUMN',
								@level2name=N'estado'
GO

INSERT INTO [dbo].[Departamento] ([ID],[NomDep], [fec_con],[login], [obs],[estado] )
VALUES 
('1','SISTEMAS', GETDATE(),'HARIZA','',1),
('2','CONTABILIDAD', GETDATE(),'HARIZA','',1),
('3','SERVICIOS VARIOS', GETDATE(),'HARIZA','',1)
GO