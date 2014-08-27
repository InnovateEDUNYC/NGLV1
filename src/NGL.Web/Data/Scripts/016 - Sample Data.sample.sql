INSERT INTO [edfi].[Session] 
	([SchoolId], [TermTypeId] ,[SchoolYear], [SessionName],
     [BeginDate] ,[EndDate] ,[TotalInstructionalDays])
	VALUES
	 (1, 1, 2014, 'Fall 2014',
	 '09/09/2014', '01/21/2015', 100)
	 
INSERT INTO [edfi].[Session] 
	([SchoolId], [TermTypeId] ,[SchoolYear], [SessionName],
     [BeginDate] ,[EndDate] ,[TotalInstructionalDays])
	 VALUES
	 (1, 2, 2014, 'Spring 2015',
	 '01/22/2015', '06/20/2015', 100)

INSERT INTO [edfi].[Location]
	([SchoolId], [ClassroomIdentificationCode])
	VALUES
	 (1, 'Room 207')

INSERT INTO [edfi].[Location]
	([SchoolId], [ClassroomIdentificationCode])
	VALUES
	 (1, 'Room 108')

INSERT INTO [edfi].[ClassPeriod]
	([SchoolId], [ClassPeriodName])
	VALUES
	 (1, 'Period 1')

INSERT INTO [edfi].[ClassPeriod]
	([SchoolId], [ClassPeriodName])
	VALUES
	 (1, 'Period 2')

INSERT INTO [edfi].[ClassPeriod]
	([SchoolId], [ClassPeriodName])
	VALUES
	 (1, 'Period 3')

INSERT INTO [edfi].[ClassPeriod]
	([SchoolId], [ClassPeriodName])
	VALUES
	 (1, 'Period 4')

INSERT INTO [edfi].[ClassPeriod]
	([SchoolId], [ClassPeriodName])
	VALUES
	 (1, 'Period 5')

INSERT INTO [dbo].[ParentCourse]
	(	[EducationOrganizationId],
	[ParentCourseCode],
	[ParentCourseTitle], [Id])
	VALUES 
	(1, 'MATH123', 'Algebra I', 'F43C1E50-1FEA-4D11-B98E-3DBA89999F18'),
	(1, 'ENGL400', 'Creative Writing II', 'F43C1E50-1FEA-4D11-B98E-3DBA8AB22F18')

declare @math123parentCourseid uniqueidentifier
declare @engl400parentCourseId uniqueidentifier

select @math123parentCourseid = Id from [dbo].[ParentCourse] where ParentCourseCode like 'MATH123'
select @engl400parentCourseid = Id from [dbo].[ParentCourse] where ParentCourseCode like 'ENGL400'

INSERT INTO [edfi].[Course]
	([EducationOrganizationId], [CourseCode], [CourseTitle], [NumberOfParts], [AcademicSubjectDescriptorId], [ParentCourseId])
	VALUES
	 (1, 'MATH123 - DI', 'Algebra I', 1, 1, @math123parentCourseid),
	 (1, 'MATH123 - CW', 'Algebra I', 1, 2, @math123parentCourseid),
	 (1, 'MATH123 - TU', 'Algebra I', 1, 3, @math123parentCourseid),
	 (1, 'ENGL400 - DI', 'Creative Writing II', 1, 4, @engl400parentCourseid),
	 (1, 'ENGL400 - CW', 'Creative Writing II', 1, 4, @engl400parentCourseid)


INSERT INTO [edfi].[CourseOffering]
	([SchoolId], [TermTypeId], [SchoolYear], [EducationOrganizationId],
	 [LocalCourseCode], [LocalCourseTitle], [CourseCode])
	VALUES
	 (1, 1, 2014, 1,
	  'MATH123 - DI', 'Algebra I DI Fall 2014', 'MATH123 - DI')
	  
INSERT INTO [edfi].[CourseOffering]
	([SchoolId], [TermTypeId], [SchoolYear], [EducationOrganizationId],
	 [LocalCourseCode], [LocalCourseTitle], [CourseCode])
	VALUES
	 (1, 1, 2014, 1,
	  'MATH123 - CW', 'Algebra I CW Fall 2014', 'MATH123 - CW')

INSERT INTO [edfi].[CourseOffering]
	([SchoolId], [TermTypeId], [SchoolYear], [EducationOrganizationId],
	 [LocalCourseCode], [LocalCourseTitle], [CourseCode])
	VALUES
	 (1, 1, 2014, 1,
	  'MATH123 - TU', 'Algebra I TU Fall 2014', 'MATH123 - TU')

INSERT INTO [edfi].[CourseOffering]
	([SchoolId], [TermTypeId], [SchoolYear], [EducationOrganizationId],
	 [LocalCourseCode], [LocalCourseTitle], [CourseCode])
	VALUES
	 (1, 1, 2014, 1,
	  'ENGL400 - DI', 'Creative Writing II DI Fall 2014', 'ENGL400 - DI')

INSERT INTO [edfi].[CourseOffering]
	([SchoolId], [TermTypeId], [SchoolYear], [EducationOrganizationId],
	 [LocalCourseCode], [LocalCourseTitle], [CourseCode])
	VALUES
	 (1, 1, 2014, 1,
	  'ENGL400 - CW', 'Creative Writing II CW Fall 2014', 'ENGL400 - CW')

INSERT INTO [edfi].[CourseOffering]
	([SchoolId], [TermTypeId], [SchoolYear], [EducationOrganizationId],
	 [LocalCourseCode], [LocalCourseTitle], [CourseCode])
	VALUES
	 (1, 2, 2014, 1,
	  'ENGL400 - CW', 'Creative Writing II CW Spring 2015', 'ENGL400 - CW')
	  
/* MATH123 - SECTION 1 */
INSERT INTO [edfi].[Section]
	([SchoolId], [TermTypeId], [SchoolYear], [LocalCourseCode], 
	 [ClassPeriodName], [ClassroomIdentificationCode], [UniqueSectionCode], [SequenceOfCourse])
	VALUES
	 (1, 1, 2014, 'MATH123 - DI',
	 'Period 1', 'Room 207', 'MATH123-Fall2014-001', 1)

INSERT INTO [edfi].[Section]
	([SchoolId], [TermTypeId], [SchoolYear], [LocalCourseCode], 
	 [ClassPeriodName], [ClassroomIdentificationCode], [UniqueSectionCode], [SequenceOfCourse])
	VALUES
	 (1, 1, 2014, 'MATH123 - CW',
	 'Period 1', 'Room 207', 'MATH123-Fall2014-001', 1)

INSERT INTO [edfi].[Section]
	([SchoolId], [TermTypeId], [SchoolYear], [LocalCourseCode], 
	 [ClassPeriodName], [ClassroomIdentificationCode], [UniqueSectionCode], [SequenceOfCourse])
	VALUES
	 (1, 1, 2014, 'MATH123 - TU',
	 'Period 1', 'Room 207', 'MATH123-Fall2014-001', 1)

/* MATH123 - SECTION 2 */
INSERT INTO [edfi].[Section]
	([SchoolId], [TermTypeId], [SchoolYear], [LocalCourseCode], 
	 [ClassPeriodName], [ClassroomIdentificationCode], [UniqueSectionCode], [SequenceOfCourse])
	VALUES
	 (1, 1, 2014, 'MATH123 - DI',
	 'Period 2', 'Room 108', 'MATH123-Fall2014-002', 1)

INSERT INTO [edfi].[Section]
	([SchoolId], [TermTypeId], [SchoolYear], [LocalCourseCode], 
	 [ClassPeriodName], [ClassroomIdentificationCode], [UniqueSectionCode], [SequenceOfCourse])
	VALUES
	 (1, 1, 2014, 'MATH123 - CW',
	 'Period 2', 'Room 108', 'MATH123-Fall2014-002', 1)

INSERT INTO [edfi].[Section]
	([SchoolId], [TermTypeId], [SchoolYear], [LocalCourseCode], 
	 [ClassPeriodName], [ClassroomIdentificationCode], [UniqueSectionCode], [SequenceOfCourse])
	VALUES
	 (1, 1, 2014, 'MATH123 - TU',
	 'Period 2', 'Room 108', 'MATH123-Fall2014-002', 1)

INSERT INTO [edfi].[Section]
	([SchoolId], [TermTypeId], [SchoolYear], [LocalCourseCode], 
	 [ClassPeriodName], [ClassroomIdentificationCode], [UniqueSectionCode], [SequenceOfCourse])
	VALUES
	 (1, 1, 2014, 'ENGL400 - DI',
	 'Period 3', 'Room 207', 'ENGL400-Fall2014-001', 1)

INSERT INTO [edfi].[Section]
	([SchoolId], [TermTypeId], [SchoolYear], [LocalCourseCode], 
	 [ClassPeriodName], [ClassroomIdentificationCode], [UniqueSectionCode], [SequenceOfCourse])
	VALUES
	 (1, 1, 2014, 'ENGL400 - CW',
	 'Period 3', 'Room 207', 'ENGL400-Fall2014-001', 1)

INSERT INTO [edfi].[Section]
	([SchoolId], [TermTypeId], [SchoolYear], [LocalCourseCode], 
	 [ClassPeriodName], [ClassroomIdentificationCode], [UniqueSectionCode], [SequenceOfCourse])
	VALUES
	 (1, 1, 2014, 'ENGL400 - DI',
	 'Period 4', 'Room 207', 'ENGL400-Fall2014-001', 1)

INSERT INTO [edfi].[Section]
	([SchoolId], [TermTypeId], [SchoolYear], [LocalCourseCode], 
	 [ClassPeriodName], [ClassroomIdentificationCode], [UniqueSectionCode], [SequenceOfCourse])
	VALUES
	 (1, 1, 2014, 'ENGL400 - CW',
	 'Period 4', 'Room 207', 'ENGL400-Fall2014-001', 1)

INSERT INTO [edfi].[Section]
	([SchoolId], [TermTypeId], [SchoolYear], [LocalCourseCode], 
	 [ClassPeriodName], [ClassroomIdentificationCode], [UniqueSectionCode], [SequenceOfCourse])
	VALUES
	 (1, 2, 2014, 'ENGL400 - CW',
	 'Period 4', 'Room 207', 'ENGL400-Spring2015-001', 1)


INSERT INTO [edfi].[Student]
           ([StudentUSI]
           ,[FirstName]
           ,[LastSurname]
           ,[SexTypeId]
           ,[BirthDate]
           ,[HispanicLatinoEthnicity])
     VALUES
           (999
           ,'Cameron'
           ,'James'
           ,1
           ,'12/12/1955'
           ,1)

INSERT INTO [edfi].[Student]
           ([StudentUSI]
           ,[FirstName]
           ,[LastSurname]
           ,[SexTypeId]
           ,[BirthDate]
           ,[HispanicLatinoEthnicity])
     VALUES
           (1000
           ,'Michael'
           ,'Jordan'
           ,1
           ,'2/12/1980'
           ,0)

INSERT INTO [edfi].[StudentRace]
			([StudentUSI],
			[RaceTypeId])
	VALUES
		(999, 2)
		
INSERT INTO [edfi].[StudentRace]
			([StudentUSI],
			[RaceTypeId])
	VALUES
		(1000, 2)

INSERT INTO [edfi].[StudentLanguage]
			([StudentUSI],
			[LanguageDescriptorId])
	VALUES
		(999, 165)

INSERT INTO [edfi].[StudentLanguage]
			([StudentUSI],
			[LanguageDescriptorId])
	VALUES
		(1000, 165)

INSERT INTO [edfi].[StudentLanguageUse]
			([StudentUSI],
			[LanguageDescriptorId],
			[LanguageUseTypeId])
	VALUES
		(999, 165, 1)

INSERT INTO [edfi].[StudentLanguageUse]
			([StudentUSI],
			[LanguageDescriptorId],
			[LanguageUseTypeId])
	VALUES
		(1000, 165, 1)

INSERT INTO [edfi].[StudentAddress]
			([StudentUSI],
			[AddressTypeId],
			[StreetNumberName],
			[ApartmentRoomSuiteNumber],
			[City],
			[StateAbbreviationTypeId],
			[PostalCode])
	VALUES
		(999, 1, '123 fake st', '1', 'Chicago', 23, '60664')

INSERT INTO [edfi].[StudentAddress]
			([StudentUSI],
			[AddressTypeId],
			[StreetNumberName],
			[ApartmentRoomSuiteNumber],
			[City],
			[StateAbbreviationTypeId],
			[PostalCode])
	VALUES
		(1000, 1, '1234 fake st', '1', 'NYC', 21, '32314')

INSERT INTO [edfi].[Parent]
		   ([FirstName]
           ,[LastSurname]
           ,[SexTypeId])
	VALUES
	('Jake', 'Goob', 1)

INSERT INTO [edfi].[Parent]
		   ([FirstName]
           ,[LastSurname]
           ,[SexTypeId])
	VALUES
	('Jill', 'Cook', 1)

declare @jakeparentusi int
declare @jillparentusi int

select @jakeparentusi = ParentUSI from [edfi].[Parent] where FirstName like 'Jake'
select @jillparentusi = ParentUSI from [edfi].[Parent] where FirstName like 'Jill'

INSERT INTO [edfi].[StudentParentAssociation]
           ([StudentUSI]
           ,[ParentUSI]
           ,[RelationTypeId]
           ,[LivesWith])
	VALUES
	(999, @jakeparentusi, 1, 1)

INSERT INTO [edfi].[StudentParentAssociation]
           ([StudentUSI]
           ,[ParentUSI]
           ,[RelationTypeId]
           ,[LivesWith])
	VALUES
	(1000, @jillparentusi, 1, 1)

INSERT INTO [edfi].[ParentTelephone]
           ([ParentUSI]
           ,[TelephoneNumberTypeId]
           ,[TelephoneNumber])
	VALUES
	(@jakeparentusi, 1, '123421')

INSERT INTO [edfi].[ParentTelephone]
           ([ParentUSI]
           ,[TelephoneNumberTypeId]
           ,[TelephoneNumber])
	VALUES
	(@jillparentusi, 1, '123423421')

INSERT INTO [edfi].[StudentSectionAssociation]
           ([StudentUSI]
           ,[SchoolId]
           ,[ClassPeriodName]
           ,[ClassroomIdentificationCode]
           ,[LocalCourseCode]
           ,[TermTypeId]
           ,[SchoolYear]
           ,[BeginDate]
           ,[EndDate])
     VALUES
           (999, 1, 'Period 3', 'Room 207', 'ENGL400 - DI', 1, 2014, '2014-06-09', '2015-01-21'),
		   (1000, 1, 'Period 3', 'Room 207', 'ENGL400 - DI', 1, 2014, '2014-06-09', '2015-01-21')