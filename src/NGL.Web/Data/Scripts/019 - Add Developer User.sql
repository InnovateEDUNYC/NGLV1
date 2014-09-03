declare @DeveloperRoleId nvarchar(256),
		@DeveloperUserId nvarchar(256)

select @DeveloperRoleId = Id from [dbo].[AspNetRoles] where Name ='Developer'
select @DeveloperUserId = CAST(newid() AS nvarchar(256))

INSERT INTO [edfi].[Staff]([StaffUSI],[FirstName],[LastSurname],[HispanicLatinoEthnicity])
     VALUES (9, 'Developer', 'Developer', 0)

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
           (@DeveloperUserId
		   ,9
           ,0
           ,'ACERoeZ2ERgdwprCeqjS23zfO9mgbwStQi0VUzaqf/t0H3QNltp69K6zaqqkuBlL3A=='
           ,'5fd40d1e-eff1-43be-8f09-d4c30b8ce481'
           ,0
           ,0
           ,0
           ,0
           ,'developer')


INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId])
     VALUES (@DeveloperUserId, @DeveloperRoleId)