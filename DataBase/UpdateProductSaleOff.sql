update Products
set PriceDiscount = Products.Price - 1000000, 
DiscountDateFrom = GETDATE(), DiscountDateTo = DATEADD(hour,2,GETDATE())
from Products
join Product_ProductStatus on Products.Id = Product_ProductStatus.ProductId
where Product_ProductStatus.ProductStatusId = 4

