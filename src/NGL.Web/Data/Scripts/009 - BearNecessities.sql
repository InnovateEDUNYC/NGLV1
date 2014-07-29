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

