select * from tblItem;


INSERT INTO tblItem(itemName, itemImage)  
select 'testimage',BulkColumn
FROM OPENROWSET(Bulk 'C:\Users\susur\Dropbox\document\test.jpg', SINGLE_BLOB) AS img;