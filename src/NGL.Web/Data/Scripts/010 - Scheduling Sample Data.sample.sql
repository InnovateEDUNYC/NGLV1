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
	 (1, 2, 2014, 'Winter 2014',
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

INSERT INTO [edfi].[Course]
	([EducationOrganizationId], [CourseCode], [CourseTitle], [NumberOfParts])
	VALUES
	 (1, 'MATH123 - DI', 'Algebra I', 1)
	 
INSERT INTO [edfi].[Course]
	([EducationOrganizationId], [CourseCode], [CourseTitle], [NumberOfParts])
	VALUES
	 (1, 'MATH123 - CW', 'Algebra I', 1)
	  
INSERT INTO [edfi].[Course]
	([EducationOrganizationId], [CourseCode], [CourseTitle], [NumberOfParts])
	VALUES
	 (1, 'MATH123 - TU', 'Algebra I', 1)
	 
INSERT INTO [edfi].[Course]
	([EducationOrganizationId], [CourseCode], [CourseTitle], [NumberOfParts])
	VALUES
	 (1, 'ENGL400 - DI', 'Creative Writing II', 1)
	 
INSERT INTO [edfi].[Course]
	([EducationOrganizationId], [CourseCode], [CourseTitle], [NumberOfParts])
	VALUES
	 (1, 'ENGL400 - CW', 'Creative Writing II', 1)


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
