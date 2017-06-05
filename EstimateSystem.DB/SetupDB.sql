
CREATE DATABASE [EstimateDB]
GO

USE [EstimateDB]
GO

/****** Object:  Table [dbo].[BrandMaster]    Script Date: 05-06-2017 08:14:09 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[BrandMaster](
	[BrandID] [int] IDENTITY(1,1) NOT NULL,
	[Brand_Name] [varchar](200) NOT NULL,
	[Client_ID] [int] NOT NULL,
 CONSTRAINT [PK_BrandMaster] PRIMARY KEY CLUSTERED 
(
	[BrandID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_BrandMaster] UNIQUE NONCLUSTERED 
(
	[Brand_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[BrandMaster]  WITH CHECK ADD  CONSTRAINT [FK_BrandMaster_ClientMaster] FOREIGN KEY([Client_ID])
REFERENCES [dbo].[ClientMaster] ([ClientID])
GO


USE [EstimateDB]
GO

/****** Object:  Table [dbo].[CaptionMaster]    Script Date: 05-06-2017 08:17:13 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CaptionMaster](
	[CaptionID] [int] IDENTITY(1,1) NOT NULL,
	[Caption] [varchar](200) NOT NULL,
	[BrandID] [int] NOT NULL,
 CONSTRAINT [PK_CaptionMaster] PRIMARY KEY CLUSTERED 
(
	[CaptionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_CaptionMaster] UNIQUE NONCLUSTERED 
(
	[Caption] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[CaptionMaster]  WITH CHECK ADD  CONSTRAINT [FK_CaptionMaster_BrandMaster] FOREIGN KEY([BrandID])
REFERENCES [dbo].[BrandMaster] ([BrandID])
GO

ALTER TABLE [dbo].[CaptionMaster] CHECK CONSTRAINT [FK_CaptionMaster_BrandMaster]
GO


USE [EstimateDB]
GO

/****** Object:  Table [dbo].[ClientMaster]    Script Date: 05-06-2017 08:17:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ClientMaster](
	[ClientID] [int] IDENTITY(1,1) NOT NULL,
	[Client_Name] [varchar](200) NOT NULL,
 CONSTRAINT [PK_ClientMaster] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_ClientMaster] UNIQUE NONCLUSTERED 
(
	[Client_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


USE [EstimateDB]
GO

/****** Object:  Table [dbo].[EstimateEdition]    Script Date: 05-06-2017 08:17:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[EstimateEdition](
	[EST_EditionID] [int] IDENTITY(1,1) NOT NULL,
	[EST_PUBID] [int] NOT NULL,
	[EST_ID] [int] NOT NULL,
	[Edition] [varchar](200) NOT NULL,
	[Height] [decimal](18, 0) NOT NULL,
	[Weidth] [decimal](18, 0) NOT NULL,
	[Total_Size] [decimal](18, 0) NOT NULL,
	[Rate] [decimal](18, 0) NOT NULL,
	[NoOfInsertion] [int] NOT NULL,
	[Total_Cost] [decimal](18, 0) NOT NULL,
	[Agency_Discount] [decimal](18, 0) NOT NULL,
	[Total_NetCost] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_EstimateEdition] PRIMARY KEY CLUSTERED 
(
	[EST_EditionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[EstimateEdition]  WITH CHECK ADD  CONSTRAINT [FK_EstimateEdition_EstimateHeader] FOREIGN KEY([EST_ID])
REFERENCES [dbo].[EstimateHeader] ([EST_ID])
GO

ALTER TABLE [dbo].[EstimateEdition] CHECK CONSTRAINT [FK_EstimateEdition_EstimateHeader]
GO

ALTER TABLE [dbo].[EstimateEdition]  WITH CHECK ADD  CONSTRAINT [FK_EstimateEdition_EstimatePublication] FOREIGN KEY([EST_PUBID])
REFERENCES [dbo].[EstimatePublication] ([EST_PUBID])
GO

ALTER TABLE [dbo].[EstimateEdition] CHECK CONSTRAINT [FK_EstimateEdition_EstimatePublication]
GO


USE [EstimateDB]
GO

/****** Object:  Table [dbo].[EstimateHeader]    Script Date: 05-06-2017 08:17:40 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[EstimateHeader](
	[EST_ID] [int] IDENTITY(1,1) NOT NULL,
	[EST_NO] [varchar](50) NOT NULL,
	[EST_Date] [datetime] NOT NULL,
	[Campaign] [varchar](200) NOT NULL,
	[Agency] [varchar](50) NOT NULL,
	[PO_NO] [varchar](50) NOT NULL,
	[PO_Date] [datetime] NOT NULL,
	[ClientID] [int] NOT NULL,
	[BrandID] [int] NOT NULL,
	[PeriodFrom] [datetime] NOT NULL,
	[PeriodTo] [datetime] NOT NULL,
	[SAC_PER] [decimal](18, 0) NOT NULL,
	[AAC_PER] [decimal](18, 0) NOT NULL,
	[Gross_Cost] [decimal](18, 0) NOT NULL,
	[Net_Cost] [decimal](18, 0) NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_EstimateHeader] PRIMARY KEY CLUSTERED 
(
	[EST_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_EstimateHeader] UNIQUE NONCLUSTERED 
(
	[EST_NO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[EstimateHeader]  WITH CHECK ADD  CONSTRAINT [FK_EstimateHeader_BrandMaster] FOREIGN KEY([BrandID])
REFERENCES [dbo].[BrandMaster] ([BrandID])
GO

ALTER TABLE [dbo].[EstimateHeader] CHECK CONSTRAINT [FK_EstimateHeader_BrandMaster]
GO

ALTER TABLE [dbo].[EstimateHeader]  WITH CHECK ADD  CONSTRAINT [FK_EstimateHeader_ClientMaster] FOREIGN KEY([ClientID])
REFERENCES [dbo].[ClientMaster] ([ClientID])
GO

ALTER TABLE [dbo].[EstimateHeader] CHECK CONSTRAINT [FK_EstimateHeader_ClientMaster]
GO


USE [EstimateDB]
GO

/****** Object:  Table [dbo].[EstimatePublication]    Script Date: 05-06-2017 08:17:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[EstimatePublication](
	[EST_PUBID] [int] IDENTITY(1,1) NOT NULL,
	[EST_Publication] [varchar](200) NOT NULL,
	[EST_ID] [int] NOT NULL,
	[Pub_Language] [varchar](200) NOT NULL,
	[Total_Edition] [int] NOT NULL,
	[Rate] [decimal](18, 0) NOT NULL,
	[Total_Insertion] [int] NOT NULL,
	[Total_Cost] [decimal](18, 0) NOT NULL,
	[Agency_Discount] [decimal](18, 0) NOT NULL,
	[Total_NetCost] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_EstimatePublication] PRIMARY KEY CLUSTERED 
(
	[EST_PUBID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[EstimatePublication]  WITH CHECK ADD  CONSTRAINT [FK_EstimatePublication_EstimateHeader] FOREIGN KEY([EST_ID])
REFERENCES [dbo].[EstimateHeader] ([EST_ID])
GO

ALTER TABLE [dbo].[EstimatePublication] CHECK CONSTRAINT [FK_EstimatePublication_EstimateHeader]
GO


USE [EstimateDB]
GO

/****** Object:  Table [dbo].[EstimateScheduled]    Script Date: 05-06-2017 08:17:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[EstimateScheduled](
	[EST_SchID] [int] IDENTITY(1,1) NOT NULL,
	[EST_EditionID] [int] NOT NULL,
	[EST_PUBID] [int] NOT NULL,
	[EST_ID] [int] NOT NULL,
	[Scheduled_Date] [datetime] NOT NULL,
	[CaptionID] [int] NOT NULL,
	[Language] [varchar](200) NOT NULL,
	[Height] [decimal](18, 0) NOT NULL,
	[Weidth] [decimal](18, 0) NOT NULL,
	[Total_Size] [decimal](18, 0) NOT NULL,
	[Rate] [decimal](18, 0) NOT NULL,
	[NoOfInsertion] [int] NOT NULL,
	[Total_Cost] [decimal](18, 0) NOT NULL,
	[Agency_Discount] [decimal](18, 0) NOT NULL,
	[Total_NetCost] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_EstimateScheduled] PRIMARY KEY CLUSTERED 
(
	[EST_SchID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[EstimateScheduled]  WITH CHECK ADD  CONSTRAINT [FK_EstimateScheduled_CaptionMaster] FOREIGN KEY([CaptionID])
REFERENCES [dbo].[CaptionMaster] ([CaptionID])
GO

ALTER TABLE [dbo].[EstimateScheduled] CHECK CONSTRAINT [FK_EstimateScheduled_CaptionMaster]
GO

ALTER TABLE [dbo].[EstimateScheduled]  WITH CHECK ADD  CONSTRAINT [FK_EstimateScheduled_EstimateEdition] FOREIGN KEY([EST_EditionID])
REFERENCES [dbo].[EstimateEdition] ([EST_EditionID])
GO

ALTER TABLE [dbo].[EstimateScheduled] CHECK CONSTRAINT [FK_EstimateScheduled_EstimateEdition]
GO

ALTER TABLE [dbo].[EstimateScheduled]  WITH CHECK ADD  CONSTRAINT [FK_EstimateScheduled_EstimateHeader] FOREIGN KEY([EST_ID])
REFERENCES [dbo].[EstimateHeader] ([EST_ID])
GO

ALTER TABLE [dbo].[EstimateScheduled] CHECK CONSTRAINT [FK_EstimateScheduled_EstimateHeader]
GO

ALTER TABLE [dbo].[EstimateScheduled]  WITH CHECK ADD  CONSTRAINT [FK_EstimateScheduled_EstimatePublication] FOREIGN KEY([EST_PUBID])
REFERENCES [dbo].[EstimatePublication] ([EST_PUBID])
GO

ALTER TABLE [dbo].[EstimateScheduled] CHECK CONSTRAINT [FK_EstimateScheduled_EstimatePublication]
GO



