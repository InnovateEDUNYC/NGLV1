declare @MasterAdminRoleId nvarchar(256),
		@MasterAdminUserId nvarchar(256)

select  @MasterAdminRoleId = CAST(newid() AS nvarchar(256)), @MasterAdminUserId = CAST(newid() AS nvarchar(256))

INSERT INTO [dbo].[AspNetRoles] ([Id],[Name])
     VALUES (@MasterAdminRoleId, 'Master Admin')
INSERT INTO [dbo].[AspNetRoles] ([Id],[Name])
     VALUES (CAST(newid() AS nvarchar(256)),'Admin')
INSERT INTO [dbo].[AspNetRoles] ([Id],[Name])
     VALUES (CAST(newid() AS nvarchar(256)),'Teacher')
INSERT INTO [dbo].[AspNetRoles] ([Id],[Name])
     VALUES (CAST(newid() AS nvarchar(256)),'Developer')

INSERT INTO [dbo].[AspNetUsers]
           ([Id]
           ,[EmailConfirmed]
           ,[PasswordHash]
           ,[SecurityStamp]
           ,[PhoneNumberConfirmed]
           ,[TwoFactorEnabled]
           ,[LockoutEnabled]
           ,[AccessFailedCount]
           ,[UserName])
     VALUES
           (@MasterAdminUserId,
           0
           ,'ACERoeZ2ERgdwprCeqjS23zfO9mgbwStQi0VUzaqf/t0H3QNltp69K6zaqqkuBlL3A=='
           ,'5fd40d1e-eff1-43be-8f09-d4c30b8ce481'
           ,0
           ,0
           ,0
           ,0
           ,'MasterAdmin')


INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId])
     VALUES (@MasterAdminUserId, @MasterAdminRoleId)