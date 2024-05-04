use OrderApp

---- Create the Items table
--CREATE TABLE Items (
--    ItemsId INT PRIMARY KEY IDENTITY,
--    ItemDesc NVARCHAR(255),
--    ItemCost DECIMAL(18, 2)
--);

---- Create the OrderMaster table
--CREATE TABLE OrderMasters (
--    OrderId INT PRIMARY KEY IDENTITY,
--    CustomerID varchar(MAX),
--    OrderedDate DATETIME,
--    OrderedAmount DECIMAL(18, 2)
--);

---- Create the OrderDetails table
--CREATE TABLE OrderDetails (
--    OrderedDetailsId INT PRIMARY KEY IDENTITY,
--    OrderedIDMaster INT,
--    Item INT,
--    Quantity INT,
--    Cost DECIMAL(18, 2),
--    FOREIGN KEY (OrderedIDMaster) REFERENCES OrderMasters(OrderId),
--    FOREIGN KEY (Item) REFERENCES Items(ItemsId)
--);

select * from Items
select * from OrderMasters
select * from OrderDetails