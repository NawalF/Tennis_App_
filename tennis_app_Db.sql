USE [tennis_app_Db]
GO
/****** Object:  Table [dbo].[Admins]    Script Date: 10/14/2024 4:28:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admins](
	[AdminId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](100) NOT NULL,
	[PasswordHash] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AdminId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Coaches]    Script Date: 10/14/2024 4:28:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coaches](
	[CoachId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Biography] [nvarchar](max) NULL,
	[Photo] [varbinary](max) NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CoachId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enrollments]    Script Date: 10/14/2024 4:28:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enrollments](
	[EnrollId] [int] IDENTITY(1,1) NOT NULL,
	[ScheduleId] [int] NOT NULL,
	[MemberId] [int] NOT NULL,
 CONSTRAINT [PK_Enrollments] PRIMARY KEY CLUSTERED 
(
	[EnrollId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Members]    Script Date: 10/14/2024 4:28:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Members](
	[MemberId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nchar](200) NULL,
	[LastName] [nchar](200) NOT NULL,
	[Email] [nchar](400) NULL,
	[Active] [bit] NOT NULL,
	[Password] [nvarchar](255) NULL,
 CONSTRAINT [PK_Members_New] PRIMARY KEY CLUSTERED 
(
	[MemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedules]    Script Date: 10/14/2024 4:28:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedules](
	[ScheduleId] [int] IDENTITY(1,1) NOT NULL,
	[Location] [nchar](200) NULL,
	[EventName] [nchar](200) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Date] [date] NOT NULL,
	[CoachId] [int] NOT NULL,
	[MemberId] [int] NULL,
 CONSTRAINT [PK_Schedules] PRIMARY KEY CLUSTERED 
(
	[ScheduleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Enrollments]  WITH CHECK ADD  CONSTRAINT [FK_Enrollments_Members] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([MemberId])
GO
ALTER TABLE [dbo].[Enrollments] CHECK CONSTRAINT [FK_Enrollments_Members]
GO
ALTER TABLE [dbo].[Schedules]  WITH CHECK ADD  CONSTRAINT [FK_Schedules_Coaches] FOREIGN KEY([CoachId])
REFERENCES [dbo].[Coaches] ([CoachId])
GO
ALTER TABLE [dbo].[Schedules] CHECK CONSTRAINT [FK_Schedules_Coaches]
GO
ALTER TABLE [dbo].[Schedules]  WITH CHECK ADD  CONSTRAINT [FK_Schedules_Members] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([MemberId])
GO
ALTER TABLE [dbo].[Schedules] CHECK CONSTRAINT [FK_Schedules_Members]
GO
