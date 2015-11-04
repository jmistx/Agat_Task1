CREATE TABLE [dbo].[Address](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[User] [int] NOT NULL,
	[City] [nvarchar](255) NULL,
	[Street] [nvarchar](255) NULL,
	[BuildingNum] [nvarchar](50) NULL,
	[ApartmentNum] [nvarchar](50) NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED ([Id] ASC)
 )
GO

ALTER TABLE [dbo].[Address] ADD CONSTRAINT [FK_Address_User] FOREIGN KEY([User]) REFERENCES [dbo].[User] ([Id])
GO