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
           (CAST(newid() AS nvarchar(256)),
           0
           ,'ACERoeZ2ERgdwprCeqjS23zfO9mgbwStQi0VUzaqf/t0H3QNltp69K6zaqqkuBlL3A=='
           ,'5fd40d1e-eff1-43be-8f09-d4c30b8ce481'
           ,0
           ,0
           ,0
           ,0
           ,'JohnSmith')