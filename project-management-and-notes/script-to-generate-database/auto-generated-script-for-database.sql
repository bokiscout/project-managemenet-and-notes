USE [master]
GO
/****** Object:  Database [ProjerctManagementAndNotesDB]    Script Date: 29.6.2016 23:22:11 ******/
CREATE DATABASE [ProjerctManagementAndNotesDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjerctManagementAndNotesDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ProjerctManagementAndNotesDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ProjerctManagementAndNotesDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ProjerctManagementAndNotesDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ProjerctManagementAndNotesDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjerctManagementAndNotesDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProjerctManagementAndNotesDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProjerctManagementAndNotesDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProjerctManagementAndNotesDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProjerctManagementAndNotesDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProjerctManagementAndNotesDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProjerctManagementAndNotesDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProjerctManagementAndNotesDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ProjerctManagementAndNotesDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProjerctManagementAndNotesDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProjerctManagementAndNotesDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProjerctManagementAndNotesDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProjerctManagementAndNotesDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProjerctManagementAndNotesDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProjerctManagementAndNotesDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProjerctManagementAndNotesDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProjerctManagementAndNotesDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProjerctManagementAndNotesDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProjerctManagementAndNotesDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProjerctManagementAndNotesDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProjerctManagementAndNotesDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProjerctManagementAndNotesDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProjerctManagementAndNotesDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProjerctManagementAndNotesDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProjerctManagementAndNotesDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProjerctManagementAndNotesDB] SET  MULTI_USER 
GO
ALTER DATABASE [ProjerctManagementAndNotesDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProjerctManagementAndNotesDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProjerctManagementAndNotesDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProjerctManagementAndNotesDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [ProjerctManagementAndNotesDB]
GO
/****** Object:  Table [dbo].[Assignments]    Script Date: 29.6.2016 23:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Assignments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDone] [bit] NULL,
	[ToDo] [varchar](max) NULL,
	[ProjectId] [int] NULL,
 CONSTRAINT [PK_Assignments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CssCodes]    Script Date: 29.6.2016 23:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CssCodes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Function] [varchar](max) NULL,
	[Code] [varchar](max) NULL,
	[ProjectId] [int] NULL,
 CONSTRAINT [PK_CssCodes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LoginInfoes]    Script Date: 29.6.2016 23:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LoginInfoes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Url] [varchar](max) NULL,
	[Username] [varchar](max) NULL,
	[Password] [varchar](max) NULL,
	[ProjectId] [int] NULL,
 CONSTRAINT [PK_LoginInfoes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 29.6.2016 23:22:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Projects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](max) NULL,
	[Client] [varchar](max) NULL,
	[StartDate] [datetime] NULL,
	[FinishDate] [datetime] NULL,
	[DeadLine] [datetime] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Index [IX_FK_Assignment_ToTable]    Script Date: 29.6.2016 23:22:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_Assignment_ToTable] ON [dbo].[Assignments]
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_CssCode_ToTable]    Script Date: 29.6.2016 23:22:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_CssCode_ToTable] ON [dbo].[CssCodes]
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_LoginInfo_ToTable]    Script Date: 29.6.2016 23:22:11 ******/
CREATE NONCLUSTERED INDEX [IX_FK_LoginInfo_ToTable] ON [dbo].[LoginInfoes]
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Assignments]  WITH CHECK ADD  CONSTRAINT [FK_Assignment_ToTable] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([Id])
GO
ALTER TABLE [dbo].[Assignments] CHECK CONSTRAINT [FK_Assignment_ToTable]
GO
ALTER TABLE [dbo].[CssCodes]  WITH CHECK ADD  CONSTRAINT [FK_CssCode_ToTable] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([Id])
GO
ALTER TABLE [dbo].[CssCodes] CHECK CONSTRAINT [FK_CssCode_ToTable]
GO
ALTER TABLE [dbo].[LoginInfoes]  WITH CHECK ADD  CONSTRAINT [FK_LoginInfo_ToTable] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([Id])
GO
ALTER TABLE [dbo].[LoginInfoes] CHECK CONSTRAINT [FK_LoginInfo_ToTable]
GO
USE [master]
GO
ALTER DATABASE [ProjerctManagementAndNotesDB] SET  READ_WRITE 
GO
