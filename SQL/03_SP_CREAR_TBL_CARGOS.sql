--USE AMARIS
/*
==================================================================================================================    
' Creación: Se crea la tabla Cargos"  
' Fecha Creación: 14/11/2025                     
' Autor: Humberto R. Ariza V. - XXXXX  
' Proyecto: SGE  
' Solicitud: RRHH
==================================================================================================================    
*/   
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cargos]') AND type in (N'U'))
DROP TABLE [dbo].[Cargos]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE Cargos (
	ID INT PRIMARY KEY,
    NomCargo NVARCHAR(200),
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
								@level1name=N'Cargos', 
								@level2type=N'COLUMN',
								@level2name=N'ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description',
                                @value=N'Nombre Cargo ', 
                                @level0type=N'SCHEMA',
								@level0name=N'dbo', 
								@level1type=N'TABLE',
								@level1name=N'Cargos', 
								@level2type=N'COLUMN',
								@level2name=N'NomCargo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', 
                                @value=N'Fecha de guardado', 
								@level0type=N'SCHEMA',
								@level0name=N'dbo', 
								@level1type=N'TABLE',
								@level1name=N'Cargos', 
								@level2type=N'COLUMN',
								@level2name=N'fec_con'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', 
                                @value=N'Usuario', 
								@level0type=N'SCHEMA',
								@level0name=N'dbo', 
								@level1type=N'TABLE',
								@level1name=N'Cargos', 
								@level2type=N'COLUMN',
								@level2name=N'login'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', 
                                @value=N'Observacion adicional' , 
								@level0type=N'SCHEMA',
								@level0name=N'dbo', 
								@level1type=N'TABLE',
								@level1name=N'Cargos', 
								@level2type=N'COLUMN',
								@level2name=N'obs'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', 
                                @value=N'Estado', 
								@level0type=N'SCHEMA',
								@level0name=N'dbo', 
								@level1type=N'TABLE',
								@level1name=N'Cargos', 
								@level2type=N'COLUMN',
								@level2name=N'estado'
GO

INSERT INTO [dbo].[Cargos] ([ID],[NomCargo], [fec_con],[login], [obs],[estado] )
VALUES 
('1','SOPORTE DE SOFTWARE', GETDATE(),'HARIZA','',1),
('2','ANALISTA', GETDATE(),'HARIZA','',1),
('3','QA', GETDATE(),'HARIZA','',1)
GO
