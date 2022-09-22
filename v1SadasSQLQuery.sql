USE [master]
GO

/****** Object:  Database [v1Sadas]    Script Date: 21/9/2022 17:52:32 ******/
CREATE DATABASE [v1Sadas]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'v1Sadas', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\v1Sadas.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'v1Sadas_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\v1Sadas_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [v1Sadas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [v1Sadas] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [v1Sadas] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [v1Sadas] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [v1Sadas] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [v1Sadas] SET ARITHABORT OFF 
GO

ALTER DATABASE [v1Sadas] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [v1Sadas] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [v1Sadas] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [v1Sadas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [v1Sadas] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [v1Sadas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [v1Sadas] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [v1Sadas] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [v1Sadas] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [v1Sadas] SET  DISABLE_BROKER 
GO

ALTER DATABASE [v1Sadas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [v1Sadas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [v1Sadas] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [v1Sadas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [v1Sadas] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [v1Sadas] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [v1Sadas] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [v1Sadas] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [v1Sadas] SET  MULTI_USER 
GO

ALTER DATABASE [v1Sadas] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [v1Sadas] SET DB_CHAINING OFF 
GO

ALTER DATABASE [v1Sadas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [v1Sadas] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [v1Sadas] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [v1Sadas] SET QUERY_STORE = OFF
GO

ALTER DATABASE [v1Sadas] SET  READ_WRITE 
GO


USE [v1Sadas]
GO

/****** Object:  Table [dbo].[archivo]    Script Date: 21/9/2022 17:53:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[archivo](
	[id_archivo] [int] IDENTITY(1,1) NOT NULL,
	[ruta] [nvarchar](2000) NULL,
	[nombre] [nvarchar](1000) NULL,
	[tamanno] [nvarchar](1000) NULL,
 CONSTRAINT [PK_archivo] PRIMARY KEY CLUSTERED 
(
	[id_archivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [v1Sadas]
GO

/****** Object:  Table [dbo].[auditoria_solicitud]    Script Date: 21/9/2022 18:07:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[auditoria_solicitud](
	[id_auditoria_solicitud] [int] IDENTITY(1,1) NOT NULL,
	[modificado_por] [nvarchar](50) NULL,
	[razon_modificacion] [nvarchar](50) NULL,
	[fecha] [datetime] NULL,
 CONSTRAINT [PK_auditoria_solicitud] PRIMARY KEY CLUSTERED 
(
	[id_auditoria_solicitud] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [v1Sadas]
GO

/****** Object:  Table [dbo].[centro_educativo]    Script Date: 21/9/2022 18:08:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[centro_educativo](
	[id_centro_educativo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](250) NULL,
	[telefono1] [int] NULL,
	[telefono2] [int] NULL,
	[correo1] [varchar](320) NULL,
	[correo2] [varchar](320) NULL,
	[dependencia] [nvarchar](100) NULL,
	[region_educativa] [nvarchar](100) NULL,
	[provincia] [nvarchar](100) NULL,
	[canton] [nvarchar](100) NULL,
	[distrito] [nvarchar](100) NULL,
	[ubicacion_exacta] [nvarchar](250) NULL,
	[circuito] [nvarchar](100) NULL,
	[encargado] [nvarchar](100) NULL,
 CONSTRAINT [PK_centro_educativo] PRIMARY KEY CLUSTERED 
(
	[id_centro_educativo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [v1Sadas]
GO

/****** Object:  Table [dbo].[funcionario]    Script Date: 21/9/2022 18:09:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[funcionario](
	[id_funcionario] [int] IDENTITY(1,1) NOT NULL,
	[tipo_cedula] [nvarchar](100) NULL,
	[numero_cedula] [nvarchar](250) NULL,
	[nombre] [nvarchar](250) NULL,
	[apellido_1] [nvarchar](250) NULL,
	[apellido_2] [nvarchar](250) NULL,
	[telefono_1] [int] NULL,
	[telefono_2] [int] NULL,
	[usuario] [varchar](50) NULL,
	[contrasenna] [nvarchar](25) NULL,
	[sede_trabajo] [nvarchar](100) NULL,
 CONSTRAINT [PK_funcionario] PRIMARY KEY CLUSTERED 
(
	[id_funcionario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [v1Sadas]
GO

/****** Object:  Table [dbo].[funcionario_permiso]    Script Date: 21/9/2022 18:09:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[funcionario_permiso](
	[id_funcionario] [int] NULL,
	[id_permiso] [int] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[funcionario_permiso]  WITH CHECK ADD  CONSTRAINT [FK_funcionario_permiso_funcionario] FOREIGN KEY([id_funcionario])
REFERENCES [dbo].[funcionario] ([id_funcionario])
GO

ALTER TABLE [dbo].[funcionario_permiso] CHECK CONSTRAINT [FK_funcionario_permiso_funcionario]
GO

ALTER TABLE [dbo].[funcionario_permiso]  WITH CHECK ADD  CONSTRAINT [FK_funcionario_permiso_permiso] FOREIGN KEY([id_permiso])
REFERENCES [dbo].[permiso] ([id_permiso])
GO

ALTER TABLE [dbo].[funcionario_permiso] CHECK CONSTRAINT [FK_funcionario_permiso_permiso]
GO


USE [v1Sadas]
GO

/****** Object:  Table [dbo].[historial]    Script Date: 21/9/2022 18:10:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[historial](
	[id_historial] [int] IDENTITY(1,1) NOT NULL,
	[asesoria_previa] [int] NULL,
	[sede_asesoria_previa] [nvarchar](50) NULL,
	[adjunta_certificacion_medica_CCSS] [int] NULL,
	[adjunta_certificacion_medica_CONAPDIS] [int] NULL,
	[producto_apoyo_gubernamental] [int] NULL,
	[descripcion_producto_apoyo_gubernamental] [nvarchar](1000) NULL,
	[producto_apoyo_no_gubernamental] [int] NULL,
	[descripcion_producto_apoyo_no_gubernamental] [nvarchar](1000) NULL,
 CONSTRAINT [PK_Historial] PRIMARY KEY CLUSTERED 
(
	[id_historial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [v1Sadas]
GO

/****** Object:  Table [dbo].[historico]    Script Date: 21/9/2022 18:10:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[historico](
	[id_historico] [int] IDENTITY(1,1) NOT NULL,
	[id_historico_cenarec] [nvarchar](250) NULL,
	[nombre_estudiante] [nvarchar](250) NULL,
	[numero] [nvarchar](250) NULL,
	[fecha] [date] NULL,
	[telefono_contacot] [varchar](100) NULL,
	[centro_educativo] [nvarchar](250) NULL,
	[persona_funcionaria] [nvarchar](250) NULL,
	[producto_apoyo_solicitado] [nvarchar](4000) NULL,
	[descricpción_condición] [nvarchar](max) NULL,
 CONSTRAINT [PK_historico] PRIMARY KEY CLUSTERED 
(
	[id_historico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


USE [v1Sadas]
GO

/****** Object:  Table [dbo].[permiso]    Script Date: 21/9/2022 18:10:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[permiso](
	[id_permiso] [int] IDENTITY(1,1) NOT NULL,
	[nombe] [nvarchar](50) NULL,
	[detalle] [nvarchar](500) NULL,
 CONSTRAINT [PK_permiso] PRIMARY KEY CLUSTERED 
(
	[id_permiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [v1Sadas]
GO

/****** Object:  Table [dbo].[persona]    Script Date: 21/9/2022 18:11:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[persona](
	[id_persona] [int] IDENTITY(1,1) NOT NULL,
	[tipo_cedula] [nvarchar](100) NULL,
	[numero_cedula] [nvarchar](250) NULL,
	[tipo_persona] [nvarchar](100) NULL,
	[apellido_1] [nvarchar](250) NULL,
	[apellido_2] [nvarchar](250) NULL,
	[nombre] [nvarchar](250) NULL,
	[telefono_1] [int] NULL,
	[telefono_2] [int] NULL,
	[correo_1] [varchar](320) NULL,
	[correo_2] [varchar](320) NULL,
	[parenstesco_encargado] [nvarchar](250) NULL,
	[prioridad_encargado] [int] NULL,
	[fecha_nacimiento_estudiante] [date] NULL,
	[nivel_educativo_estudiante] [nvarchar](50) NULL,
	[provincia_estudiante] [nvarchar](50) NULL,
	[canton_estudiante] [nvarchar](50) NULL,
	[distrito_estudiante] [nvarchar](50) NULL,
	[ubicacion_exacta_estudiante] [nchar](10) NULL,
	[observaciones_estudiante] [nvarchar](4000) NULL,
	[relacion_solicitante] [nvarchar](50) NULL,
	[otro_anote_solicitante] [nvarchar](4000) NULL,
 CONSTRAINT [PK_persona] PRIMARY KEY CLUSTERED 
(
	[id_persona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [v1Sadas]
GO

/****** Object:  Table [dbo].[solicitud]    Script Date: 21/9/2022 18:11:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[solicitud](
	[id_solicitud] [int] IDENTITY(1,1) NOT NULL,
	[fecha_realiza] [datetime] NULL,
	[fecha_recibe] [datetime] NULL,
	[sede_recibe] [nvarchar](100) NULL,
	[nombre_persona_recibe] [nvarchar](200) NULL,
	[metodo_envio] [nvarchar](50) NULL,
	[motivo] [nvarchar](max) NULL,
	[apoyo_organizativo] [nvarchar](max) NULL,
	[producto_apoyo_organizativo] [nvarchar](max) NULL,
	[servicio_apoyo_empleados] [nvarchar](max) NULL,
	[servicio_apoyo_recibe] [nvarchar](max) NULL,
	[servicio_apoyo_recibe_region_educativa] [nvarchar](max) NULL,
	[apoyo_educativo_requerido] [nvarchar](max) NULL,
	[descripcion_condicion] [nvarchar](max) NULL,
	[id_centro_educativo] [int] NULL,
	[id_historial] [int] NULL,
 CONSTRAINT [PK_solicitudes] PRIMARY KEY CLUSTERED 
(
	[id_solicitud] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[solicitud]  WITH CHECK ADD  CONSTRAINT [FK_solicitudes_Historial] FOREIGN KEY([id_historial])
REFERENCES [dbo].[historial] ([id_historial])
GO

ALTER TABLE [dbo].[solicitud] CHECK CONSTRAINT [FK_solicitudes_Historial]
GO

ALTER TABLE [dbo].[solicitud]  WITH CHECK ADD  CONSTRAINT [FK_solicitudes_solicitudes] FOREIGN KEY([id_centro_educativo])
REFERENCES [dbo].[centro_educativo] ([id_centro_educativo])
GO

ALTER TABLE [dbo].[solicitud] CHECK CONSTRAINT [FK_solicitudes_solicitudes]
GO


USE [v1Sadas]
GO

/****** Object:  Table [dbo].[solicitud_archivo]    Script Date: 21/9/2022 18:11:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[solicitud_archivo](
	[id_solicitud] [int] NULL,
	[id_archivo] [int] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[solicitud_archivo]  WITH CHECK ADD  CONSTRAINT [FK_solicitud_archivo_archivo] FOREIGN KEY([id_archivo])
REFERENCES [dbo].[archivo] ([id_archivo])
GO

ALTER TABLE [dbo].[solicitud_archivo] CHECK CONSTRAINT [FK_solicitud_archivo_archivo]
GO

ALTER TABLE [dbo].[solicitud_archivo]  WITH CHECK ADD  CONSTRAINT [FK_solicitud_archivo_solicitud] FOREIGN KEY([id_solicitud])
REFERENCES [dbo].[solicitud] ([id_solicitud])
GO

ALTER TABLE [dbo].[solicitud_archivo] CHECK CONSTRAINT [FK_solicitud_archivo_solicitud]
GO


USE [v1Sadas]
GO

/****** Object:  Table [dbo].[solicitud_auditoria]    Script Date: 21/9/2022 18:12:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[solicitud_auditoria](
	[id_auditoria] [int] NULL,
	[id_solicitud] [int] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[solicitud_auditoria]  WITH CHECK ADD  CONSTRAINT [FK_solicitud_auditoria_auditoria_solicitud] FOREIGN KEY([id_auditoria])
REFERENCES [dbo].[auditoria_solicitud] ([id_auditoria_solicitud])
GO

ALTER TABLE [dbo].[solicitud_auditoria] CHECK CONSTRAINT [FK_solicitud_auditoria_auditoria_solicitud]
GO

ALTER TABLE [dbo].[solicitud_auditoria]  WITH CHECK ADD  CONSTRAINT [FK_solicitud_auditoria_solicitudes] FOREIGN KEY([id_solicitud])
REFERENCES [dbo].[solicitud] ([id_solicitud])
GO

ALTER TABLE [dbo].[solicitud_auditoria] CHECK CONSTRAINT [FK_solicitud_auditoria_solicitudes]
GO


USE [v1Sadas]
GO

/****** Object:  Table [dbo].[solicitud_funcionario]    Script Date: 21/9/2022 18:12:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[solicitud_funcionario](
	[id_funcionario] [int] NULL,
	[id_solicitud] [int] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[solicitud_funcionario]  WITH CHECK ADD  CONSTRAINT [FK_solicitud_funcionarios_funcionario] FOREIGN KEY([id_funcionario])
REFERENCES [dbo].[funcionario] ([id_funcionario])
GO

ALTER TABLE [dbo].[solicitud_funcionario] CHECK CONSTRAINT [FK_solicitud_funcionarios_funcionario]
GO

ALTER TABLE [dbo].[solicitud_funcionario]  WITH CHECK ADD  CONSTRAINT [FK_solicitud_funcionarios_solicitudes] FOREIGN KEY([id_solicitud])
REFERENCES [dbo].[solicitud] ([id_solicitud])
GO

ALTER TABLE [dbo].[solicitud_funcionario] CHECK CONSTRAINT [FK_solicitud_funcionarios_solicitudes]
GO


USE [v1Sadas]
GO

/****** Object:  Table [dbo].[solicitud_persona]    Script Date: 21/9/2022 18:12:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[solicitud_persona](
	[id_persona] [int] NULL,
	[id_solicitud] [int] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[solicitud_persona]  WITH CHECK ADD  CONSTRAINT [FK_solicitud_persona_persona] FOREIGN KEY([id_persona])
REFERENCES [dbo].[persona] ([id_persona])
GO

ALTER TABLE [dbo].[solicitud_persona] CHECK CONSTRAINT [FK_solicitud_persona_persona]
GO

ALTER TABLE [dbo].[solicitud_persona]  WITH CHECK ADD  CONSTRAINT [FK_solicitud_persona_solicitudes] FOREIGN KEY([id_solicitud])
REFERENCES [dbo].[solicitud] ([id_solicitud])
GO

ALTER TABLE [dbo].[solicitud_persona] CHECK CONSTRAINT [FK_solicitud_persona_solicitudes]
GO


