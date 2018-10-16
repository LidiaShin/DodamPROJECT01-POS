select * from tblCustomer;

UPDATE tblCustomer SET fName='Som',lName='Som',Address='Som',City='Som',Province='BC',Phone='som',Email='som@gmail.com',Note='na',PostalCode='S9S0G0'
WHERE customerID='4';

SELECT * FROM tblCustomer WHERE customerID='4';

SELECT * FROM tblCustomer;
SELECT * FROM tblCustomer WHERE lOWER(fName+lName) LIKE LOWER('%shi%');
SELECT * FROM tblCustomer WHERE lOWER(fName+lName) LIKE LOWER('%ss%');

UPDATE tblCustomer SET fName=('ss'),lName=('ss'),
            Address=('ss'),City=('ss'),Province=('ss'),Phone=('ss'),Email=('ss'),PostalCode=('ss'),Note=('ss')
            WHERE customerID=('4');
UPDATE tblCustomer SET fName=('s'),lName=('s'),
            Address=('s'),City=('s'),Province=('s'),Phone=('s'),Email=('s'),PostalCode=('s'),Note=('s') WHERE customerID=('4');