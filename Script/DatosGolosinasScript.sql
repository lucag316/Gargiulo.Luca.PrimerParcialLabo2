USE [master]
GO
/****** Object:  Database [Kiosco]    Script Date: 2/7/2024 22:22:42 ******/
CREATE DATABASE [Kiosco]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Kiosco', FILENAME = N'C:\SQLData\Kiosco.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Kiosco_log', FILENAME = N'C:\SQLData\Kiosco_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Kiosco] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Kiosco].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Kiosco] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Kiosco] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Kiosco] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Kiosco] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Kiosco] SET ARITHABORT OFF 
GO
ALTER DATABASE [Kiosco] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Kiosco] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Kiosco] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Kiosco] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Kiosco] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Kiosco] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Kiosco] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Kiosco] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Kiosco] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Kiosco] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Kiosco] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Kiosco] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Kiosco] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Kiosco] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Kiosco] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Kiosco] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Kiosco] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Kiosco] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Kiosco] SET  MULTI_USER 
GO
ALTER DATABASE [Kiosco] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Kiosco] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Kiosco] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Kiosco] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Kiosco] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Kiosco] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Kiosco] SET QUERY_STORE = ON
GO
ALTER DATABASE [Kiosco] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Kiosco]
GO
/****** Object:  Table [dbo].[DatosGolosinas]    Script Date: 2/7/2024 22:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DatosGolosinas](
	[tipoDeGolosina] [nvarchar](50) NULL,
	[codigo] [int] NOT NULL,
	[precio] [float] NOT NULL,
	[peso] [float] NOT NULL,
	[cantidad] [int] NOT NULL,
	[tipoDeCacao] [nvarchar](50) NULL,
	[relleno] [nvarchar](50) NULL,
	[esVegano] [bit] NULL,
	[elasticidad] [nvarchar](50) NULL,
	[duracionSabor] [nvarchar](50) NULL,
	[blanqueadorDental] [bit] NULL,
	[formaChupetin] [nvarchar](50) NULL,
	[dureza] [nvarchar](50) NULL,
	[envolturaTransparente] [bit] NULL
) ON [PRIMARY]
GO
INSERT [dbo].[DatosGolosinas] ([tipoDeGolosina], [codigo], [precio], [peso], [cantidad], [tipoDeCacao], [relleno], [esVegano], [elasticidad], [duracionSabor], [blanqueadorDental], [formaChupetin], [dureza], [envolturaTransparente]) VALUES (N'Chocolate', 1, 10, 10, 10, N'Almendra', N'ConLeche', 0, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[DatosGolosinas] ([tipoDeGolosina], [codigo], [precio], [peso], [cantidad], [tipoDeCacao], [relleno], [esVegano], [elasticidad], [duracionSabor], [blanqueadorDental], [formaChupetin], [dureza], [envolturaTransparente]) VALUES (N'Chocolate', 2, 20, 4, 1, N'Caramelo', N'Blanco', 1, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[DatosGolosinas] ([tipoDeGolosina], [codigo], [precio], [peso], [cantidad], [tipoDeCacao], [relleno], [esVegano], [elasticidad], [duracionSabor], [blanqueadorDental], [formaChupetin], [dureza], [envolturaTransparente]) VALUES (N'Chocolate', 4, 10, 20, 200, N'Nuez', N'Negro', 0, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[DatosGolosinas] ([tipoDeGolosina], [codigo], [precio], [peso], [cantidad], [tipoDeCacao], [relleno], [esVegano], [elasticidad], [duracionSabor], [blanqueadorDental], [formaChupetin], [dureza], [envolturaTransparente]) VALUES (N'Chupetin', 5, 20, 7, 8, NULL, NULL, NULL, NULL, NULL, NULL, N'PicoDulce', N'Poca', 1)
INSERT [dbo].[DatosGolosinas] ([tipoDeGolosina], [codigo], [precio], [peso], [cantidad], [tipoDeCacao], [relleno], [esVegano], [elasticidad], [duracionSabor], [blanqueadorDental], [formaChupetin], [dureza], [envolturaTransparente]) VALUES (N'Chicle', 6, 10, 2000, 20, NULL, NULL, NULL, N'Poca', N'NoTiene', 1, NULL, NULL, NULL)
INSERT [dbo].[DatosGolosinas] ([tipoDeGolosina], [codigo], [precio], [peso], [cantidad], [tipoDeCacao], [relleno], [esVegano], [elasticidad], [duracionSabor], [blanqueadorDental], [formaChupetin], [dureza], [envolturaTransparente]) VALUES (N'Chocolate', 7, 100, 10, 10, N'Nutela', N'Blanco', 1, NULL, NULL, NULL, NULL, NULL, NULL)
GO
USE [master]
GO
ALTER DATABASE [Kiosco] SET  READ_WRITE 
GO
