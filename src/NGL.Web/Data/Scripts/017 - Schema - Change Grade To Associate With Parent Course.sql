IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ParentCourseGrade]') AND type in (N'U'))
CREATE TABLE [dbo].[ParentCourseGrade](
	[StudentUSI] [int] NOT NULL,
	[SchoolId] [int] NOT NULL,
	[TermTypeId] [int] NOT NULL,
	[SchoolYear] [smallint] NOT NULL,
	[ParentCourseId] [uniqueidentifier] NOT NULL,
	[GradeEarned] [nvarchar](20) NULL,
	[Id] [uniqueidentifier] NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ParentCourseGradeIdentity] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_ParentCourseGrade] PRIMARY KEY CLUSTERED 
(
	[ParentCourseGradeIdentity] ASC
)
WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

ALTER TABLE [dbo].[ParentCourseGrade]  ADD  CONSTRAINT [FK_ParentCourseGrade_Student_StudentUSI] FOREIGN KEY([StudentUSI]) REFERENCES [edfi].[Student] ([StudentUSI])

ALTER TABLE [dbo].[ParentCourseGrade]  ADD  CONSTRAINT [FK_ParentCourseGrade_Session_SessionIdentity] FOREIGN KEY(
	[SchoolId],
	[TermTypeId],
	[SchoolYear]
) REFERENCES [edfi].[Session] (	
	[SchoolId],
	[TermTypeId],
	[SchoolYear])

ALTER TABLE [dbo].[ParentCourseGrade]  ADD  CONSTRAINT [FK_ParentCourseGrade_ParentCourse_ParentCourseId] FOREIGN KEY([ParentCourseId]) REFERENCES [dbo].[ParentCourse] ([Id])
