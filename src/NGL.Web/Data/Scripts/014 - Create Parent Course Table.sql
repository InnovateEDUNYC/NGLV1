IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[edfi].[ParentCourse]') AND type in (N'U'))
BEGIN
CREATE TABLE [edfi].[ParentCourse](
	[EducationOrganizationId] [int] NOT NULL,
	[ParentCourseCode] [nvarchar](60) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ParentCourseTitle] [nvarchar](60) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ParentCourseDescription] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Id] [uniqueidentifier] NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[EducationOrganizationId] ASC,
	[ParentCourseCode] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)
END
GO