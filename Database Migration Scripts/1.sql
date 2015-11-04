CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](255) NULL,
	[LastName] [nvarchar](255) NULL,
	[Address] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC)
 )
GO