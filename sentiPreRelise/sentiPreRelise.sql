USE [master]
GO
/****** Object:  Database [SentiDb]    Script Date: 16.10.2023 4:19:29 ******/
CREATE DATABASE [SentiDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SentiDb', FILENAME = N'E:\forwork\MSSQL15.SA\MSSQL\DATA\SentiDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SentiDb_log', FILENAME = N'E:\forwork\MSSQL15.SA\MSSQL\DATA\SentiDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 COLLATE Cyrillic_General_CI_AI
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SentiDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SentiDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SentiDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SentiDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SentiDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SentiDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SentiDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [SentiDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SentiDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SentiDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SentiDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SentiDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SentiDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SentiDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SentiDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SentiDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SentiDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SentiDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SentiDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SentiDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SentiDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SentiDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SentiDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SentiDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SentiDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SentiDb] SET  MULTI_USER 
GO
ALTER DATABASE [SentiDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SentiDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SentiDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SentiDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SentiDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SentiDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [SentiDb] SET QUERY_STORE = OFF
GO
USE [SentiDb]
GO
/****** Object:  Table [dbo].[Appointment]    Script Date: 16.10.2023 4:19:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointment](
	[AppointmentId] [int] IDENTITY(1,1) NOT NULL,
	[Payment] [float] NULL,
	[RegistrationId] [int] NULL,
	[Comment] [text] COLLATE Cyrillic_General_CI_AI NULL,
 CONSTRAINT [PK_Appointment_1] PRIMARY KEY CLUSTERED 
(
	[AppointmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 16.10.2023 4:19:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[ClientId] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](50) COLLATE Cyrillic_General_CI_AI NULL,
	[FirstName] [nvarchar](50) COLLATE Cyrillic_General_CI_AI NULL,
	[Patronymic] [nvarchar](50) COLLATE Cyrillic_General_CI_AI NULL,
	[ContactInfo] [nvarchar](50) COLLATE Cyrillic_General_CI_AI NULL,
	[Comment] [text] COLLATE Cyrillic_General_CI_AI NULL,
	[MedHistory] [text] COLLATE Cyrillic_General_CI_AI NULL,
	[Status] [nvarchar](50) COLLATE Cyrillic_General_CI_AI NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeInfo]    Script Date: 16.10.2023 4:19:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeInfo](
	[EmployeeInfoId] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](50) COLLATE Cyrillic_General_CI_AI NULL,
	[FirstName] [nvarchar](50) COLLATE Cyrillic_General_CI_AI NULL,
	[Patronymic] [nvarchar](50) COLLATE Cyrillic_General_CI_AI NULL,
	[EmployeePhoto] [varbinary](max) NULL,
	[EmployeeIDocument] [varbinary](max) NULL,
	[AcceptanceDate] [date] NULL,
	[Status] [nvarchar](50) COLLATE Cyrillic_General_CI_AI NULL,
 CONSTRAINT [PK_EmployeeInfo] PRIMARY KEY CLUSTERED 
(
	[EmployeeInfoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeSpecializations]    Script Date: 16.10.2023 4:19:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeSpecializations](
	[EmployeeSpecializationsId] [int] IDENTITY(1,1) NOT NULL,
	[SpecializationId] [int] NULL,
	[EmployeeId] [int] NULL,
 CONSTRAINT [PK_EmployeeSpecializations] PRIMARY KEY CLUSTERED 
(
	[EmployeeSpecializationsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registration]    Script Date: 16.10.2023 4:19:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registration](
	[RegistrationId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NULL,
	[ClientId] [int] NULL,
	[DateTime] [datetime] NULL,
	[Status] [nvarchar](50) COLLATE Cyrillic_General_CI_AI NULL,
	[RegistrationDate] [datetime] NULL,
 CONSTRAINT [PK_Appointment] PRIMARY KEY CLUSTERED 
(
	[RegistrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 16.10.2023 4:19:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] NOT NULL,
	[RoleName] [nvarchar](20) COLLATE Cyrillic_General_CI_AI NULL,
	[AccessLevel] [int] NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 16.10.2023 4:19:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[RoomId] [int] NOT NULL,
	[RoomNumber] [nvarchar](5) COLLATE Cyrillic_General_CI_AI NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[RoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shedule]    Script Date: 16.10.2023 4:19:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shedule](
	[SheduleId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NULL,
	[RoomId] [int] NULL,
	[Day] [date] NULL,
	[StartTime] [time](7) NULL,
	[EndTime] [time](7) NULL,
	[TimeSlotsGroupId] [int] NULL,
 CONSTRAINT [PK_Shedule] PRIMARY KEY CLUSTERED 
(
	[SheduleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Specialization]    Script Date: 16.10.2023 4:19:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Specialization](
	[SpecializationId] [int] NOT NULL,
	[SpecializationName] [nvarchar](50) COLLATE Cyrillic_General_CI_AI NULL,
 CONSTRAINT [PK_Specialization] PRIMARY KEY CLUSTERED 
(
	[SpecializationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TimeSlotGroup]    Script Date: 16.10.2023 4:19:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeSlotGroup](
	[TimeSlotsGroupId] [int] NOT NULL,
	[TimeSlot] [time](7) NULL,
	[SlotOccupancy] [nvarchar](20) COLLATE Cyrillic_General_CI_AI NULL,
 CONSTRAINT [PK_TimeSlotGroup] PRIMARY KEY CLUSTERED 
(
	[TimeSlotsGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 16.10.2023 4:19:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] NOT NULL,
	[Password] [nvarchar](50) COLLATE Cyrillic_General_CI_AI NOT NULL,
	[Login] [nvarchar](50) COLLATE Cyrillic_General_CI_AI NOT NULL,
	[RoleId] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Appointment] ON 

INSERT [dbo].[Appointment] ([AppointmentId], [Payment], [RegistrationId], [Comment]) VALUES (1, 3000, 2, N'Продолжать выполнять упражнения из лекции "Психосоматиака человека"')
INSERT [dbo].[Appointment] ([AppointmentId], [Payment], [RegistrationId], [Comment]) VALUES (2, 2000, 3, N'комментарий')
INSERT [dbo].[Appointment] ([AppointmentId], [Payment], [RegistrationId], [Comment]) VALUES (4, NULL, 1, NULL)
INSERT [dbo].[Appointment] ([AppointmentId], [Payment], [RegistrationId], [Comment]) VALUES (5, NULL, 4, NULL)
SET IDENTITY_INSERT [dbo].[Appointment] OFF
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([ClientId], [LastName], [FirstName], [Patronymic], [ContactInfo], [Comment], [MedHistory], [Status]) VALUES (1, N'Петров', N'Дмитрий', N'Сергеевич', N'79205567387', NULL, NULL, N'Активен')
INSERT [dbo].[Client] ([ClientId], [LastName], [FirstName], [Patronymic], [ContactInfo], [Comment], [MedHistory], [Status]) VALUES (2, N'Верюков', N'Анатолий', N'Дмитриевич', N'79244567387', NULL, NULL, N'Удалён')
INSERT [dbo].[Client] ([ClientId], [LastName], [FirstName], [Patronymic], [ContactInfo], [Comment], [MedHistory], [Status]) VALUES (3, N'Ворошнева', N'Полина', N'Сергеевна', N'79506063745', NULL, NULL, N'Активен')
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
SET IDENTITY_INSERT [dbo].[EmployeeInfo] ON 

INSERT [dbo].[EmployeeInfo] ([EmployeeInfoId], [LastName], [FirstName], [Patronymic], [EmployeePhoto], [EmployeeIDocument], [AcceptanceDate], [Status]) VALUES (1, N'Девенко', N'Дмитрий', N'Сергеевич', NULL, NULL, CAST(N'2023-10-06' AS Date), N'Активный')
INSERT [dbo].[EmployeeInfo] ([EmployeeInfoId], [LastName], [FirstName], [Patronymic], [EmployeePhoto], [EmployeeIDocument], [AcceptanceDate], [Status]) VALUES (2, N'Власов', N'Игорь', N'Альхайтамович', NULL, NULL, CAST(N'2020-02-02' AS Date), N'Активный')
INSERT [dbo].[EmployeeInfo] ([EmployeeInfoId], [LastName], [FirstName], [Patronymic], [EmployeePhoto], [EmployeeIDocument], [AcceptanceDate], [Status]) VALUES (3, N'Захарова', N'Анастасия', N'Валерьевна', NULL, NULL, CAST(N'2021-03-03' AS Date), N'Активный')
INSERT [dbo].[EmployeeInfo] ([EmployeeInfoId], [LastName], [FirstName], [Patronymic], [EmployeePhoto], [EmployeeIDocument], [AcceptanceDate], [Status]) VALUES (4, N'Звёздочкина', N'Анастасия', N'Михайлова', NULL, NULL, CAST(N'2020-11-11' AS Date), N'Активный')
SET IDENTITY_INSERT [dbo].[EmployeeInfo] OFF
GO
SET IDENTITY_INSERT [dbo].[EmployeeSpecializations] ON 

INSERT [dbo].[EmployeeSpecializations] ([EmployeeSpecializationsId], [SpecializationId], [EmployeeId]) VALUES (1, 1, 2)
INSERT [dbo].[EmployeeSpecializations] ([EmployeeSpecializationsId], [SpecializationId], [EmployeeId]) VALUES (2, 1, 1)
INSERT [dbo].[EmployeeSpecializations] ([EmployeeSpecializationsId], [SpecializationId], [EmployeeId]) VALUES (3, 1, 4)
INSERT [dbo].[EmployeeSpecializations] ([EmployeeSpecializationsId], [SpecializationId], [EmployeeId]) VALUES (4, 2, 4)
INSERT [dbo].[EmployeeSpecializations] ([EmployeeSpecializationsId], [SpecializationId], [EmployeeId]) VALUES (5, 3, 4)
SET IDENTITY_INSERT [dbo].[EmployeeSpecializations] OFF
GO
SET IDENTITY_INSERT [dbo].[Registration] ON 

INSERT [dbo].[Registration] ([RegistrationId], [EmployeeId], [ClientId], [DateTime], [Status], [RegistrationDate]) VALUES (1, 2, 1, CAST(N'2023-10-09T00:00:00.000' AS DateTime), N'Активна', CAST(N'2023-10-11T11:00:00.000' AS DateTime))
INSERT [dbo].[Registration] ([RegistrationId], [EmployeeId], [ClientId], [DateTime], [Status], [RegistrationDate]) VALUES (2, 4, 1, CAST(N'2023-11-09T12:00:00.000' AS DateTime), N'Закрыта', CAST(N'2023-11-11T15:00:00.000' AS DateTime))
INSERT [dbo].[Registration] ([RegistrationId], [EmployeeId], [ClientId], [DateTime], [Status], [RegistrationDate]) VALUES (3, 4, 3, CAST(N'2023-12-10T14:00:00.000' AS DateTime), N'Закрыта', CAST(N'2023-09-09T00:00:00.000' AS DateTime))
INSERT [dbo].[Registration] ([RegistrationId], [EmployeeId], [ClientId], [DateTime], [Status], [RegistrationDate]) VALUES (4, 4, 3, CAST(N'2023-10-12T00:00:00.000' AS DateTime), N'Активна', CAST(N'2023-09-09T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Registration] OFF
GO
INSERT [dbo].[Role] ([RoleId], [RoleName], [AccessLevel]) VALUES (1, N'Врач', 0)
INSERT [dbo].[Role] ([RoleId], [RoleName], [AccessLevel]) VALUES (2, N'Администратор', 2)
INSERT [dbo].[Role] ([RoleId], [RoleName], [AccessLevel]) VALUES (3, N'Регистратор', 1)
GO
INSERT [dbo].[Room] ([RoomId], [RoomNumber]) VALUES (1, N'1А')
INSERT [dbo].[Room] ([RoomId], [RoomNumber]) VALUES (2, N'1')
INSERT [dbo].[Room] ([RoomId], [RoomNumber]) VALUES (3, N'2')
INSERT [dbo].[Room] ([RoomId], [RoomNumber]) VALUES (4, N'2А')
GO
INSERT [dbo].[Specialization] ([SpecializationId], [SpecializationName]) VALUES (1, N'Общая')
INSERT [dbo].[Specialization] ([SpecializationId], [SpecializationName]) VALUES (2, N'Социальная')
INSERT [dbo].[Specialization] ([SpecializationId], [SpecializationName]) VALUES (3, N'Клиническая')
INSERT [dbo].[Specialization] ([SpecializationId], [SpecializationName]) VALUES (4, N'Психология семейных отношений')
GO
INSERT [dbo].[User] ([UserId], [Password], [Login], [RoleId]) VALUES (1, N'1', N'1', 1)
INSERT [dbo].[User] ([UserId], [Password], [Login], [RoleId]) VALUES (2, N'2', N'2', 2)
INSERT [dbo].[User] ([UserId], [Password], [Login], [RoleId]) VALUES (3, N'3', N'3', 3)
INSERT [dbo].[User] ([UserId], [Password], [Login], [RoleId]) VALUES (4, N'4', N'4', 1)
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_Registration] FOREIGN KEY([RegistrationId])
REFERENCES [dbo].[Registration] ([RegistrationId])
GO
ALTER TABLE [dbo].[Appointment] CHECK CONSTRAINT [FK_Appointment_Registration]
GO
ALTER TABLE [dbo].[EmployeeSpecializations]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeSpecializations_EmployeeInfo1] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[EmployeeInfo] ([EmployeeInfoId])
GO
ALTER TABLE [dbo].[EmployeeSpecializations] CHECK CONSTRAINT [FK_EmployeeSpecializations_EmployeeInfo1]
GO
ALTER TABLE [dbo].[EmployeeSpecializations]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeSpecializations_Specialization] FOREIGN KEY([SpecializationId])
REFERENCES [dbo].[Specialization] ([SpecializationId])
GO
ALTER TABLE [dbo].[EmployeeSpecializations] CHECK CONSTRAINT [FK_EmployeeSpecializations_Specialization]
GO
ALTER TABLE [dbo].[Registration]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_Client] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([ClientId])
GO
ALTER TABLE [dbo].[Registration] CHECK CONSTRAINT [FK_Appointment_Client]
GO
ALTER TABLE [dbo].[Registration]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_EmployeeInfo] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[EmployeeInfo] ([EmployeeInfoId])
GO
ALTER TABLE [dbo].[Registration] CHECK CONSTRAINT [FK_Appointment_EmployeeInfo]
GO
ALTER TABLE [dbo].[Shedule]  WITH CHECK ADD  CONSTRAINT [FK_Shedule_EmployeeInfo] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[EmployeeInfo] ([EmployeeInfoId])
GO
ALTER TABLE [dbo].[Shedule] CHECK CONSTRAINT [FK_Shedule_EmployeeInfo]
GO
ALTER TABLE [dbo].[Shedule]  WITH CHECK ADD  CONSTRAINT [FK_Shedule_Room] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Room] ([RoomId])
GO
ALTER TABLE [dbo].[Shedule] CHECK CONSTRAINT [FK_Shedule_Room]
GO
ALTER TABLE [dbo].[Shedule]  WITH CHECK ADD  CONSTRAINT [FK_Shedule_TimeSlotGroup] FOREIGN KEY([TimeSlotsGroupId])
REFERENCES [dbo].[TimeSlotGroup] ([TimeSlotsGroupId])
GO
ALTER TABLE [dbo].[Shedule] CHECK CONSTRAINT [FK_Shedule_TimeSlotGroup]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_EmployeeInfo1] FOREIGN KEY([UserId])
REFERENCES [dbo].[EmployeeInfo] ([EmployeeInfoId])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_EmployeeInfo1]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
USE [master]
GO
ALTER DATABASE [SentiDb] SET  READ_WRITE 
GO
