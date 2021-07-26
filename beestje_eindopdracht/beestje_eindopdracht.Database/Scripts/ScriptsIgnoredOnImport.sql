
USE [master]
GO

/****** Object:  Database [beestje_database]    Script Date: 21-12-2019 17:10:08 ******/
CREATE DATABASE [beestje_database]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'beestje_database', FILENAME = N'C:\Users\RivaldoPC\beestje_database.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'beestje_database_log', FILENAME = N'C:\Users\RivaldoPC\beestje_database_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

ALTER DATABASE [beestje_database] SET COMPATIBILITY_LEVEL = 110
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [beestje_database].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [beestje_database] SET ANSI_NULL_DEFAULT OFF
GO

ALTER DATABASE [beestje_database] SET ANSI_NULLS OFF
GO

ALTER DATABASE [beestje_database] SET ANSI_PADDING OFF
GO

ALTER DATABASE [beestje_database] SET ANSI_WARNINGS OFF
GO

ALTER DATABASE [beestje_database] SET ARITHABORT OFF
GO

ALTER DATABASE [beestje_database] SET AUTO_CLOSE OFF
GO

ALTER DATABASE [beestje_database] SET AUTO_SHRINK OFF
GO

ALTER DATABASE [beestje_database] SET AUTO_UPDATE_STATISTICS ON
GO

ALTER DATABASE [beestje_database] SET CURSOR_CLOSE_ON_COMMIT OFF
GO

ALTER DATABASE [beestje_database] SET CURSOR_DEFAULT  GLOBAL
GO

ALTER DATABASE [beestje_database] SET CONCAT_NULL_YIELDS_NULL OFF
GO

ALTER DATABASE [beestje_database] SET NUMERIC_ROUNDABORT OFF
GO

ALTER DATABASE [beestje_database] SET QUOTED_IDENTIFIER OFF
GO

ALTER DATABASE [beestje_database] SET RECURSIVE_TRIGGERS OFF
GO

ALTER DATABASE [beestje_database] SET  DISABLE_BROKER
GO

ALTER DATABASE [beestje_database] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO

ALTER DATABASE [beestje_database] SET DATE_CORRELATION_OPTIMIZATION OFF
GO

ALTER DATABASE [beestje_database] SET TRUSTWORTHY OFF
GO

ALTER DATABASE [beestje_database] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO

ALTER DATABASE [beestje_database] SET PARAMETERIZATION SIMPLE
GO

ALTER DATABASE [beestje_database] SET READ_COMMITTED_SNAPSHOT OFF
GO

ALTER DATABASE [beestje_database] SET HONOR_BROKER_PRIORITY OFF
GO

ALTER DATABASE [beestje_database] SET RECOVERY SIMPLE
GO

ALTER DATABASE [beestje_database] SET  MULTI_USER
GO

ALTER DATABASE [beestje_database] SET PAGE_VERIFY CHECKSUM
GO

ALTER DATABASE [beestje_database] SET DB_CHAINING OFF
GO

ALTER DATABASE [beestje_database] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF )
GO

ALTER DATABASE [beestje_database] SET TARGET_RECOVERY_TIME = 60 SECONDS
GO

USE [beestje_database]
GO

/****** Object:  Table [dbo].[Accessoires]    Script Date: 21-12-2019 17:10:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[Beestjes]    Script Date: 21-12-2019 17:10:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[BeestType]    Script Date: 21-12-2019 17:10:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[Boeking]    Script Date: 21-12-2019 17:10:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

INSERT [dbo].[Accessoires] ([Id], [Naam], [Prijs], [Afbeelding], [Beestje_id]) VALUES (1, N'Ketting', 50.0000, N'/ketting.jpg', 1)
GO

INSERT [dbo].[Accessoires] ([Id], [Naam], [Prijs], [Afbeelding], [Beestje_id]) VALUES (2, N'Armband', 30.0000, N'/armband.jpg', 2)
GO

INSERT [dbo].[Accessoires] ([Id], [Naam], [Prijs], [Afbeelding], [Beestje_id]) VALUES (3, N'Oorbellen', 70.0000, N'/oorbellen.jpg', 3)
GO

INSERT [dbo].[Beestjes] ([Id], [Boeking_id], [BeestType_id], [Naam], [Prijs], [Afbeelding]) VALUES (1, 1, 1, N'Aap', N'50', N'aap.jpg')
GO

INSERT [dbo].[Beestjes] ([Id], [Boeking_id], [BeestType_id], [Naam], [Prijs], [Afbeelding]) VALUES (2, 2, 2, N'Olifant', N'30', N'olifant.jpg')
GO

INSERT [dbo].[Beestjes] ([Id], [Boeking_id], [BeestType_id], [Naam], [Prijs], [Afbeelding]) VALUES (3, 2, 3, N'Zebra', N'20', N'zebra.jpg')
GO

INSERT [dbo].[BeestType] ([id], [Type]) VALUES (1, N'Jungle')
GO

INSERT [dbo].[BeestType] ([id], [Type]) VALUES (2, N'Boerderij')
GO

INSERT [dbo].[BeestType] ([id], [Type]) VALUES (3, N'Sneeuw')
GO

INSERT [dbo].[BeestType] ([id], [Type]) VALUES (4, N'Woestijn')
GO

INSERT [dbo].[Boeking] ([Id], [datum], [contact_naam], [contact_adres], [contact_email], [contact_telefoonnummer]) VALUES (1, CAST(N'2008-11-11' AS Date), N'Jan', N'Straat', N'email@email.com', N'0612121212')
GO

INSERT [dbo].[Boeking] ([Id], [datum], [contact_naam], [contact_adres], [contact_email], [contact_telefoonnummer]) VALUES (2, CAST(N'2009-11-11' AS Date), N'Bob', N'Laan', N'mail@mail.com', N'0638383838')
GO

USE [master]
GO

ALTER DATABASE [beestje_database] SET  READ_WRITE
GO

USE [master]
GO

/****** Object:  Database [beestje_database]    Script Date: 24-12-2019 12:55:56 ******/
CREATE DATABASE [beestje_database]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'beestje_database', FILENAME = N'C:\Users\RivaldoPC\beestje_database.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'beestje_database_log', FILENAME = N'C:\Users\RivaldoPC\beestje_database_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

ALTER DATABASE [beestje_database] SET COMPATIBILITY_LEVEL = 110
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [beestje_database].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [beestje_database] SET ANSI_NULL_DEFAULT OFF
GO

ALTER DATABASE [beestje_database] SET ANSI_NULLS OFF
GO

ALTER DATABASE [beestje_database] SET ANSI_PADDING OFF
GO

ALTER DATABASE [beestje_database] SET ANSI_WARNINGS OFF
GO

ALTER DATABASE [beestje_database] SET ARITHABORT OFF
GO

ALTER DATABASE [beestje_database] SET AUTO_CLOSE OFF
GO

ALTER DATABASE [beestje_database] SET AUTO_SHRINK OFF
GO

ALTER DATABASE [beestje_database] SET AUTO_UPDATE_STATISTICS ON
GO

ALTER DATABASE [beestje_database] SET CURSOR_CLOSE_ON_COMMIT OFF
GO

ALTER DATABASE [beestje_database] SET CURSOR_DEFAULT  GLOBAL
GO

ALTER DATABASE [beestje_database] SET CONCAT_NULL_YIELDS_NULL OFF
GO

ALTER DATABASE [beestje_database] SET NUMERIC_ROUNDABORT OFF
GO

ALTER DATABASE [beestje_database] SET QUOTED_IDENTIFIER OFF
GO

ALTER DATABASE [beestje_database] SET RECURSIVE_TRIGGERS OFF
GO

ALTER DATABASE [beestje_database] SET  DISABLE_BROKER
GO

ALTER DATABASE [beestje_database] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO

ALTER DATABASE [beestje_database] SET DATE_CORRELATION_OPTIMIZATION OFF
GO

ALTER DATABASE [beestje_database] SET TRUSTWORTHY OFF
GO

ALTER DATABASE [beestje_database] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO

ALTER DATABASE [beestje_database] SET PARAMETERIZATION SIMPLE
GO

ALTER DATABASE [beestje_database] SET READ_COMMITTED_SNAPSHOT OFF
GO

ALTER DATABASE [beestje_database] SET HONOR_BROKER_PRIORITY OFF
GO

ALTER DATABASE [beestje_database] SET RECOVERY SIMPLE
GO

ALTER DATABASE [beestje_database] SET  MULTI_USER
GO

ALTER DATABASE [beestje_database] SET PAGE_VERIFY CHECKSUM
GO

ALTER DATABASE [beestje_database] SET DB_CHAINING OFF
GO

ALTER DATABASE [beestje_database] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF )
GO

ALTER DATABASE [beestje_database] SET TARGET_RECOVERY_TIME = 60 SECONDS
GO

USE [beestje_database]
GO

/****** Object:  Table [dbo].[Accessoires]    Script Date: 24-12-2019 12:55:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[Beestjes]    Script Date: 24-12-2019 12:55:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[BeestType]    Script Date: 24-12-2019 12:55:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[Boeking]    Script Date: 24-12-2019 12:55:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET IDENTITY_INSERT [dbo].[Accessoires] ON
GO

INSERT [dbo].[Accessoires] ([Id], [Naam], [Prijs], [Afbeelding], [Beestje_id]) VALUES (1, N'Ketting', 50.0000, N'Content/Images/Accessoires/ketting.png', 1)
GO

INSERT [dbo].[Accessoires] ([Id], [Naam], [Prijs], [Afbeelding], [Beestje_id]) VALUES (2, N'Armband', 30.0000, N'Content/Images/Accessoires/bracelet.png', 2)
GO

INSERT [dbo].[Accessoires] ([Id], [Naam], [Prijs], [Afbeelding], [Beestje_id]) VALUES (3, N'Oorbellen', 70.0000, N'Content/Images/Accessoires/earrings.png', 3)
GO

SET IDENTITY_INSERT [dbo].[Accessoires] OFF
GO

SET IDENTITY_INSERT [dbo].[Beestjes] ON
GO

INSERT [dbo].[Beestjes] ([Id], [Boeking_id], [BeestType_id], [Naam], [Prijs], [Afbeelding]) VALUES (1, 1, 1, N'Aap', N'50', N'Content/Images/Beestjes/aap.png')
GO

INSERT [dbo].[Beestjes] ([Id], [Boeking_id], [BeestType_id], [Naam], [Prijs], [Afbeelding]) VALUES (2, 2, 2, N'Olifant', N'30', N'Content/Images/Beestjes/olifant.png')
GO

INSERT [dbo].[Beestjes] ([Id], [Boeking_id], [BeestType_id], [Naam], [Prijs], [Afbeelding]) VALUES (3, 2, 3, N'Zebra', N'20', N'Content/Images/Beestjes/zebra.png')
GO

SET IDENTITY_INSERT [dbo].[Beestjes] OFF
GO

SET IDENTITY_INSERT [dbo].[BeestType] ON
GO

INSERT [dbo].[BeestType] ([id], [Type]) VALUES (1, N'Jungle')
GO

INSERT [dbo].[BeestType] ([id], [Type]) VALUES (2, N'Boerderij')
GO

INSERT [dbo].[BeestType] ([id], [Type]) VALUES (3, N'Sneeuw')
GO

INSERT [dbo].[BeestType] ([id], [Type]) VALUES (4, N'Woestijn')
GO

SET IDENTITY_INSERT [dbo].[BeestType] OFF
GO

SET IDENTITY_INSERT [dbo].[Boeking] ON
GO

INSERT [dbo].[Boeking] ([Id], [datum], [contact_naam], [contact_adres], [contact_email], [contact_telefoonnummer]) VALUES (1, CAST(N'2008-11-11' AS Date), N'Jan', N'Straat', N'email@email.com', N'0612121212')
GO

INSERT [dbo].[Boeking] ([Id], [datum], [contact_naam], [contact_adres], [contact_email], [contact_telefoonnummer]) VALUES (2, CAST(N'2009-11-11' AS Date), N'Bob', N'Laan', N'mail@mail.com', N'0638383838')
GO

SET IDENTITY_INSERT [dbo].[Boeking] OFF
GO

USE [master]
GO

ALTER DATABASE [beestje_database] SET  READ_WRITE
GO
