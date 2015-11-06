CREATE TABLE [dbo].[Request](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Author] [int] NOT NULL,
	[Description] [text] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_Request] PRIMARY KEY CLUSTERED ([Id] ASC)
 )
GO

ALTER TABLE [dbo].[Request] ADD  CONSTRAINT [FK_Request_User] FOREIGN KEY([Author]) REFERENCES [dbo].[User] ([Id])
GO