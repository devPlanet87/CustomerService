USE [ServiceVault]
GO
/****** Object:  Table [dbo].[CustomerInfo]    Script Date: 22-02-2026 23:53:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerInfo](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](100) NOT NULL,
	[NickName] [nvarchar](50) NULL,
	[MobileNumber] [nvarchar](15) NULL,
	[AlternateNumber] [nvarchar](15) NULL,
	[Address] [nvarchar](max) NULL,
	[Relationship] [nvarchar](500) NULL,
	[Notes] [nvarchar](max) NULL,
	[ImagePath] [nvarchar](250) NULL,
	[MapLocation] [nvarchar](max) NULL,
	[CreatedDateTime] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[UpdatedDateTime] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerServices]    Script Date: 22-02-2026 23:53:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerServices](
	[CustomerServiceId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[MobileNumber] [nvarchar](15) NULL,
	[Location] [nvarchar](250) NULL,
	[ProductId] [int] NOT NULL,
	[ProductsDetail] [nvarchar](max) NULL,
	[ProductOrWarrantyImage] [nvarchar](250) NULL,
	[Remarks] [nvarchar](max) NULL,
	[CreatedDateTime] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[UpdatedDateTime] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 22-02-2026 23:53:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[Category] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
	[CreatedDateTime] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[UpdatedDateTime] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CustomerInfo] ON 
GO
INSERT [dbo].[CustomerInfo] ([CustomerId], [CustomerName], [NickName], [MobileNumber], [AlternateNumber], [Address], [Relationship], [Notes], [ImagePath], [MapLocation], [CreatedDateTime], [CreatedBy], [UpdatedDateTime], [UpdatedBy]) VALUES (1, N'Arun', NULL, N'9865768790', NULL, N'3, veda street, Tiruvannamalai.', N'Tvm friend. Ravi frnd dubai arun. He working lathe machine work', NULL, NULL, NULL, CAST(N'2026-02-21T23:27:42.4500000' AS DateTime2), N'Admin', NULL, NULL)
GO
INSERT [dbo].[CustomerInfo] ([CustomerId], [CustomerName], [NickName], [MobileNumber], [AlternateNumber], [Address], [Relationship], [Notes], [ImagePath], [MapLocation], [CreatedDateTime], [CreatedBy], [UpdatedDateTime], [UpdatedBy]) VALUES (2, N'Sathish', NULL, N'8428407191', NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2026-02-22T23:27:01.8366667' AS DateTime2), N'Admin', CAST(N'2026-02-22T23:27:01.8374326' AS DateTime2), NULL)
GO
INSERT [dbo].[CustomerInfo] ([CustomerId], [CustomerName], [NickName], [MobileNumber], [AlternateNumber], [Address], [Relationship], [Notes], [ImagePath], [MapLocation], [CreatedDateTime], [CreatedBy], [UpdatedDateTime], [UpdatedBy]) VALUES (3, N'Ramkumar', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2026-02-22T23:32:50.1266667' AS DateTime2), N'Admin', CAST(N'2026-02-22T23:32:50.1272377' AS DateTime2), NULL)
GO
INSERT [dbo].[CustomerInfo] ([CustomerId], [CustomerName], [NickName], [MobileNumber], [AlternateNumber], [Address], [Relationship], [Notes], [ImagePath], [MapLocation], [CreatedDateTime], [CreatedBy], [UpdatedDateTime], [UpdatedBy]) VALUES (4, N'Suresh', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2026-02-22T23:33:08.2866667' AS DateTime2), N'Admin', CAST(N'2026-02-22T23:33:08.2878289' AS DateTime2), NULL)
GO
INSERT [dbo].[CustomerInfo] ([CustomerId], [CustomerName], [NickName], [MobileNumber], [AlternateNumber], [Address], [Relationship], [Notes], [ImagePath], [MapLocation], [CreatedDateTime], [CreatedBy], [UpdatedDateTime], [UpdatedBy]) VALUES (5, N'Rama Subbu', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2026-02-22T23:33:33.2000000' AS DateTime2), N'Admin', CAST(N'2026-02-22T23:33:33.2032227' AS DateTime2), NULL)
GO
INSERT [dbo].[CustomerInfo] ([CustomerId], [CustomerName], [NickName], [MobileNumber], [AlternateNumber], [Address], [Relationship], [Notes], [ImagePath], [MapLocation], [CreatedDateTime], [CreatedBy], [UpdatedDateTime], [UpdatedBy]) VALUES (6, N'AVR durai', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2026-02-22T23:33:50.5300000' AS DateTime2), N'Admin', CAST(N'2026-02-22T23:33:50.5334689' AS DateTime2), NULL)
GO
INSERT [dbo].[CustomerInfo] ([CustomerId], [CustomerName], [NickName], [MobileNumber], [AlternateNumber], [Address], [Relationship], [Notes], [ImagePath], [MapLocation], [CreatedDateTime], [CreatedBy], [UpdatedDateTime], [UpdatedBy]) VALUES (7, N'Udhya', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2026-02-22T23:34:08.3666667' AS DateTime2), N'Admin', CAST(N'2026-02-22T23:34:08.3682781' AS DateTime2), NULL)
GO
SET IDENTITY_INSERT [dbo].[CustomerInfo] OFF
GO
SET IDENTITY_INSERT [dbo].[CustomerServices] ON 
GO
INSERT [dbo].[CustomerServices] ([CustomerServiceId], [CustomerId], [MobileNumber], [Location], [ProductId], [ProductsDetail], [ProductOrWarrantyImage], [Remarks], [CreatedDateTime], [CreatedBy], [UpdatedDateTime], [UpdatedBy]) VALUES (1, 1, N'9876543210', N'Chennai - Anna Nagar', 1, N'Exide Battery 150Ah, Installed Jan 2026', N'images/battery_warranty.jpg', N'Customer requested routine checkup', CAST(N'2026-02-21T23:47:09.2247867' AS DateTime2), N'Admin', CAST(N'2026-02-21T23:47:09.2247867' AS DateTime2), NULL)
GO
INSERT [dbo].[CustomerServices] ([CustomerServiceId], [CustomerId], [MobileNumber], [Location], [ProductId], [ProductsDetail], [ProductOrWarrantyImage], [Remarks], [CreatedDateTime], [CreatedBy], [UpdatedDateTime], [UpdatedBy]) VALUES (4, 2, N'8428407191', N'Vandalur - otteri', 2, N'new battery installed 150ah and 1120va inverter', NULL, N'Customer requested routine checkup', CAST(N'2026-02-22T23:39:37.4337430' AS DateTime2), N'plumbing work need for next month', CAST(N'2026-02-22T23:39:37.4337430' AS DateTime2), NULL)
GO
INSERT [dbo].[CustomerServices] ([CustomerServiceId], [CustomerId], [MobileNumber], [Location], [ProductId], [ProductsDetail], [ProductOrWarrantyImage], [Remarks], [CreatedDateTime], [CreatedBy], [UpdatedDateTime], [UpdatedBy]) VALUES (6, 4, NULL, N't.v. malai', 2, N'10 pending calls', NULL, NULL, CAST(N'2026-02-22T23:43:25.3177597' AS DateTime2), NULL, CAST(N'2026-02-22T23:43:25.3177597' AS DateTime2), NULL)
GO
INSERT [dbo].[CustomerServices] ([CustomerServiceId], [CustomerId], [MobileNumber], [Location], [ProductId], [ProductsDetail], [ProductOrWarrantyImage], [Remarks], [CreatedDateTime], [CreatedBy], [UpdatedDateTime], [UpdatedBy]) VALUES (7, 5, NULL, N'kayarambedu', 2, N'10 pending calls', NULL, NULL, CAST(N'2026-02-22T23:43:50.5802925' AS DateTime2), NULL, CAST(N'2026-02-22T23:43:50.5802925' AS DateTime2), NULL)
GO
INSERT [dbo].[CustomerServices] ([CustomerServiceId], [CustomerId], [MobileNumber], [Location], [ProductId], [ProductsDetail], [ProductOrWarrantyImage], [Remarks], [CreatedDateTime], [CreatedBy], [UpdatedDateTime], [UpdatedBy]) VALUES (8, 6, NULL, N'vandalur', 2, N'10 pending calls', NULL, NULL, CAST(N'2026-02-22T23:44:11.1800043' AS DateTime2), NULL, CAST(N'2026-02-22T23:44:11.1800043' AS DateTime2), NULL)
GO
INSERT [dbo].[CustomerServices] ([CustomerServiceId], [CustomerId], [MobileNumber], [Location], [ProductId], [ProductsDetail], [ProductOrWarrantyImage], [Remarks], [CreatedDateTime], [CreatedBy], [UpdatedDateTime], [UpdatedBy]) VALUES (9, 7, NULL, N'Mudichur', 2, N'10 pending calls', NULL, NULL, CAST(N'2026-02-22T23:44:29.3455072' AS DateTime2), NULL, CAST(N'2026-02-22T23:44:29.3455072' AS DateTime2), NULL)
GO
SET IDENTITY_INSERT [dbo].[CustomerServices] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [Description], [Category], [IsActive], [CreatedDateTime], [CreatedBy], [UpdatedDateTime], [UpdatedBy]) VALUES (1, N'Battery Service', N'Maintenance and replacement of batteries', N'Electrical', 1, CAST(N'2026-02-21T23:41:44.1009937' AS DateTime2), N'Admin', CAST(N'2026-02-21T23:41:44.1009937' AS DateTime2), NULL)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [Description], [Category], [IsActive], [CreatedDateTime], [CreatedBy], [UpdatedDateTime], [UpdatedBy]) VALUES (2, N'Inverter Service', N'Installation and repair of inverters', N'Electrical', 1, CAST(N'2026-02-21T23:41:44.1009937' AS DateTime2), N'Admin', CAST(N'2026-02-21T23:41:44.1009937' AS DateTime2), NULL)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [Description], [Category], [IsActive], [CreatedDateTime], [CreatedBy], [UpdatedDateTime], [UpdatedBy]) VALUES (3, N'RO Water Purifier Service', N'Filter replacement and purifier maintenance', N'Water', 1, CAST(N'2026-02-21T23:41:44.1009937' AS DateTime2), N'Admin', CAST(N'2026-02-21T23:41:44.1009937' AS DateTime2), NULL)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [Description], [Category], [IsActive], [CreatedDateTime], [CreatedBy], [UpdatedDateTime], [UpdatedBy]) VALUES (4, N'General Electrical Checkup', N'Routine inspection of electrical systems', N'Electrical', 1, CAST(N'2026-02-21T23:41:44.1009937' AS DateTime2), N'Admin', CAST(N'2026-02-21T23:41:44.1009937' AS DateTime2), NULL)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [Description], [Category], [IsActive], [CreatedDateTime], [CreatedBy], [UpdatedDateTime], [UpdatedBy]) VALUES (5, N'Annual Maintenance Contract', N'Yearly service package for multiple utilities', N'Package', 1, CAST(N'2026-02-21T23:41:44.1009937' AS DateTime2), N'Admin', CAST(N'2026-02-21T23:41:44.1009937' AS DateTime2), NULL)
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
ALTER TABLE [dbo].[CustomerInfo] ADD  DEFAULT (sysdatetime()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[CustomerInfo] ADD  DEFAULT (sysdatetime()) FOR [UpdatedDateTime]
GO
ALTER TABLE [dbo].[CustomerServices] ADD  DEFAULT (sysdatetime()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[CustomerServices] ADD  DEFAULT (sysdatetime()) FOR [UpdatedDateTime]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT (sysdatetime()) FOR [CreatedDateTime]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT (sysdatetime()) FOR [UpdatedDateTime]
GO
ALTER TABLE [dbo].[CustomerServices]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[CustomerInfo] ([CustomerId])
GO
ALTER TABLE [dbo].[CustomerServices]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
