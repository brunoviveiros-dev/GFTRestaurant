CREATE DATABASE [GFTRestaurant]
GO

CREATE TABLE [GFTRestaurant].[dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Detail] [nvarchar](max) NULL,
PRIMARY KEY ([Id]))
GO