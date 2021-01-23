USE [master]
GO
/****** Object:  Database [SignalRChat]    Script Date: 19-Jan-21 12:27:46 AM ******/
CREATE DATABASE [SignalRChat]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SignalRChat', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\SignalRChat.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SignalRChat_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\SignalRChat_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [SignalRChat] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SignalRChat].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SignalRChat] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SignalRChat] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SignalRChat] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SignalRChat] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SignalRChat] SET ARITHABORT OFF 
GO
ALTER DATABASE [SignalRChat] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SignalRChat] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SignalRChat] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SignalRChat] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SignalRChat] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SignalRChat] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SignalRChat] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SignalRChat] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SignalRChat] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SignalRChat] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SignalRChat] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SignalRChat] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SignalRChat] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SignalRChat] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SignalRChat] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SignalRChat] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SignalRChat] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SignalRChat] SET RECOVERY FULL 
GO
ALTER DATABASE [SignalRChat] SET  MULTI_USER 
GO
ALTER DATABASE [SignalRChat] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SignalRChat] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SignalRChat] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SignalRChat] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SignalRChat] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SignalRChat', N'ON'
GO
ALTER DATABASE [SignalRChat] SET QUERY_STORE = OFF
GO
USE [SignalRChat]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [SignalRChat]
GO
/****** Object:  Table [dbo].[User]    Script Date: 19-Jan-21 12:27:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_User_Email] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserChat]    Script Date: 19-Jan-21 12:27:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserChat](
	[Chatid] [bigint] IDENTITY(1,1) NOT NULL,
	[Senderid] [bigint] NOT NULL,
	[Receiverid] [bigint] NOT NULL,
	[Message] [nvarchar](max) NULL,
	[Messagedate] [datetime] NULL,
	[Deletedfor] [bigint] NULL,
 CONSTRAINT [PK_UserChat] PRIMARY KEY CLUSTERED 
(
	[Chatid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [SignalRChat] SET  READ_WRITE 
GO
