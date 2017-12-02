-- ***** Parent ******

USE [ell]
GO

/****** Object:  Table [dbo].[Parent]    Script Date: 02/12/2017 01:17:35 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Parent](
	[Id] [int] NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[Phone] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- ***** Student ******
USE [ell]
GO

/****** Object:  Table [dbo].[Student]    Script Date: 02/12/2017 01:19:41 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Student](
	[Id] [int] NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](500) NULL,
	[Picture] [nvarchar](500) NULL,
	[BirthDate] [date] NULL,
	[Gender] [int] NOT NULL,
	[Phone] [nvarchar](100) NULL,
	[ReferenceNumber] [int] NULL,
	[ParentId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Student] ADD  DEFAULT ((0)) FOR [Gender]
GO

ALTER TABLE [dbo].[Student]  WITH CHECK ADD FOREIGN KEY([ParentId])
REFERENCES [dbo].[Parent] ([Id])
GO

-- ***** Payment ******
USE [ell]
GO

/****** Object:  Table [dbo].[Payment]    Script Date: 02/12/2017 01:20:16 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Payment](
	[Id] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
	[Amount] [decimal](19, 4) NOT NULL,
	[Description] [nvarchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Payment] ADD  DEFAULT ((0)) FOR [Amount]
GO

ALTER TABLE [dbo].[Payment]  WITH CHECK ADD FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO


