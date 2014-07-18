﻿CREATE TABLE [dbo].[StudentAcademicDetails](
	[StudentUSI] [int] NOT NULL,
	[ReadingScore] [decimal](3, 2) NOT NULL,
	[WritingScore] [decimal](3, 2) NOT NULL,
	[MathScore] [decimal](3, 2) NOT NULL,
	[PerfomanceHistory] [nvarchar](4000),
	[PerformanceHistoryFileUrl] [varchar](200),
	[Id] [uniqueidentifier] NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	CONSTRAINT [PK_StudentAcademicDetails] PRIMARY KEY CLUSTERED 
(
	[StudentUSI] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[StudentAcademicDetails] ADD  CONSTRAINT [DF_StudentAcademicDetails_Id]  DEFAULT (newid()) FOR [Id]
GO

ALTER TABLE [dbo].[StudentAcademicDetails] ADD  CONSTRAINT [DF_StudentAcademicDetails_LastModifiedDate]  DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[StudentAcademicDetails] ADD  CONSTRAINT [DF_StudentAcademicDetails_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO

ALTER TABLE [dbo].[StudentAcademicDetails]  WITH CHECK ADD  CONSTRAINT [FK_StudentAcademicDetails_Student] FOREIGN KEY([StudentUSI])
REFERENCES [edfi].[Student] ([StudentUSI])
GO

ALTER TABLE [dbo].[StudentAcademicDetails] CHECK CONSTRAINT [FK_StudentAcademicDetails_Student]
GO
