ALTER TABLE [edfi].[Course] 
ADD CourseIdentity int IDENTITY(1,1) NOT NULL

CREATE UNIQUE INDEX IX_CourseIdentity on [edfi].[Course] (CourseIdentity)