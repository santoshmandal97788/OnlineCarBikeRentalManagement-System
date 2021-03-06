USE [master]
GO
/****** Object:  Database [OnlineCarBikeRentalDB]    Script Date: 7/25/2019 1:37:42 PM ******/
CREATE DATABASE [OnlineCarBikeRentalDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OnlineCarBikeRentalDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\OnlineCarBikeRentalDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OnlineCarBikeRentalDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\OnlineCarBikeRentalDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [OnlineCarBikeRentalDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OnlineCarBikeRentalDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OnlineCarBikeRentalDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OnlineCarBikeRentalDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OnlineCarBikeRentalDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OnlineCarBikeRentalDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OnlineCarBikeRentalDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [OnlineCarBikeRentalDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OnlineCarBikeRentalDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OnlineCarBikeRentalDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OnlineCarBikeRentalDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OnlineCarBikeRentalDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OnlineCarBikeRentalDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OnlineCarBikeRentalDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OnlineCarBikeRentalDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OnlineCarBikeRentalDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OnlineCarBikeRentalDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OnlineCarBikeRentalDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OnlineCarBikeRentalDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OnlineCarBikeRentalDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OnlineCarBikeRentalDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OnlineCarBikeRentalDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OnlineCarBikeRentalDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OnlineCarBikeRentalDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OnlineCarBikeRentalDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [OnlineCarBikeRentalDB] SET  MULTI_USER 
GO
ALTER DATABASE [OnlineCarBikeRentalDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OnlineCarBikeRentalDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OnlineCarBikeRentalDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OnlineCarBikeRentalDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OnlineCarBikeRentalDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OnlineCarBikeRentalDB] SET QUERY_STORE = OFF
GO
USE [OnlineCarBikeRentalDB]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 7/25/2019 1:37:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblRoles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblAboutUs]    Script Date: 7/25/2019 1:37:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAboutUs](
	[AboutUsId] [int] IDENTITY(1,1) NOT NULL,
	[SubHeadingParagraph] [nvarchar](500) NULL,
	[Content] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[Icon] [nvarchar](150) NULL,
	[CardHeading] [nvarchar](500) NULL,
	[CardParagraph] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblAboutUs] PRIMARY KEY CLUSTERED 
(
	[AboutUsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblBikeCar]    Script Date: 7/25/2019 1:37:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblBikeCar](
	[VehicleId] [int] IDENTITY(1,1) NOT NULL,
	[VendorId] [int] NULL,
	[Bike/CarName] [nvarchar](50) NULL,
	[EngieneCC] [nvarchar](50) NULL,
	[PricePerHour] [int] NULL,
	[PricePerDay] [int] NULL,
	[PricePerWeek] [int] NULL,
	[PricePermonth] [int] NULL,
	[FuelUsed] [nvarchar](50) NULL,
	[SmallImage] [nvarchar](max) NULL,
	[LargeImgae] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblBikeCar] PRIMARY KEY CLUSTERED 
(
	[VehicleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblBikeCarRecord]    Script Date: 7/25/2019 1:37:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblBikeCarRecord](
	[BikeCarRecordId] [int] IDENTITY(1,1) NOT NULL,
	[VehicleId] [int] NULL,
	[NoPlate] [nvarchar](150) NULL,
	[EngieneNo] [nvarchar](150) NULL,
 CONSTRAINT [PK_tblBikeCarRecord] PRIMARY KEY CLUSTERED 
(
	[BikeCarRecordId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblBooking]    Script Date: 7/25/2019 1:37:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblBooking](
	[BookingId] [int] IDENTITY(1,1) NOT NULL,
	[BookingDate] [date] NULL,
	[VehicleId] [int] NULL,
	[PickUpDate] [date] NULL,
	[ReturnDate] [date] NULL,
	[UserId] [nvarchar](250) NULL,
	[FullName] [nvarchar](250) NULL,
	[Address] [nvarchar](250) NULL,
	[Phone] [nvarchar](50) NULL,
	[HireDetails] [nvarchar](150) NULL,
	[Status] [nvarchar](150) NULL,
 CONSTRAINT [PK_tblBooking] PRIMARY KEY CLUSTERED 
(
	[BookingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCategory]    Script Date: 7/25/2019 1:37:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCategory](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblCategory] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblComment]    Script Date: 7/25/2019 1:37:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblComment](
	[CommentId] [int] IDENTITY(1,1) NOT NULL,
	[Fullname] [nvarchar](250) NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
	[Comment] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_tblComment] PRIMARY KEY CLUSTERED 
(
	[CommentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblContact]    Script Date: 7/25/2019 1:37:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblContact](
	[ContactId] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](150) NULL,
	[Email] [nvarchar](250) NULL,
	[Website] [nvarchar](max) NULL,
	[Subject] [nvarchar](max) NULL,
	[Message] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblContact] PRIMARY KEY CLUSTERED 
(
	[ContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCustomerRecord]    Script Date: 7/25/2019 1:37:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCustomerRecord](
	[CustomerRecordId] [int] IDENTITY(1,1) NOT NULL,
	[BookingId] [int] NULL,
	[Address] [nvarchar](500) NULL,
	[Phone1] [nvarchar](50) NULL,
	[Phone2] [nvarchar](50) NULL,
	[BikeCarRecordId] [int] NULL,
	[CitizenshipNo] [nvarchar](150) NULL,
	[Photo] [nvarchar](max) NULL,
	[LicenseNo] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblCustomerRecord] PRIMARY KEY CLUSTERED 
(
	[CustomerRecordId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblDriver]    Script Date: 7/25/2019 1:37:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDriver](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DriverName] [nvarchar](150) NULL,
	[DriverCategory] [nvarchar](250) NULL,
	[Image] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblDriver] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblFaqHeading]    Script Date: 7/25/2019 1:37:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblFaqHeading](
	[FaqId] [int] IDENTITY(1,1) NOT NULL,
	[FaqHeading] [nvarchar](500) NULL,
 CONSTRAINT [PK_tblFaqHeading] PRIMARY KEY CLUSTERED 
(
	[FaqId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblFaqQA]    Script Date: 7/25/2019 1:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblFaqQA](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FaqId] [int] NULL,
	[Question] [nvarchar](max) NULL,
	[Answer] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblFaqQA] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblHelpDesk]    Script Date: 7/25/2019 1:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblHelpDesk](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Position] [nvarchar](250) NULL,
	[About] [nvarchar](max) NULL,
	[SmallImage] [nvarchar](max) NULL,
	[LargeImage] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblHelpDesk] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblMenu]    Script Date: 7/25/2019 1:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMenu](
	[MenuId] [int] IDENTITY(1,1) NOT NULL,
	[MenuName] [nvarchar](50) NULL,
	[ControllerName] [nvarchar](50) NULL,
	[ActionName] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblMenu] PRIMARY KEY CLUSTERED 
(
	[MenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPackageContent]    Script Date: 7/25/2019 1:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPackageContent](
	[PackageId] [int] IDENTITY(1,1) NOT NULL,
	[PackageHeading] [nvarchar](max) NULL,
	[ListPackage] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblPackageContent] PRIMARY KEY CLUSTERED 
(
	[PackageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPayment]    Script Date: 7/25/2019 1:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPayment](
	[PaymentId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerRecordId] [int] NULL,
	[BookingId] [int] NULL,
	[TotalPrice] [int] NULL,
	[PaymentDate] [date] NULL,
	[ReceivedBy] [nvarchar](150) NULL,
 CONSTRAINT [PK_tblPayment] PRIMARY KEY CLUSTERED 
(
	[PaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblRentalContent]    Script Date: 7/25/2019 1:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblRentalContent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Heading] [nvarchar](500) NULL,
	[FeatureList] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblRentalContent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblServicesContent]    Script Date: 7/25/2019 1:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblServicesContent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Heading] [nvarchar](500) NULL,
	[Paragraph] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblServicesContent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblServiceSection]    Script Date: 7/25/2019 1:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblServiceSection](
	[ServiceId] [int] IDENTITY(1,1) NOT NULL,
	[Icon] [nvarchar](250) NULL,
	[Heading] [nvarchar](500) NULL,
	[Paragraph] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblServiceSection] PRIMARY KEY CLUSTERED 
(
	[ServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSlider]    Script Date: 7/25/2019 1:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSlider](
	[SliderId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblSlider] PRIMARY KEY CLUSTERED 
(
	[SliderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblStock]    Script Date: 7/25/2019 1:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblStock](
	[StockId] [int] IDENTITY(1,1) NOT NULL,
	[VehicleId] [int] NULL,
	[TotalBike/Car] [int] NULL,
 CONSTRAINT [PK_tblStock] PRIMARY KEY CLUSTERED 
(
	[StockId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSubMenu]    Script Date: 7/25/2019 1:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSubMenu](
	[SubMenuId] [int] IDENTITY(1,1) NOT NULL,
	[MenuId] [int] NULL,
	[SubMenuName] [nvarchar](50) NULL,
	[ControllerName] [nvarchar](50) NULL,
	[ActionName] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblSubMenu] PRIMARY KEY CLUSTERED 
(
	[SubMenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblTestimonial]    Script Date: 7/25/2019 1:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTestimonial](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Paragraph] [nvarchar](max) NULL,
	[Username] [nvarchar](250) NULL,
	[Image] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblTestimonial] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 7/25/2019 1:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUser](
	[UserId] [nvarchar](250) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblVendor]    Script Date: 7/25/2019 1:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblVendor](
	[VendorId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NULL,
	[VendorName] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblVendor] PRIMARY KEY CLUSTERED 
(
	[VendorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 7/25/2019 1:37:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserRolesId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](250) NULL,
	[RoleId] [int] NULL,
 CONSTRAINT [PK_tblUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserRolesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblBikeCar]  WITH CHECK ADD  CONSTRAINT [FK_tblBikeCar_tblVendor] FOREIGN KEY([VendorId])
REFERENCES [dbo].[tblVendor] ([VendorId])
GO
ALTER TABLE [dbo].[tblBikeCar] CHECK CONSTRAINT [FK_tblBikeCar_tblVendor]
GO
ALTER TABLE [dbo].[tblBikeCarRecord]  WITH CHECK ADD  CONSTRAINT [FK_tblBikeCarRecord_tblBikeCar] FOREIGN KEY([VehicleId])
REFERENCES [dbo].[tblBikeCar] ([VehicleId])
GO
ALTER TABLE [dbo].[tblBikeCarRecord] CHECK CONSTRAINT [FK_tblBikeCarRecord_tblBikeCar]
GO
ALTER TABLE [dbo].[tblBooking]  WITH CHECK ADD  CONSTRAINT [FK_tblBooking_tblBikeCar] FOREIGN KEY([VehicleId])
REFERENCES [dbo].[tblBikeCar] ([VehicleId])
GO
ALTER TABLE [dbo].[tblBooking] CHECK CONSTRAINT [FK_tblBooking_tblBikeCar]
GO
ALTER TABLE [dbo].[tblCustomerRecord]  WITH CHECK ADD  CONSTRAINT [FK_tblCustomerRecord_tblBikeCarRecord] FOREIGN KEY([BikeCarRecordId])
REFERENCES [dbo].[tblBikeCarRecord] ([BikeCarRecordId])
GO
ALTER TABLE [dbo].[tblCustomerRecord] CHECK CONSTRAINT [FK_tblCustomerRecord_tblBikeCarRecord]
GO
ALTER TABLE [dbo].[tblCustomerRecord]  WITH CHECK ADD  CONSTRAINT [FK_tblCustomerRecord_tblBooking] FOREIGN KEY([BookingId])
REFERENCES [dbo].[tblBooking] ([BookingId])
GO
ALTER TABLE [dbo].[tblCustomerRecord] CHECK CONSTRAINT [FK_tblCustomerRecord_tblBooking]
GO
ALTER TABLE [dbo].[tblFaqQA]  WITH CHECK ADD  CONSTRAINT [FK_tblFaqQA_tblFaqHeading] FOREIGN KEY([FaqId])
REFERENCES [dbo].[tblFaqHeading] ([FaqId])
GO
ALTER TABLE [dbo].[tblFaqQA] CHECK CONSTRAINT [FK_tblFaqQA_tblFaqHeading]
GO
ALTER TABLE [dbo].[tblPayment]  WITH CHECK ADD  CONSTRAINT [FK_tblPayment_tblBooking] FOREIGN KEY([BookingId])
REFERENCES [dbo].[tblBooking] ([BookingId])
GO
ALTER TABLE [dbo].[tblPayment] CHECK CONSTRAINT [FK_tblPayment_tblBooking]
GO
ALTER TABLE [dbo].[tblPayment]  WITH CHECK ADD  CONSTRAINT [FK_tblPayment_tblCustomerRecord] FOREIGN KEY([CustomerRecordId])
REFERENCES [dbo].[tblCustomerRecord] ([CustomerRecordId])
GO
ALTER TABLE [dbo].[tblPayment] CHECK CONSTRAINT [FK_tblPayment_tblCustomerRecord]
GO
ALTER TABLE [dbo].[tblStock]  WITH CHECK ADD  CONSTRAINT [FK_tblStock_tblBikeCar] FOREIGN KEY([VehicleId])
REFERENCES [dbo].[tblBikeCar] ([VehicleId])
GO
ALTER TABLE [dbo].[tblStock] CHECK CONSTRAINT [FK_tblStock_tblBikeCar]
GO
ALTER TABLE [dbo].[tblSubMenu]  WITH CHECK ADD  CONSTRAINT [FK_tblSubMenu_tblMenu] FOREIGN KEY([MenuId])
REFERENCES [dbo].[tblMenu] ([MenuId])
GO
ALTER TABLE [dbo].[tblSubMenu] CHECK CONSTRAINT [FK_tblSubMenu_tblMenu]
GO
ALTER TABLE [dbo].[tblVendor]  WITH CHECK ADD  CONSTRAINT [FK_tblVendor_tblCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[tblCategory] ([CategoryId])
GO
ALTER TABLE [dbo].[tblVendor] CHECK CONSTRAINT [FK_tblVendor_tblCategory]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_tblUserRoles_tblRoles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_tblUserRoles_tblRoles]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_tblUserRoles_tblUser] FOREIGN KEY([UserId])
REFERENCES [dbo].[tblUser] ([UserId])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_tblUserRoles_tblUser]
GO
USE [master]
GO
ALTER DATABASE [OnlineCarBikeRentalDB] SET  READ_WRITE 
GO
