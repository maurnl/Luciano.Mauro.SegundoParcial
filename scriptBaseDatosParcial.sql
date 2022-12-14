USE [master]
GO
/****** Object:  Database [Parcial_Db]    Script Date: 12/11/2022 11:43:57 ******/
CREATE DATABASE [Parcial_Db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Parcial_Db', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Parcial_Db.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Parcial_Db_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Parcial_Db_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Parcial_Db] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Parcial_Db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Parcial_Db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Parcial_Db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Parcial_Db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Parcial_Db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Parcial_Db] SET ARITHABORT OFF 
GO
ALTER DATABASE [Parcial_Db] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Parcial_Db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Parcial_Db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Parcial_Db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Parcial_Db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Parcial_Db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Parcial_Db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Parcial_Db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Parcial_Db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Parcial_Db] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Parcial_Db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Parcial_Db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Parcial_Db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Parcial_Db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Parcial_Db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Parcial_Db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Parcial_Db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Parcial_Db] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Parcial_Db] SET  MULTI_USER 
GO
ALTER DATABASE [Parcial_Db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Parcial_Db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Parcial_Db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Parcial_Db] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Parcial_Db] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Parcial_Db] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Parcial_Db] SET QUERY_STORE = OFF
GO
USE [Parcial_Db]
GO
/****** Object:  Table [dbo].[HistorialPartidas]    Script Date: 12/11/2022 11:43:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistorialPartidas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idPartida] [int] NOT NULL,
	[idJugadorGanador] [int] NOT NULL,
	[idJugadorPerdedor] [int] NOT NULL,
	[rondaJugadas] [int] NOT NULL,
	[juego] [varchar](50) NOT NULL,
 CONSTRAINT [PK_HistorialPartidas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jugadores]    Script Date: 12/11/2022 11:43:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jugadores](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[esHumano] [bit] NOT NULL,
	[trucoGanadas] [int] NOT NULL,
	[trucoPerdidas] [int] NOT NULL,
	[piedrapapeltijeraGanadas] [int] NOT NULL,
	[piedrapapeltijeraPerdidas] [int] NOT NULL,
 CONSTRAINT [PK_Jugadores] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[HistorialPartidas] ON 

INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (1, 0, 1, 3, 15, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (2, 0, 6, 6, 3, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (3, 0, 1, 1, 3, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (4, 0, 4, 4, 6, N'PiedraPapelTijera')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (5, 1, 4, 4, 6, N'PiedraPapelTijera')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (6, 0, 6, 6, 9, N'PiedraPapelTijera')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (7, 1, 5, 5, 3, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (8, 0, 3, 3, 8, N'PiedraPapelTijera')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (9, 0, 5, 5, 0, N'PiedraPapelTijera')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (10, 0, 6, 6, 1, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (11, 1, 4, 4, 0, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (12, 2, 4, 4, 1, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (13, 0, 4, 4, 3, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (14, 0, 6, 6, 3, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (15, 1, 4, 4, 3, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (16, 2, 4, 4, 3, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (17, 20, 6, 6, 0, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (18, 21, 3, 3, 0, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (19, 22, 5, 5, 0, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (20, 23, 5, 5, 0, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (21, 24, 5, 5, 0, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (22, 25, 4, 4, 0, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (23, 26, 5, 5, 0, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (24, 27, 6, 6, 0, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (25, 28, 5, 5, 0, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (26, 29, 3, 3, 0, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (27, 30, 4, 4, 0, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (28, 31, 6, 6, 0, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (29, 32, 4, 4, 0, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (30, 33, 4, 4, 0, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (31, 34, 5, 5, 0, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (32, 35, 5, 5, 0, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (33, 36, 4, 4, 0, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (34, 37, 5, 5, 0, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (35, 38, 6, 6, 0, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (36, 14, 5, 5, 3, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (37, 11, 4, 4, 2, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (38, 12, 5, 5, 1, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (39, 13, 3, 3, 0, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (40, 3, 4, 4, 3, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (41, 0, 6, 6, 2, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (42, 10, 5, 5, 1, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (43, 39, 4, 4, 0, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (44, 7, 4, 4, 1, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (45, 41, 6, 6, 0, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (46, 42, 5, 5, 0, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (47, 43, 4, 4, 0, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (48, 44, 6, 6, 0, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (49, 45, 4, 4, 0, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (50, 46, 6, 6, 0, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (51, 47, 5, 5, 0, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (52, 40, 5, 5, 0, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (53, 49, 3, 3, 0, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (54, 48, 3, 3, 0, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (55, 6, 5, 5, 3, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (56, 5, 6, 6, 1, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (57, 2, 4, 4, 0, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (58, 9, 3, 3, 3, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (59, 15, 4, 4, 3, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (60, 1, 3, 3, 2, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (61, 19, 5, 5, 1, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (62, 4, 5, 5, 2, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (63, 8, 6, 6, 3, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (64, 17, 5, 5, 1, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (65, 18, 3, 3, 1, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (66, 16, 3, 3, 2, N'Truco')
INSERT [dbo].[HistorialPartidas] ([id], [idPartida], [idJugadorGanador], [idJugadorPerdedor], [rondaJugadas], [juego]) VALUES (67, 51, 6, 6, 2, N'Truco')
SET IDENTITY_INSERT [dbo].[HistorialPartidas] OFF
GO
SET IDENTITY_INSERT [dbo].[Jugadores] ON 

INSERT [dbo].[Jugadores] ([id], [nombre], [apellido], [esHumano], [trucoGanadas], [trucoPerdidas], [piedrapapeltijeraGanadas], [piedrapapeltijeraPerdidas]) VALUES (1, N'Mauro', N'Luciano', 1, 0, 0, 0, 0)
INSERT [dbo].[Jugadores] ([id], [nombre], [apellido], [esHumano], [trucoGanadas], [trucoPerdidas], [piedrapapeltijeraGanadas], [piedrapapeltijeraPerdidas]) VALUES (3, N'Maximiliano', N'Neiner', 0, 0, 0, 0, 0)
INSERT [dbo].[Jugadores] ([id], [nombre], [apellido], [esHumano], [trucoGanadas], [trucoPerdidas], [piedrapapeltijeraGanadas], [piedrapapeltijeraPerdidas]) VALUES (4, N'Facundo', N'Rocha', 0, 0, 0, 0, 0)
INSERT [dbo].[Jugadores] ([id], [nombre], [apellido], [esHumano], [trucoGanadas], [trucoPerdidas], [piedrapapeltijeraGanadas], [piedrapapeltijeraPerdidas]) VALUES (5, N'Milagros', N'Luna', 0, 0, 0, 0, 0)
INSERT [dbo].[Jugadores] ([id], [nombre], [apellido], [esHumano], [trucoGanadas], [trucoPerdidas], [piedrapapeltijeraGanadas], [piedrapapeltijeraPerdidas]) VALUES (6, N'Pablo', N'Vidal', 0, 0, 0, 0, 0)
SET IDENTITY_INSERT [dbo].[Jugadores] OFF
GO
USE [master]
GO
ALTER DATABASE [Parcial_Db] SET  READ_WRITE 
GO
