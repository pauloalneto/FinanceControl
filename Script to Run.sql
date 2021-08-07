USE [FinanceControl]
GO
/****** Object:  Table [dbo].[Card]    Script Date: 07/08/2021 12:27:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Card](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdFlag] [int] NULL,
	[IdUser] [int] NULL,
	[BankName] [nvarchar](100) NULL,
	[Number] [nvarchar](16) NULL,
	[DueDay] [int] NULL,
	[Expiration] [datetime] NULL,
	[Limit] [decimal](18, 2) NULL,
	[Color] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Flag]    Script Date: 07/08/2021 12:27:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Flag](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 07/08/2021 12:27:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCard] [int] NULL,
	[DueDate] [datetime] NULL,
	[PaymentDate] [datetime] NULL,
	[IdInvoiceStatus] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvoiceStatus]    Script Date: 07/08/2021 12:27:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 07/08/2021 12:27:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
	[Description] [nvarchar](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 07/08/2021 12:27:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Login] [nvarchar](150) NULL,
	[Password] [nvarchar](max) NULL,
	[Email] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 07/08/2021 12:27:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[IdUser] [int] NULL,
	[IdRole] [int] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Card] ON 
GO
INSERT [dbo].[Card] ([Id], [IdFlag], [IdUser], [BankName], [Number], [DueDay], [Expiration], [Limit], [Color]) VALUES (1, 1, 1, N'NUBANK', N'1234123412341234', 24, CAST(N'2022-06-01T00:00:00.000' AS DateTime), CAST(14000.00 AS Decimal(18, 2)), N'#612F74')
GO
SET IDENTITY_INSERT [dbo].[Card] OFF
GO
SET IDENTITY_INSERT [dbo].[Flag] ON 
GO
INSERT [dbo].[Flag] ([Id], [Name]) VALUES (1, N'MasterCard')
GO
INSERT [dbo].[Flag] ([Id], [Name]) VALUES (2, N'Visa')
GO
INSERT [dbo].[Flag] ([Id], [Name]) VALUES (3, N'Elo')
GO
SET IDENTITY_INSERT [dbo].[Flag] OFF
GO
SET IDENTITY_INSERT [dbo].[InvoiceStatus] ON 
GO
INSERT [dbo].[InvoiceStatus] ([Id], [Name]) VALUES (1, N'Pendent')
GO
INSERT [dbo].[InvoiceStatus] ([Id], [Name]) VALUES (2, N'Realized')
GO
SET IDENTITY_INSERT [dbo].[InvoiceStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 
GO
INSERT [dbo].[Role] ([Id], [Name], [Description]) VALUES (1, N'administrator', N'Administrator')
GO
INSERT [dbo].[Role] ([Id], [Name], [Description]) VALUES (2, N'reader', N'Reader')
GO
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([Id], [Name], [Login], [Password], [Email]) VALUES (1, N'Paulo Almeida', N'paulo.almeida', N'123456', N'paulo_machado_a@yahoo.com.br')
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Card]  WITH CHECK ADD FOREIGN KEY([IdFlag])
REFERENCES [dbo].[Flag] ([Id])
GO
ALTER TABLE [dbo].[Card]  WITH CHECK ADD FOREIGN KEY([IdUser])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD FOREIGN KEY([IdCard])
REFERENCES [dbo].[Card] ([Id])
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD FOREIGN KEY([IdInvoiceStatus])
REFERENCES [dbo].[InvoiceStatus] ([Id])
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD FOREIGN KEY([IdRole])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD FOREIGN KEY([IdUser])
REFERENCES [dbo].[User] ([Id])
GO
