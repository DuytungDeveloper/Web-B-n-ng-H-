USE [Ecommerce]
GO

INSERT INTO [dbo].[Product]([ProductCode],[url],[DiscountPrice],[SalePrice],[Images],[Videos],[Note],[MetaTags],[Status],[Created])
select '1','',35000,25000,'','','','',1,GETDATE()     
GO
INSERT INTO [dbo].[Product]([ProductCode],[url],[DiscountPrice],[SalePrice],[Images],[Videos],[Note],[MetaTags],[Status],[Created])
select '1','',95000,125000,'','','','',1,GETDATE()  
GO
INSERT INTO [dbo].[Product_Attribute]([Name],[Url],[Type],[Status],[Created])
select 'Price','',1,1,GETDATE()
GO
INSERT INTO [dbo].[Product_Attribute]([Name],[Url],[Type],[Status],[Created])
select 'Title','',1,1,GETDATE()

GO
INSERT INTO [dbo].[Product_Attribute_Mapping]([ProductId],[Product_AttributeId],[Value],[Type])
select 1,1,'1000000',1
GO
INSERT INTO [dbo].[Product_Attribute_Mapping]([ProductId],[Product_AttributeId],[Value],[Type])
select 2,1,'1000000',1
GO
INSERT INTO [dbo].[Product_Attribute_Mapping]([ProductId],[Product_AttributeId],[Value],[Type])
select 3,2,'1000000',2
GO
select * from Product
select * from Product_Attribute
select * from Product_Attribute_Mapping