IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ParentCourse]') AND type in (N'U'))
CREATE TABLE [dbo].[ParentCourse](
	[EducationOrganizationId] [int] NOT NULL,
	[ParentCourseCode] [nvarchar](60) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ParentCourseTitle] [nvarchar](60) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ParentCourseDescription] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Id] [uniqueidentifier] NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ParentCourse] PRIMARY KEY CLUSTERED 
(
	[Id]
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

ALTER TABLE [dbo].[ParentCourse] ADD  CONSTRAINT [DF_ParentCourse_Id]  DEFAULT (newid()) FOR [Id]

ALTER TABLE [dbo].[ParentCourse] ADD  DEFAULT (getdate()) FOR [LastModifiedDate]

ALTER TABLE [dbo].[ParentCourse] ADD  DEFAULT (getdate()) FOR [CreateDate]