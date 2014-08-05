declare @Grade1Id int
declare @Grade2Id int
declare @ELASubjectId int
declare @MathematicsSubjectId int

select @Grade1Id = [GradeLevelDescriptorId] From [edfi].[GradeLevelDescriptor] Where GradeLevelTypeId = 1
select @Grade2Id = [GradeLevelDescriptorId] From [edfi].[GradeLevelDescriptor] Where GradeLevelTypeId = 2

select @ELASubjectId = [AcademicSubjectDescriptorId] From [edfi].[AcademicSubjectDescriptor] d INNER JOIN [edfi].[AcademicSubjectType] t ON d.[AcademicSubjectTypeId] = t.[AcademicSubjectTypeId] Where t.CodeValue = 'ELA'
select @MathematicsSubjectId = [AcademicSubjectDescriptorId] From [edfi].[AcademicSubjectDescriptor] d INNER JOIN [edfi].[AcademicSubjectType] t ON d.[AcademicSubjectTypeId] = t.[AcademicSubjectTypeId] Where t.CodeValue = 'Mathematics'

INSERT INTO [edfi].[LearningStandard]([LearningStandardId],[Description],[URI],[GradeLevelDescriptorId],[AcademicSubjectDescriptorId])
     VALUES('0577C84400AC4c478DE39F9D0C81416B','Reading: Literature > Grade 1 > 1','CCSS.ELA-Literacy.RL.1.1',@Grade1Id,@ELASubjectId),
     ('6159740590EE485e9BDC4761A5C6C309','Reading: Literature > Grade 1 > 2','CCSS.ELA-Literacy.RL.1.2',@Grade1Id,@ELASubjectId),
     ('017AAEA9D22543A59A60C697FEBADD1B','Measurement & Data > Describe and compare measurable attributes. > 1','CCSS.Math.Content.K.MD.A.1',@Grade2Id,@MathematicsSubjectId),
     ('4D3953649C704D4CAFC97E99C7A83EE9','Measurement & Data > Describe and compare measurable attributes. > 2','CCSS.Math.Content.K.MD.A.2',@Grade2Id,@MathematicsSubjectId)
