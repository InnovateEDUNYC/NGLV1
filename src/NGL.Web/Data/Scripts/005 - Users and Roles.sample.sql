/* John Smith - Admin */
declare @AdminRoleId nvarchar(256),
		@JohnSmithUserId nvarchar(256)

select @AdminRoleId = Id From [dbo].[AspNetRoles] Where Name = 'Admin'
select @JohnSmithUserId = CAST(newid() AS nvarchar(256))

INSERT INTO [edfi].[Staff]([StaffUSI],[FirstName],[LastSurname],[HispanicLatinoEthnicity])
     VALUES (2, 'John', 'Smith', 0)

INSERT INTO [dbo].[AspNetUsers]
           ([Id]
		   ,[StaffUSI]
           ,[EmailConfirmed]
           ,[PasswordHash]
           ,[SecurityStamp]
           ,[PhoneNumberConfirmed]
           ,[TwoFactorEnabled]
           ,[LockoutEnabled]
           ,[AccessFailedCount]
           ,[UserName])
     VALUES
           (@JohnSmithUserId
		   ,2
           ,0
           ,'ACERoeZ2ERgdwprCeqjS23zfO9mgbwStQi0VUzaqf/t0H3QNltp69K6zaqqkuBlL3A=='
           ,'5fd40d1e-eff1-43be-8f09-d4c30b8ce481'
           ,0
           ,0
           ,0
           ,0
           ,'JohnSmith')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId])
     VALUES (@JohnSmithUserId, @AdminRoleId)

/* Hellen Smith - Admin */
declare @TeacherRoleId nvarchar(256),
		@HellenSmithUserId nvarchar(256)

select @TeacherRoleId = Id From [dbo].[AspNetRoles] Where Name = 'Teacher'
select @HellenSmithUserId = CAST(newid() AS nvarchar(256))

INSERT INTO [edfi].[Staff]([StaffUSI],[FirstName],[LastSurname],[HispanicLatinoEthnicity])
     VALUES (3, 'Hellen', 'Smith', 0)

INSERT INTO [dbo].[AspNetUsers]
           ([Id]
		   ,[StaffUSI]
           ,[EmailConfirmed]
           ,[PasswordHash]
           ,[SecurityStamp]
           ,[PhoneNumberConfirmed]
           ,[TwoFactorEnabled]
           ,[LockoutEnabled]
           ,[AccessFailedCount]
           ,[UserName])
     VALUES
           (@HellenSmithUserId
		   ,3
		   ,0
           ,'ACERoeZ2ERgdwprCeqjS23zfO9mgbwStQi0VUzaqf/t0H3QNltp69K6zaqqkuBlL3A=='
           ,'5fd40d1e-eff1-43be-8f09-d4c30b8ce481'
           ,0
           ,0
           ,0
           ,0
           ,'HellenSmith')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId])
     VALUES (@HellenSmithUserId, @TeacherRoleId)