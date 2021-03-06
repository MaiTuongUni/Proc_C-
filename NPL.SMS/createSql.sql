USE [master]
GO
/****** Object:  Database [SMS]    Script Date: 11/18/2021 11:47:04 PM ******/
CREATE DATABASE [SMS]
GO
USE [SMS]
GO

create function [dbo].[search_ComputeOrderTotal]
(@order_id int)
returns float
as
begin
return (select SUM(quantity*price) as total_price from LineItem where order_id=@order_id)
end
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 11/18/2021 11:47:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[customer_id] [int] IDENTITY(1,1) NOT NULL,
	[customer_name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 11/18/2021 11:47:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[employee_id] [int] IDENTITY(1,1) NOT NULL,
	[employ_name] [nvarchar](100) NOT NULL,
	[salary] [float] NOT NULL,
	[supervisor_id] [int] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[employee_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LineItem]    Script Date: 11/18/2021 11:47:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LineItem](
	[order_id] [int] NOT NULL,
	[product_id] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[price] [float] NOT NULL,
 CONSTRAINT [PK_LineItem] PRIMARY KEY CLUSTERED 
(
	[order_id] ASC,
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 11/18/2021 11:47:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[order_id] [int] IDENTITY(1,1) NOT NULL,
	[order_date] [datetime] NOT NULL,
	[customer_id] [int] NOT NULL,
	[employee_id] [int] NOT NULL,
	[total] [float] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 11/18/2021 11:47:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[product_id] [int] IDENTITY(1,1) NOT NULL,
	[product_name] [nvarchar](100) NOT NULL,
	[product_price] [float] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([customer_id], [customer_name]) VALUES (2, N'Name449')
INSERT [dbo].[Customer] ([customer_id], [customer_name]) VALUES (3, N'Name850')
INSERT [dbo].[Customer] ([customer_id], [customer_name]) VALUES (4, N'Name416')
INSERT [dbo].[Customer] ([customer_id], [customer_name]) VALUES (5, N'Name416')
INSERT [dbo].[Customer] ([customer_id], [customer_name]) VALUES (6, N'Name539')
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([employee_id], [employ_name], [salary], [supervisor_id]) VALUES (1, N'employee1', 20000, 1)
INSERT [dbo].[Employee] ([employee_id], [employ_name], [salary], [supervisor_id]) VALUES (2, N'employee2', 10000, 1)
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([product_id], [product_name], [product_price]) VALUES (1, N'Pro1', 10000)
INSERT [dbo].[Product] ([product_id], [product_name], [product_price]) VALUES (2, N'Pro2', 10000)
INSERT [dbo].[Product] ([product_id], [product_name], [product_price]) VALUES (3, N'Pro3', 10000)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Employee] FOREIGN KEY([supervisor_id])
REFERENCES [dbo].[Employee] ([employee_id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Employee]
GO
ALTER TABLE [dbo].[LineItem]  WITH CHECK ADD  CONSTRAINT [FK_LineItem_Orders] FOREIGN KEY([order_id])
REFERENCES [dbo].[Orders] ([order_id])
GO
ALTER TABLE [dbo].[LineItem] CHECK CONSTRAINT [FK_LineItem_Orders]
GO
ALTER TABLE [dbo].[LineItem]  WITH CHECK ADD  CONSTRAINT [FK_LineItem_Product] FOREIGN KEY([product_id])
REFERENCES [dbo].[Product] ([product_id])
GO
ALTER TABLE [dbo].[LineItem] CHECK CONSTRAINT [FK_LineItem_Product]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customer] FOREIGN KEY([customer_id])
REFERENCES [dbo].[Customer] ([customer_id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customer]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Employee] FOREIGN KEY([employee_id])
REFERENCES [dbo].[Employee] ([employee_id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Employee]
GO
/****** Object:  StoredProcedure [dbo].[add_Customer]    Script Date: 11/18/2021 11:47:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[add_Customer]
(@customer_name nvarchar(100))
as
insert into Customer(customer_name) values(@customer_name);
GO
/****** Object:  StoredProcedure [dbo].[delete_Customer]    Script Date: 11/18/2021 11:47:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[delete_Customer]
(@customer_id int)
as
begin try
	begin tran
	delete LineItem where order_id in(select order_id from Orders where customer_id=@customer_id);
	delete Orders where customer_id=@customer_id;
	delete Customer where customer_id=@customer_id;
	commit tran
end try
begin catch
	rollback tran
end catch
GO
/****** Object:  StoredProcedure [dbo].[insert_LineItem]    Script Date: 11/18/2021 11:47:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insert_LineItem]
(@order_id int
,@product_id int
,@quantity int
,@price float)
as
declare @found varchar;
begin try
	begin tran
	set @found = (select 'A' from LineItem where order_id=@order_id and product_id=@product_id);
	if @found is null
		insert into LineItem(order_id,product_id,quantity,price) values(@order_id,@product_id,@quantity,@price);
	else
		update LineItem set quantity=quantity+@quantity, price=price+@price where order_id=@order_id and product_id=@product_id;
	commit tran
end try
begin catch
	rollback tran
end catch
GO
/****** Object:  StoredProcedure [dbo].[insert_Order]    Script Date: 11/18/2021 11:47:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insert_Order]
(@order_date datetime
,@customer_id int
,@employee_id int
,@total float)
as
begin try
	begin tran
	insert into Orders(order_date,customer_id,employee_id,total) values(@order_date,@customer_id,@employee_id,@total);
	commit tran
end try
begin catch
	rollback tran
end catch
GO
/****** Object:  StoredProcedure [dbo].[search_AllOrder]    Script Date: 11/18/2021 11:47:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[search_AllOrder] 
as 
select customer_id, customer_name from Customer;
GO
/****** Object:  StoredProcedure [dbo].[search_LineItemsByOrder]    Script Date: 11/18/2021 11:47:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[search_LineItemsByOrder]
(@order_id int)
as 
select * from LineItem where order_id=@order_id;
GO
/****** Object:  StoredProcedure [dbo].[search_OrderByCutomer]    Script Date: 11/18/2021 11:47:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[search_OrderByCutomer]
(@customer_id int)
as
select order_id, order_date,customer_id,employee_id, total from Orders where customer_id=@customer_id;
GO
/****** Object:  StoredProcedure [dbo].[update_Customer]    Script Date: 11/18/2021 11:47:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[update_Customer]
(
 @customer_id int
,@customer_name nvarchar(100)
)
as
update Customer set customer_name=@customer_name where customer_id=@customer_id;
GO
/****** Object:  StoredProcedure [dbo].[update_TotalOrder]    Script Date: 11/18/2021 11:47:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[update_TotalOrder]
(@order_id int)
as
begin try
	begin tran
	update Orders set total = (select SUM(quantity*price) from LineItem where order_id=@order_id);
	commit tran
end try
begin catch
	rollback tran
end catch
GO
USE [master]
GO
ALTER DATABASE [SMS] SET  READ_WRITE 
GO
