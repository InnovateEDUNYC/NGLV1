ALTER TABLE [edfi].[Course] ADD
	[ParentCourseId] uniqueidentifier NOT NULL
GO
ALTER TABLE [edfi].[Course] ADD CONSTRAINT
	[FK_Course_ParentCourse_ParentCourseId] FOREIGN KEY
	(ParentCourseId) REFERENCES [dbo].[ParentCourse] (Id)
GO