USE [EcommerceApiDb]
GO
/****** Object:  Table [dbo].[AdminInfo]    Script Date: 3/29/2024 11:11:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](10) NULL,
	[Email] [nvarchar](30) NULL,
	[Password] [nvarchar](6) NULL,
	[LastLogin] [nvarchar](25) NULL,
	[CreatedOn] [nvarchar](25) NULL,
	[UpdatedOn] [nvarchar](25) NULL,
 CONSTRAINT [PK_AdminInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 3/29/2024 11:11:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[cartId] [int] IDENTITY(1,1) NOT NULL,
	[userId] [int] NULL,
	[productId] [int] NULL,
	[Quantity] [int] NULL,
	[ShipppingCarges] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[cartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 3/29/2024 11:11:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerOrder]    Script Date: 3/29/2024 11:11:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerOrder](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NULL,
	[OrderId] [nvarchar](9) NULL,
	[PaymentMode] [nvarchar](50) NULL,
	[AddressId] [int] NULL,
	[ShippingCharges] [int] NULL,
	[SubTotal] [float] NULL,
	[Total] [float] NULL,
	[ShippingStatus] [nvarchar](max) NULL,
	[CreatedOn] [nvarchar](25) NULL,
	[UpdatedOn] [nvarchar](25) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EcommerceUser]    Script Date: 3/29/2024 11:11:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EcommerceUser](
	[userId] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[password] [varchar](100) NOT NULL,
	[username] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 3/29/2024 11:11:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [nvarchar](9) NOT NULL,
	[ProductId] [int] NULL,
	[Quantity] [int] NULL,
	[Price] [int] NULL,
	[SubTotal] [int] NULL,
	[CreatedOn] [nvarchar](25) NULL,
	[UpdatedOn] [nvarchar](25) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 3/29/2024 11:11:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Price] [int] NOT NULL,
	[CategoryId] [int] NULL,
	[ImageUrl] [varchar](100) NULL,
	[Stock] [int] NOT NULL,
	[ProDesc] [varchar](250) NULL,
	[shippingCharges] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shippingAddress]    Script Date: 3/29/2024 11:11:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shippingAddress](
	[addressId] [int] IDENTITY(1,1) NOT NULL,
	[aptno] [varchar](10) NULL,
	[street] [varchar](100) NULL,
	[city] [varchar](100) NULL,
	[province] [varchar](100) NULL,
	[pincode] [varchar](10) NULL,
	[phoneNumber] [varchar](15) NULL,
	[customerName] [varchar](100) NULL,
	[userId] [int] NULL,
	[active] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[addressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CustomerOrder]  WITH CHECK ADD FOREIGN KEY([AddressId])
REFERENCES [dbo].[shippingAddress] ([addressId])
GO
ALTER TABLE [dbo].[shippingAddress]  WITH CHECK ADD FOREIGN KEY([userId])
REFERENCES [dbo].[EcommerceUser] ([userId])
GO
