CREATE TABLE [dbo].[StaffCertificate](
	[Id] [uniqueidentifier] NOT NULL,
	[StaffUSI] [int] NULL,
	[Number] [int] NOT NULL,
	[Name] [nvarchar](75) NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	CONSTRAINT [PK_StaffCertificate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[StaffCertificate] ADD  CONSTRAINT [DF_StaffCertificate_Id]  DEFAULT (newid()) FOR [Id]
GO

ALTER TABLE [dbo].[StaffCertificate] ADD  DEFAULT (getdate()) FOR [LastModifiedDate]
GO

ALTER TABLE [dbo].[StaffCertificate] ADD  DEFAULT (getdate()) FOR [CreateDate]
GO

ALTER TABLE [dbo].[StaffCertificate]  WITH CHECK ADD  CONSTRAINT [FK_StaffCertificate_Staff] FOREIGN KEY([StaffUSI])
REFERENCES [edfi].[Staff] ([StaffUSI])
GO