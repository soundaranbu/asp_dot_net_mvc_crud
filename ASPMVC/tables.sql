	USE [aspmvc]
GO

/****** Object:  Table [dbo].[users]    Script Date: 4/9/2018 5:37:16 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[users](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NULL DEFAULT (NULL),
	[mobile] [bigint] NULL DEFAULT (NULL),
	[email] [nvarchar](50) NULL DEFAULT (NULL),
	[timecreated] [bigint] NULL DEFAULT (NULL),
	[timemodified] [bigint] NULL DEFAULT (NULL),
	[fullname] [varchar](50) NULL DEFAULT (NULL),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO