USE [master]
GO

/****** Object:  Database [studentsGradesSystem]    Script Date: 2021/12/14 11:26:04 ******/
CREATE DATABASE [studentsGradesSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'studentsGradesSystem', FILENAME = N'D:\studentsGradesSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'studentsGradesSystem_log', FILENAME = N'D:\studentsGradesSystem_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [studentsGradesSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [studentsGradesSystem] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [studentsGradesSystem] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [studentsGradesSystem] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [studentsGradesSystem] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [studentsGradesSystem] SET ARITHABORT OFF 
GO

ALTER DATABASE [studentsGradesSystem] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [studentsGradesSystem] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [studentsGradesSystem] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [studentsGradesSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [studentsGradesSystem] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [studentsGradesSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [studentsGradesSystem] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [studentsGradesSystem] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [studentsGradesSystem] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [studentsGradesSystem] SET  DISABLE_BROKER 
GO

ALTER DATABASE [studentsGradesSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [studentsGradesSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [studentsGradesSystem] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [studentsGradesSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [studentsGradesSystem] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [studentsGradesSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [studentsGradesSystem] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [studentsGradesSystem] SET RECOVERY FULL 
GO

ALTER DATABASE [studentsGradesSystem] SET  MULTI_USER 
GO

ALTER DATABASE [studentsGradesSystem] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [studentsGradesSystem] SET DB_CHAINING OFF 
GO

ALTER DATABASE [studentsGradesSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [studentsGradesSystem] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [studentsGradesSystem] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [studentsGradesSystem] SET QUERY_STORE = OFF
GO

ALTER DATABASE [studentsGradesSystem] SET  READ_WRITE 
GO

