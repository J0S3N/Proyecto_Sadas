USE [v1Sadas]

GO

ALTER TABLE dbo.Funcionario
ADD correo_1 varchar(320) NULL;

GO

ALTER TABLE dbo.Funcionario
ADD correo_2 varchar(320) NULL;

GO


Select * FROM dbo.funcionario