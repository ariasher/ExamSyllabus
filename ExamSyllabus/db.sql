CREATE DATABASE Syllabus;


USE [Syllabus]
GO
/****** Object:  Table [dbo].[Exam]    Script Date: 16/04/2020 04:27:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exam](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ExamName] [nvarchar](50) NOT NULL,
	[Deleted] [bit] NOT NULL CONSTRAINT [DF_Exam_Deleted]  DEFAULT ((0)),
 CONSTRAINT [PK_Exam] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExamRelation]    Script Date: 16/04/2020 04:27:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamRelation](
	[ExamId] [int] NOT NULL,
	[TopicId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL CONSTRAINT [DF_ExamRelation_Deleted]  DEFAULT ((0)),
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_ExamRelation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Subject]    Script Date: 16/04/2020 04:27:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SubjectName] [nvarchar](50) NOT NULL,
	[Deleted] [bit] NOT NULL CONSTRAINT [DF_Subject_Deleted]  DEFAULT ((0)),
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Topic]    Script Date: 16/04/2020 04:27:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Topic](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TopicName] [nvarchar](100) NOT NULL,
	[ParentSubject] [int] NOT NULL,
	[Deleted] [bit] NOT NULL CONSTRAINT [DF_Topic_Deleted]  DEFAULT ((0)),
 CONSTRAINT [PK_Topic] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ExamRelation]  WITH CHECK ADD  CONSTRAINT [FK_ExamRelation_Exam] FOREIGN KEY([ExamId])
REFERENCES [dbo].[Exam] ([Id])
GO
ALTER TABLE [dbo].[ExamRelation] CHECK CONSTRAINT [FK_ExamRelation_Exam]
GO
ALTER TABLE [dbo].[ExamRelation]  WITH CHECK ADD  CONSTRAINT [FK_ExamRelation_Topic] FOREIGN KEY([TopicId])
REFERENCES [dbo].[Topic] ([Id])
GO
ALTER TABLE [dbo].[ExamRelation] CHECK CONSTRAINT [FK_ExamRelation_Topic]
GO
ALTER TABLE [dbo].[Topic]  WITH CHECK ADD  CONSTRAINT [FK_Topic_Subject] FOREIGN KEY([ParentSubject])
REFERENCES [dbo].[Subject] ([Id])
GO
ALTER TABLE [dbo].[Topic] CHECK CONSTRAINT [FK_Topic_Subject]
GO
