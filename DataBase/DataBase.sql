﻿

----------------------------------- Phần User mặc định của Entity khi được khởi tạo
create Table Customer(
	Id  decimal identity(1,1) PRIMARY KEY ,
	AddressId int,
	Hobby nvarchar(255) null,
	Created datetime DEFAULT GETDATE()
	,Status int	-- 1: tồn tại ,2: xóa ... 
)
GO
create Table Address(
	Id  decimal identity(1,1) PRIMARY KEY ,
	Street nvarchar(255) not null,
	CityId int  null,
	DistrictId int  null,
	WardId int  null,
	Created datetime DEFAULT GETDATE()
	,Status int	-- 1: tồn tại ,2: xóa ...
)
GO
create Table City(
	Id  decimal identity(1,1) PRIMARY KEY ,
	Name nvarchar(100)  null
	,Status int	-- 1: tồn tại ,2: xóa ...
)
GO
create Table District(
	Id  decimal identity(1,1) PRIMARY KEY ,
	Name nvarchar(100)  null,
	CityId int  NULL
	,Status int	-- 1: tồn tại ,2: xóa ...
)
GO
create Table Ward(
	Id  decimal identity(1,1) PRIMARY KEY ,
	Name nvarchar(100)  null,
	DistrictId int  NULL
	,Status int	-- 1: tồn tại ,2: xóa ...
)
GO
create table Product
(
	Id  decimal identity(1,1) PRIMARY KEY ,
	IdOrigin int, -- đồng hồ có nhiều xuất xứ
	IdBrand_Product int, -- đồng hồ có nhiều thương hiệu
	IdHunting_Case int, -- đồng hồ có nhiều loại mặt kính khác nhau
	IdChatelaine int , -- đồng hồ có thể có nhiều dây đeo 
	IdColor_Clock_Face int, -- đồng có thể có nhều màu mặt số khác nhau
	IdMadeIn  int , --Đồng hồ có thể có nhiều nơi sản xuất
	IdHem int , --Đồng hồ có các loại niềng khác nhau 
	IdMachine int ,-- Máy: Automatic (Tự Động)
	Sex bit,  -- đồng hồ giới tính nam hay nữ
	Name nvarchar(max), -- tên sản phẩm
	Video nvarchar(max), -- link youtube
	Url nvarchar(max) , -- một sản phẩm sẽ có url sell khác nhau .
	Price int, -- giá bán 
	PriceDiscount int, -- Giá khuyến mãi
	Code  nvarchar(max), -- số hiệu sản phẩm
	Diameter int, --đường kính mặt số
	Waterproof bit ,-- đồng hồ có chống nước hay không ?
	Guarantee nvarchar(max),
	Characteristics nvarchar(max), -- đặc điểm
	[Function] nvarchar(max), -- chức năng : lịch,ngày ... 
	Description_short nvarchar(max), -- mô tả ngắn
	Description_Full nvarchar(max), -- mô tả đầy đủ
	Status int,	-- 1: tồn tại ,2: xóa ...
)
GO
-- bản hình ảnh 
create table Images(
   Id  decimal  identity(1,1) PRIMARY KEY,
   IdProduct int , -- 1 sản phẩm có nhiều hình 
   Name nvarchar(max), -- tên hình 
   Status int -- 1 :tồn tại , 2: đã xóa , 3: hình đại diện
)
GO
-- bản xuất xứ
create table Origin(
   Id  decimal identity(1,1) PRIMARY KEY,
   Name nvarchar(max), -- tên nơi xuất sứ
   Status int -- 1:tồn tại , 2: đã xóa
)
GO
-- mặt kính đồng hồ
create table Hunting_Case(
  Id  decimal  identity(1,1) PRIMARY KEY,
  Name nvarchar(max), -- tên loại mặt kính đồng hồ
  Status int -- 1:tồn tại , 2: đã xóa 
)
-- Dây đeo đồng hồ
create table Chatelaine(
  Id  decimal  identity(1,1) PRIMARY KEY,
  Name nvarchar(max), -- tên loại Dây đeo đồng hồ
  Status int -- 1:tồn tại , 2: đã xóa 
)
GO
-- mặt đồng hồ
create table Color_Clock_Face(
  Id  decimal  identity(1,1) PRIMARY KEY,
  Name nvarchar(max), -- tên màu măt kính đồng hồ
  Status int -- 1:tồn tại , 2: đã xóa 
)
GO
 -- thương hiệu đồng hồ
create table Brand_Product(
  Id  decimal  identity(1,1) PRIMARY KEY,
  Name nvarchar(max), -- tên thương hiệu
  Status int -- 1:tồn tại , 2: đã xóa 
)
 -- sản xuất tại nơi 
create table MadeIn(
  Id  decimal identity(1,1) PRIMARY KEY,
  Name nvarchar(max), -- nơi sản xuất
  Status int -- 1:tồn tại , 2: đã xóa 
)
GO
-- Niềng
create table Hem(
  Id  decimal identity(1,1) PRIMARY KEY,
  Name nvarchar(max), -- Niềng bao quanh đồng hồ ( thép,vàng , inox ...)
  Status int -- 1:tồn tại , 2: đã xóa 
)
GO
-- Đồng có các dòng máy tự động , không tự dộng ...
create table Machine(
  Id  decimal identity(1,1) PRIMARY KEY,
  Name nvarchar(max), -- Tên dòng máy 
  Status int -- 1:tồn tại , 2: đã xóa 
)
GO
-- order từng sản phẩm 
create table OrderItems (
  Id  decimal identity(1,1) PRIMARY KEY,
  OrderId int  null,
  ProductId int  null,
  Quantity int  null
)
GO
-- tổng order từng sản phẩm hóa đơn 
create table Orders(
  Id  decimal identity(1,1) PRIMARY KEY,
  Code nvarchar(255) null, -- mã hóa đơn 
  Note nvarchar(255), -- 
  AddressId int not null, -- địa chỉ giao 
  Phone nvarchar(30),
  CustomerId int null,   -- mã khách hàng 
  ReceiverInfo nvarchar(max), -- thông tin người nhận
  Detail nvarchar(max),  -- chi tiết
  IdOrder_Status int,  -- trạng thái hóa đơn
  Status int,  -- 1:tạo hóa đơn , 2:hủy hóa đơn 
  Created datetime DEFAULT GETDATE() -- ngày tạo
)
GO
create table Order_Status (
  Id  decimal identity(1,1) PRIMARY KEY,
  Name nvarchar(255) ,
  Desription nvarchar(255)
)