INSERT INTO [edfi].[Assessment]
	  ([AssessmentTitle]
      ,[AcademicSubjectDescriptorId]
      ,[AssessedGradeLevelDescriptorId]
      ,[Version]
      ,[AssessmentCategoryTypeId])
	VALUES
	('Motor Skills Formative Assessment', 1, 119, 1, 17)


declare @masteryTypeId int
select @masteryTypeId = PerformanceBaseConversionTypeId from [edfi].[PerformanceBaseConversionType] where CodeValue = 'Mastery'

declare @masteryDescriptorId int
select @masteryDescriptorId = PerformanceLevelDescriptorId from [edfi].[PerformanceLevelDescriptor] where PerformanceBaseConversionTypeId = @masteryTypeId

declare @nearMasteryTypeId int
select @nearMasteryTypeId = PerformanceBaseConversionTypeId from [edfi].[PerformanceBaseConversionType] where CodeValue = 'Near Mastery'

declare @nearMasteryDescriptorId int
select @nearMasteryDescriptorId = PerformanceLevelDescriptorId from [edfi].[PerformanceLevelDescriptor] where PerformanceBaseConversionTypeId = @nearMasteryTypeId


INSERT INTO [edfi].[AssessmentPerformanceLevel]
           ([AssessmentTitle]
		  ,[AcademicSubjectDescriptorId]
		  ,[AssessedGradeLevelDescriptorId]
		  ,[Version]
		  ,[PerformanceLevelDescriptorId]
		  ,[AssessmentReportingMethodTypeId]
		  ,[MinimumScore]
		  ,[ResultDatatypeTypeId])
	VALUES
	('Motor Skills Formative Assessment', 1, 119, 1, @masteryDescriptorId, 16, 90, 3)
	
INSERT INTO [edfi].[AssessmentPerformanceLevel]
           ([AssessmentTitle]
		  ,[AcademicSubjectDescriptorId]
		  ,[AssessedGradeLevelDescriptorId]
		  ,[Version]
		  ,[PerformanceLevelDescriptorId]
		  ,[AssessmentReportingMethodTypeId]
		  ,[MinimumScore]
		  ,[ResultDatatypeTypeId])
	VALUES
	('Motor Skills Formative Assessment', 1, 119, 1, @nearMasteryDescriptorId, 16, 70, 3)