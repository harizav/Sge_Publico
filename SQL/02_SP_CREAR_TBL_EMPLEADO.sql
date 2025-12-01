--USE AMARIS
/*
==================================================================================================================    
' Creación: Se crea la tabla Empleados"  
' Fecha Creación: 14/11/2025                     
' Autor: Humberto R. Ariza V. - XXXXX  
' Proyecto: SGE  
' Solicitud: RRHH
==================================================================================================================    
*/   
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Empleados]') AND type in (N'U'))
DROP TABLE [dbo].[Empleados]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE Empleados (
	ID INT PRIMARY KEY,
    NombreCompleto NVARCHAR(200),
    FechaContratacion DATE,
    Cargo INTEGER,
    Salario DECIMAL(18,2),
    Departamento INTEGER,
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
								@level1name=N'Empleados', 
								@level2type=N'COLUMN',
								@level2name=N'ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
                                @value=N'Nombre Completo ', 
                                @level0type=N'SCHEMA',
								@level0name=N'dbo', 
								@level1type=N'TABLE',
								@level1name=N'Empleados', 
								@level2type=N'COLUMN',
								@level2name=N'NombreCompleto'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', 
                                @value=N'Fecha Contratacion', 
								@level0type=N'SCHEMA',
								@level0name=N'dbo', 
								@level1type=N'TABLE',
								@level1name=N'Empleados', 
								@level2type=N'COLUMN',
								@level2name=N'FechaContratacion'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', 
                                @value=N'Cargo',
								@level0type=N'SCHEMA',
								@level0name=N'dbo', 
								@level1type=N'TABLE',
								@level1name=N'Empleados', 
								@level2type=N'COLUMN',
								@level2name=N'Cargo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', 
                                @value=N'Salario' , 
								@level0type=N'SCHEMA',
								@level0name=N'dbo', 
								@level1type=N'TABLE',
								@level1name=N'Empleados', 
								@level2type=N'COLUMN',
								@level2name=N'Salario'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', 
                                @value=N'Departamento' , 
								@level0type=N'SCHEMA',
								@level0name=N'dbo', 
								@level1type=N'TABLE',
								@level1name=N'Empleados', 
								@level2type=N'COLUMN',
								@level2name=N'Departamento'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', 
                                @value=N'Fecha de guardado', 
								@level0type=N'SCHEMA',
								@level0name=N'dbo', 
								@level1type=N'TABLE',
								@level1name=N'Empleados', 
								@level2type=N'COLUMN',
								@level2name=N'fec_con'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', 
                                @value=N'Usuario', 
								@level0type=N'SCHEMA',
								@level0name=N'dbo', 
								@level1type=N'TABLE',
								@level1name=N'Empleados', 
								@level2type=N'COLUMN',
								@level2name=N'login'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', 
                                @value=N'Observacion adicional' , 
								@level0type=N'SCHEMA',
								@level0name=N'dbo', 
								@level1type=N'TABLE',
								@level1name=N'Empleados', 
								@level2type=N'COLUMN',
								@level2name=N'obs'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', 
                                @value=N'Estado', 
								@level0type=N'SCHEMA',
								@level0name=N'dbo', 
								@level1type=N'TABLE',
								@level1name=N'Empleados', 
								@level2type=N'COLUMN',
								@level2name=N'estado'
GO

INSERT INTO [dbo].[Empleados] ([ID],[NombreCompleto], [FechaContratacion], [Cargo], [Salario], [Departamento], [fec_con],[login], [obs],[estado] )
VALUES 
('8531918','HUMBERTO R. ARIZA V.',  GETDATE(), 1,1200000,1, GETDATE(),'HARIZA','',1),
('8531919','CARLOS L. RESTREPO H.',  GETDATE(), 2,1400000,2, GETDATE(),'HARIZA','',0),
('8531920','JOSE M. CAMARGO O.',  GETDATE(), 3,1500000,3, GETDATE(),'HARIZA','',1)
GO
