--Proc for retrive all customer
create proc search_AllOrder 
as 
select customer_id, customer_name from Customer;
go

--Proc to retrive Order by customer id
--Params: customer_id
create proc search_OrderByCutomer
(@customer_id int)
as
select order_id, order_date,customer_id,employee_id, total from Orders where customer_id=@customer_id;
go

--Retrive order line items data by Order
--Params: order_id
create proc search_LineItemsByOrder
(@order_id int)
as 
select * from LineItem where order_id=@order_id;
go

--UDF sum of total data line item by order
--Params: order_id
create function search_ComputeOrderTotal
(@order_id int)
returns float
as
begin
return (select SUM(quantity*price) as total_price from LineItem where order_id=@order_id)
end
go

--Add Customer
--Params: customer_name
create proc add_Customer
(@customer_name nvarchar(100))
as
insert into Customer(customer_name) values(@customer_name);
go


--Delete Cutomer 
--Params: customer_id
create proc delete_Customer
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
go

--Update Customer
--Params: customer_id, customer_name
create proc update_Customer
(
 @customer_id int
,@customer_name nvarchar(100)
)
as
update Customer set customer_name=@customer_name where customer_id=@customer_id;
go

--Insert Order
--Params: order_date, customer_id, employee_id, total
create proc insert_Order
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
go


--Insert LineItem
--Params: order_id, product_id, quantity,price
create proc insert_LineItem
(@order_id int
,@product_id int
,@quantity int
,@price float)
as
begin try
	begin tran
	insert into LineItem(order_id,product_id,quantity,price) values(@order_id,@product_id,@quantity,@price);
	commit tran
end try
begin catch
	rollback tran
end catch
go

--Update total Order
--Params: order_id
create proc update_TotalOrder
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
go


 -- Tìm kiếm khách hàng theo id
 create proc search_CustomerById
(@customer_id int)
as
select * from Customer where customer_id=@customer_id;
go

--  Xóa đơn đặt hàng
 create proc delete_OrderById
(@order_id int)
as
begin try
	begin tran
	delete from LineItem where order_id = @order_id;
	delete from Orders where order_id = @order_id;
	commit tran
end try
begin catch
	rollback tran
end catch
go


--  Tìm kiếm đơn đặt hàng theo id
 create proc search_OrderById
(@order_id int)
as
select * from Orders where order_id=@order_id;
go


--  Cập nhật LineItem
 create proc update_LineItemById
(@order_id int
,@product_id int
,@quantity int
,@price float)
as
  update LineItem set quantity=@quantity, price=@price where order_id=@order_id and product_id=@product_id;
go


--  Xóa LineItem theo id
 create proc delete_LineItemById
(@order_id int
,@product_id int)
as
begin try
	begin tran
	delete from LineItem where order_id = @order_id and product_id=@product_id;
	commit tran
end try
begin catch
	rollback tran
end catch
go

--  Tìm kiếm nhân viên theo id
 create proc search_EmployeeId
(@employee_id int)
as
select * from Employee where employee_id=@employee_id;
go

--  Thêm mới employee 
 create proc insert_Employee
(@employee_id int
,@employee_name nvarchar(100)
,@salary float
,@supervisor_id int)
as
begin try
	begin tran
	insert into Employee(employee_id,employ_name,salary,supervisor_id) values (@employee_id,@employee_name,@salary,@supervisor_id);
	commit tran
end try
begin catch
	rollback tran
end catch
go

--  Cập nhật employee theop id
 create proc update_Employee
(@employee_id int
,@employee_name nvarchar(100)
,@salary float
,@supervisor_id int)
as
begin try
	begin tran
	update Employee set employ_name=@employee_name,salary=@salary,@supervisor_id=supervisor_id where employee_id =@employee_id;
	commit tran
end try
begin catch
	rollback tran
end catch
go

--  Tìm kiếm sản phẩm
 create proc search_ProductById
(@product_id int)
as
select * from Product where product_id=@product_id;
go

--  Thêm mới sản phẩm
 create proc insert_Product
(@product_name int
,@product_price float)
as
begin try
	begin tran
	insert into Product(product_name,product_price) values (@product_name,@product_price);
	commit tran
end try
begin catch
	rollback tran
end catch
go
--  Cập nhật sản phẩm
 create proc update_Product
(@product_id int
,@product_name int
,@product_price float)
as
begin try
	begin tran
	update Product set product_name=@product_name, product_price=@product_price where product_id=@product_id;
end try
begin catch
	rollback tran
end catch
go