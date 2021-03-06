USE [master]
GO

CREATE DATABASE [InventorySystemDB]
 
USE [InventorySystemDB]
GO

CREATE TABLE [dbo].[Resources](
	[Culture] [varchar](10) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Value] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserMaster]    Script Date: 7/23/2018 9:26:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserMaster](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](250) NOT NULL,
	[Contact] [varchar](15) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_UserMaster] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Resources] ([Culture], [Name], [Value]) VALUES (N'en-us', N'SaveSuccess', N'Record saved successfully.')
GO
INSERT [dbo].[Resources] ([Culture], [Name], [Value]) VALUES (N'en-us', N'SaveFailed', N'Could not save the record.')
GO
INSERT [dbo].[Resources] ([Culture], [Name], [Value]) VALUES (N'en-us', N'DeleteSuccess', N'Record deleted successfully.')
GO
INSERT [dbo].[Resources] ([Culture], [Name], [Value]) VALUES (N'en-us', N'DeleteFailed', N'Could not delete the record.')
GO
INSERT [dbo].[Resources] ([Culture], [Name], [Value]) VALUES (N'en-us', N'ServerError', N'Something went wrong.')
GO
SET IDENTITY_INSERT [dbo].[UserMaster] ON 
GO
INSERT [dbo].[UserMaster] ([UserId], [UserName], [FirstName], [LastName], [Email], [Contact], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (1, N'viramk7', N'Viram', N'Keshwala', N'viramk7@gmail.com', N'9737873135', -1, CAST(N'2018-07-23T00:00:00.000' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[UserMaster] ([UserId], [UserName], [FirstName], [LastName], [Email], [Contact], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (2, N'meshwajani', N'Meshwa', N'Jani', N'meshwajani@gmail.com', N'987654210', -1, CAST(N'2018-07-01T00:00:00.000' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[UserMaster] OFF
GO
/****** Object:  StoredProcedure [dbo].[USP_UserMaster_GetUsers]    Script Date: 7/23/2018 9:26:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*************************************************
USP_UserMaster_GetUsers
USP_UserMaster_GetUsers 1 
*************************************************/
CREATE PROC [dbo].[USP_UserMaster_GetUsers]
@UserId INT = NULL
AS
BEGIN

	SELECT [UserId]
		  ,[UserName]
		  ,[FirstName]
		  ,[LastName]
		  ,[Email]
		  ,[Contact]
		  ,[CreatedBy]
		  ,[CreatedDate]
		  ,[ModifiedBy]
		  ,[ModifiedDate]
	FROM 
		[dbo].[UserMaster]
	WHERE
		UserId = @UserId OR @UserId IS NULL

END
GO
USE [master]
GO
ALTER DATABASE [InventorySystemDB] SET  READ_WRITE 
GO
