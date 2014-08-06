INSERT INTO [edfi].[PerformanceBaseConversionType]
           ([CodeValue]
           ,[Description]
           ,[ShortDescription])
     VALUES
	('Mastery', 'Mastery', 'Mastery')

INSERT INTO [edfi].[PerformanceBaseConversionType]
        ([CodeValue]
        ,[Description]
        ,[ShortDescription])
    VALUES
('Near Mastery', 'Near Mastery', 'Near Mastery')

INSERT INTO [edfi].[PerformanceBaseConversionType]
           ([CodeValue]
           ,[Description]
           ,[ShortDescription])
     VALUES
	('Not Mastered', 'Not Mastered', 'Not Mastered')

INSERT INTO [edfi].[Descriptor]
           ([Namespace]
           ,[CodeValue]
           ,[ShortDescription]
           ,[Description]
           ,[EffectiveBeginDate])
     VALUES
	 ('http://www.ed-fi.org/Descriptor/PerformanceLevelDescriptor.xml', 14, 'Mastery', 'Mastery', '2014-08-06')

INSERT INTO [edfi].[Descriptor]
           ([Namespace]
           ,[CodeValue]
           ,[ShortDescription]
           ,[Description]
           ,[EffectiveBeginDate])
     VALUES
	 ('http://www.ed-fi.org/Descriptor/PerformanceLevelDescriptor.xml', 15, 'Near Mastery', 'Near Mastery', '2014-08-06')

INSERT INTO [edfi].[Descriptor]
           ([Namespace]
           ,[CodeValue]
           ,[ShortDescription]
           ,[Description]
           ,[EffectiveBeginDate])
     VALUES
	 ('http://www.ed-fi.org/Descriptor/PerformanceLevelDescriptor.xml', 16, 'Not Mastered', 'Not Mastered', '2014-08-06')

declare @masteryTypeId int
select @masteryTypeId = PerformanceBaseConversionTypeId from [edfi].[PerformanceBaseConversionType] where CodeValue = 'Mastery'

declare @nearmasteryTypeId int
select @nearmasteryTypeId = PerformanceBaseConversionTypeId from [edfi].[PerformanceBaseConversionType] where CodeValue = 'Near Mastery'

declare @notmasteredTypeId int
select @notmasteredTypeId = PerformanceBaseConversionTypeId from [edfi].[PerformanceBaseConversionType] where CodeValue = 'Not Mastered'


declare @masteryDescriptorId int
select @masteryDescriptorId = DescriptorId from [edfi].[Descriptor] where ShortDescription = 'Mastery'

declare @nearMasteryDescriptorId int
select @nearMasteryDescriptorId = DescriptorId from [edfi].[Descriptor] where ShortDescription = 'Near Mastery'

declare @notMasteredDescriptorId int
select @notMasteredDescriptorId = DescriptorId from [edfi].[Descriptor] where ShortDescription = 'Not Mastered'

INSERT INTO [edfi].[PerformanceLevelDescriptor]
           ([PerformanceLevelDescriptorId]
           ,[PerformanceBaseConversionTypeId])
     VALUES
	 (@masteryDescriptorId, @masteryTypeId)	 

INSERT INTO [edfi].[PerformanceLevelDescriptor]
           ([PerformanceLevelDescriptorId]
           ,[PerformanceBaseConversionTypeId])
     VALUES
	 (@nearMasteryDescriptorId, @nearMasteryTypeId)	 

INSERT INTO [edfi].[PerformanceLevelDescriptor]
           ([PerformanceLevelDescriptorId]
           ,[PerformanceBaseConversionTypeId])
     VALUES
	 (@notMasteredDescriptorId, @notMasteredTypeId)
