CREATE TABLE [dbo].[AttendanceFlag](
	[AttendanceFlagIdentity] [int] IDENTITY(1,1) NOT NULL,
	[StudentUSI] [int] NOT NULL UNIQUE,
	[FlagCount] [int] NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	 
	CONSTRAINT [PK_AttendanceFlag] PRIMARY KEY CLUSTERED 
(
	[AttendanceFlagIdentity] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

ALTER TABLE [dbo].[AttendanceFlag] ADD  DEFAULT (getdate()) FOR [LastModifiedDate]

ALTER TABLE [dbo].[AttendanceFlag] ADD  DEFAULT (getdate()) FOR [CreateDate]

ALTER TABLE [dbo].[AttendanceFlag] ADD CONSTRAINT
	[FK_AttendanceFlag_Student_StudentUSI] FOREIGN KEY
	(StudentUSI) REFERENCES [edfi].[Student] (StudentUSI)
GO