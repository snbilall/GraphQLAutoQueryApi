USE [AkifWorkshop]
GO
/****** Object:  Table [dbo].[Table1]    Script Date: 15.05.2022 19:07:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table1](
	[Id] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[Tbl1Prp1] [int] NULL,
	[Tbl1Prp2] [nvarchar](255) NULL,
	[Tbl1Prp3] [datetime] NULL,
 CONSTRAINT [PK_Table1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table2]    Script Date: 15.05.2022 19:07:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table2](
	[Id] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[Tbl2Prp1] [int] NULL,
	[Tbl2Prp2] [nvarchar](255) NULL,
	[Tbl2Prp3] [datetime] NULL,
	[Table1Id] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Table2] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table3]    Script Date: 15.05.2022 19:07:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table3](
	[Id] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[Tbl3Prp1] [int] NULL,
	[Tbl3Prp2] [nvarchar](255) NULL,
	[Tbl3Prp3] [datetime] NULL,
	[Table2Id] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Table3] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Table1] ([Id], [CreatedAt], [Tbl1Prp1], [Tbl1Prp2], [Tbl1Prp3]) VALUES (N'31549398-092b-49cc-b64b-6862d2700ea1', CAST(N'2022-05-15T16:40:36.230' AS DateTime), 1, N'Table 1 row 1', CAST(N'2022-05-15T16:40:36.230' AS DateTime))
GO
INSERT [dbo].[Table2] ([Id], [CreatedAt], [Tbl2Prp1], [Tbl2Prp2], [Tbl2Prp3], [Table1Id]) VALUES (N'8421035c-e88f-4216-8dc4-296cbe404b4d', CAST(N'2022-05-15T16:40:36.230' AS DateTime), 1, N'Table 1 row 1', CAST(N'2022-05-15T16:40:36.230' AS DateTime), N'31549398-092b-49cc-b64b-6862d2700ea1')
GO
INSERT [dbo].[Table3] ([Id], [CreatedAt], [Tbl3Prp1], [Tbl3Prp2], [Tbl3Prp3], [Table2Id]) VALUES (N'31549398-092b-49cc-b64b-6862d2700ea1', CAST(N'2022-05-15T16:40:36.230' AS DateTime), 1, N'Table 1 row 1', CAST(N'2022-05-15T16:40:36.230' AS DateTime), N'8421035c-e88f-4216-8dc4-296cbe404b4d')
GO
ALTER TABLE [dbo].[Table2]  WITH CHECK ADD  CONSTRAINT [FK_Table2_Table1] FOREIGN KEY([Table1Id])
REFERENCES [dbo].[Table1] ([Id])
GO
ALTER TABLE [dbo].[Table2] CHECK CONSTRAINT [FK_Table2_Table1]
GO
ALTER TABLE [dbo].[Table3]  WITH CHECK ADD  CONSTRAINT [FK_Table3_Table2] FOREIGN KEY([Table2Id])
REFERENCES [dbo].[Table2] ([Id])
GO
ALTER TABLE [dbo].[Table3] CHECK CONSTRAINT [FK_Table3_Table2]
GO
