CREATE PROC SP_GETRANDOM
(
@Lower INT, --11111-- The lowest random number
@Upper INT --99999-- The highest random number
)
AS
BEGIN

    IF NOT (@Lower < @Upper) RETURN -1

    --TODO: If all the numbers between Lower and Upper are in the table,
    --you should return from here
    --RETURN -2

    DECLARE @Random INT;
    --SELECT @Random = ROUND(((@Upper - @Lower -1) * RAND() + @Lower), 0)

    --WHILE  EXISTS (SELECT * FROM YourTable WHERE randCol = @Random)
    BEGIN

        SELECT @Random = ROUND(((@Upper - @Lower -1) * RAND() + @Lower), 0)
    END

    SELECT @Random
END


CREATE PROC SP_RANDOM_ORDERITEM_BY_ORDERID
(
@OrderIdInput INT
)
AS
BEGIN 
	DECLARE @TotalNumProduct Int = 0;
	DECLARE @TotalPrice BIGINT = 0;
	DECLARE @OrderId int = @OrderIdInput;
	DECLARE @LimitItem INT = 0;
	DECLARE @LimitItemNum INT = ROUND(((10 - 1 -1) * RAND() + 1), 0);
	WHILE @LimitItem < @LimitItemNum
		BEGIN

			BEGIN
				DECLARE @ProductId Int = ROUND(((4808 - 1 -1) * RAND() + 1), 0);
				DECLARE @Qty Int = ROUND(((10 - 1 -1) * RAND() + 1), 0);
				DECLARE @Price BIGINT;

				SELECT @Price = 
					case 
						when Products.PriceDiscount = NULL then Products.Price
						when Products.PriceDiscount > 0 and Products.DiscountDateTo > GETDATE() then Products.PriceDiscount
						ELSE Products.Price
					END
				from Products where Id = @ProductId
			END

			BEGIN
				
				IF EXISTS (Select * from Products where Id = @ProductId)
					BEGIN
						SET @TotalPrice = 
							CASE
								WHEN @Price = NULL then 0
								ELSE @TotalPrice + (@Price * @Qty)
							END;
						set @TotalNumProduct = @TotalNumProduct + @Qty
						INSERT INTO OrderItems(Id,OrderId,ProductId,Quantity,CurrentPrice) VALUES(0,@OrderId,@ProductId,@Qty,@Price)
					END
			END

            SET @LimitItem = @LimitItem + 1
		END;
	
	IF EXISTS (Select * from Orders where Id = @OrderId)
	BEGIN
		UPDATE Orders
		set TotalPrice = @TotalPrice, TotalItemInOrder = @TotalNumProduct
		where Id = @OrderId
	END
END