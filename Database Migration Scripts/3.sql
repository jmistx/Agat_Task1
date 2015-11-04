CREATE TABLE [dbo].[Requests](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Author] [int] NOT NULL,
	[Description] [text] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_Requests] PRIMARY KEY CLUSTERED ([Id] ASC)
 )
GO

ALTER TABLE [dbo].[Requests] ADD  CONSTRAINT [FK_Requests_User] FOREIGN KEY([Author]) REFERENCES [dbo].[User] ([Id])
GO