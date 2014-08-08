ALTER TABLE [edfi].[Assessment]
	ADD [AdministeredDate] date not null


CREATE TABLE [dbo].[AssessmentLearningStandard](
	[Id] [uniqueidentifier] NOT NULL,
	[AssessmentTitle] [nvarchar](60) NOT NULL,
	[AcademicSubjectDescriptorId] [int] NOT NULL,
	[AssessedGradeLevelDescriptorId] [int] NOT NULL,
	[Version] [int] NOT NULL,
	[LearningStandardId] [nvarchar](60) NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_AssessmentLearningStandard] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)
GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[AssessmentLearningStandard] ADD  DEFAULT (newid()) FOR [Id]
GO

ALTER TABLE [dbo].[AssessmentLearningStandard] ADD  DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[AssessmentLearningStandard] ADD  DEFAULT (getdate()) FOR [CreateDate]
GO

ALTER TABLE [dbo].[AssessmentLearningStandard]  WITH CHECK ADD  CONSTRAINT [FK_AssessmentLearningStandard_Assessment_AssessmentTitle] FOREIGN KEY([AssessmentTitle], [AcademicSubjectDescriptorId], [AssessedGradeLevelDescriptorId], [Version])
REFERENCES [edfi].[Assessment] ([AssessmentTitle], [AcademicSubjectDescriptorId], [AssessedGradeLevelDescriptorId], [Version])
GO

ALTER TABLE [dbo].[AssessmentLearningStandard] CHECK CONSTRAINT [FK_AssessmentLearningStandard_Assessment_AssessmentTitle]
GO

ALTER TABLE [dbo].[AssessmentLearningStandard]  WITH CHECK ADD  CONSTRAINT [FK_AssessmentLearningStandard_LearningStandard_LearningStandardId] FOREIGN KEY([LearningStandardId])
REFERENCES [edfi].[LearningStandard] ([LearningStandardId])
GO

ALTER TABLE [dbo].[AssessmentLearningStandard] CHECK CONSTRAINT [FK_AssessmentLearningStandard_LearningStandard_LearningStandardId]
GO
