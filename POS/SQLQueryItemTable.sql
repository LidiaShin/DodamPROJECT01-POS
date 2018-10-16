ALTER TABLE tblItem
	ALTER COLUMN itemImage nvarchar(100);


ALTER TABLE tblItem
	ALTER COLUMN  itemRPrice decimal(8,2);


	select * from tblItem order by itemID;
	select * from tblProvince;

INSERT INTO tblItem (itemID,itemCategory,itemName,itemPPrice,itemRPrice,itemNote,itemImage,itemQty) VALUES (NEXT VALUE FOR SQitem,N'Cloth',N'Magic Dress','50','80',N'princessmaker',N'https://dodamblob.blob.core.windows.net/dodamimg/home4.PNG','3');

CREATE SEQUENCE SQitem
  START WITH 700
  INCREMENT BY 1;

INSERT INTO tblItem (itemID,itemCategory,itemName,itemPPrice,itemRPrice,itemNote,itemImage,itemQty) VALUES (NEXT VALUE FOR SQitem,N'Cloth',N'아기옷','20','80',N'테스트',N'https://dodamblob.blob.core.windows.net/dodamimg/home4.PNG','3');

INSERT INTO tblCategory VALUES(N'CLOTH',N'C1');

INSERT INTO tblCategory VALUES(N'MAGIC',N'M1');
INSERT INTO tblCategory VALUES(N'WEAPON',N'W1');
INSERT INTO tblCategory VALUES(N'BOOK',N'B1');
INSERT INTO tblCategory VALUES(N'POTION',N'P1');

SELECT * FROM tblCategory;

INSERT INTO tblItem (itemID,itemCategory,itemName,itemPPrice,itemRPrice,itemNote,itemImage,itemQty) VALUES (NEXT VALUE FOR SQitem,N'Cloth',N'Magic Dress','50','80',N'princessmaker',N'','3');


INSERT INTO tblItem (itemID,itemCategory,itemName,itemPPrice,itemRPrice,itemNote,itemImage,itemQty) 
            VALUES (NEXT VALUE FOR SQitem,(N'cloth'),(N'cc'),('40'),('70'),(N'note'),(N'df'),('4'));

INSERT INTO tblItem (itemID,itemCategory,itemName,itemPPrice,itemRPrice,itemNote,itemImage,itemQty) 
            VALUES (NEXT VALUE FOR SQitem,(N'cloth'),(N'cc'),('89'),('900'),(N'note'),(N'dfkslfksflksfds'),('4'));

SELECT itemID AS NO,itemCategory AS CATEGORY,itemName AS NAME, itemPPrice AS PurchasePrice,itemRPrice AS RetailPrice,
itemQty AS Quantity, convert(varchar, itemRegisterDate,106) AS 'REGISTER DATE' from tblItem order by itemID;

select * from tblItem order by itemID;
SELECT * FROM tblItem WHERE itemID = '730';

SELECT * FROM tblCategory;

UPDATE tblItem SET itemCategory=(N'매직'),itemName=(N'매직드레스'),
            itemPPrice=('300'),itemRPrice=('400'),itemNote=(N'테스트'),itemImage=(N'https://dodamblob.blob.core.windows.net/dodamimg/home4.PNG'),itemQty=('5') 
			WHERE itemID=('701');

UPDATE tblItem SET itemCategory=(N'{0}'),itemName=(N'{1}'),
            itemPPrice=('{2}'),itemRPrice=('{3}'),itemNote=(N'{4}'),itemImage=(N'{5}'),itemQty=('{6}') 
			WHERE itemID=('{7}');


SELECT itemID AS NO,itemCategory AS CATEGORY,itemName AS NAME, itemPPrice AS PurchasePrice,itemRPrice AS RetailPrice,
itemQty AS Quantity, convert(varchar, itemRegisterDate,106) AS 'REGISTER DATE' from tblItem WHERE lOWER(itemName) LIKE LOWER(N'%D%')order by itemID;
