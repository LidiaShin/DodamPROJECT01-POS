using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace DodamPOS
{
    public class ConnectionClass
    {
        private static SqlConnection cntString;
        private static SqlCommand cmdString;


        static ConnectionClass()
        {
            cntString = new SqlConnection(ConfigurationManager.ConnectionStrings["dodampos"].ConnectionString);
            //cntString = new SqlConnection(ConfigurationManager.ConnectionStrings["dodamposlocal"].ConnectionString);
        }

     public static bool SignIn(CsUserlist userinfo)
        {
            string aQuery = string.Format(@"SELECT count(username) from userlist where username=('{0}') and password=('{1}')",
            userinfo.username, userinfo.password);

            cmdString = new SqlCommand(aQuery, cntString);

            cntString.Open();

            try { 
                int count = (int)cmdString.ExecuteScalar();

                cntString.Close();

                return count > 0;
            }
            finally
            {
                cntString.Close();
            }
        }

        // Get Province list into dropdownlist 
        // 031 customer_addnew.aspx
        public static void GetPVlist(CsProvincelist pv)
        {
            string bQuery = string.Format(@"SELECT * FROM tblProvince");
            cmdString = new SqlCommand(bQuery, cntString);

            try
            {
                cntString.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmdString);

                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                da.Fill(dt);
                ds.Tables.Add(dt);

                pv.Provinces = ds.Tables[0];
            }

            finally
            {
                cntString.Close();
            }
        }

        public static void RegistrationCustomer(CsCustomer customer)
        {
            string cQuery = string.Format(@"INSERT INTO tblCustomer 
            (customerID,fName,lName,Email,Phone,Address,City,Province,PostalCode,Note,RegisterDate)
            VALUES(NEXT VALUE FOR SQcustomer,(N'{0}'),(N'{1}'),('{2}'),('{3}'),(N'{4}'),(N'{5}'),('{6}'),('{7}'),(N'{8}'),GETDATE());",
            customer.cFirstName,customer.cLastName,customer.cEmail,customer.cPhone,customer.cAddress,customer.cCity,customer.cProvince,customer.cPostalCode,customer.cNote);

            cmdString = new SqlCommand(cQuery, cntString);

            try
            {
                cntString.Open();
                cmdString.ExecuteNonQuery();
            }

            finally
            {
                cntString.Close();
            }
        }


        public static void SendRegisterEmail(CsRegisterEmail cmail)
        {
            MailMessage msg = new MailMessage();
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();

            try
            {
                msg.Subject = cmail.emailSubject;
                msg.Body = cmail.emailContent;
                msg.From= new MailAddress("dodam.KGHS@gmail.com");
                msg.To.Add(cmail.emailAddress);


                msg.IsBodyHtml = true;



                client.Host = "smtp.gmail.com";
                System.Net.NetworkCredential basicauthenticationinfo = new System.Net.NetworkCredential("dodam.KGHS@gmail.com", "1142311423");

                client.Port = int.Parse("587"); //if using SSL 465
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = basicauthenticationinfo;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(msg);



                //SmtpClient smtp = new SmtpClient("smtp.gmail.com", 465);
                //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                ////to authenticate we set the username and password properites on the SmtpClient
                //smtp.Credentials = new NetworkCredential("dodam.KGHS@gmail.com", "1142311423");//no need to mention here?
                //smtp.Send(msg);

            }

            finally
            {

            }
        }


        public static void GetCustomerList(CsCustomerlist customertable)
        {
            string dQuery = string.Format(@"SELECT customerID AS NO,(fName + '  '+ lName ) AS NAME, email AS 'E-MAIL',city AS 'CITY',Province AS 'PROVINCE',convert(varchar, RegisterDate,106) AS 'REGISTER DATE' from tblCustomer;");
            cmdString = new SqlCommand(dQuery, cntString);

            try
            {
                cntString.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmdString);
  
                DataSet ds = new DataSet();
                da.Fill(ds);            
                customertable.customerList = ds.Tables[0];
            }

            finally
            {
                cntString.Close();
            }        
        }

        // Get Province list into dropdownlist 
        // 032 customer_seedetail.aspx page open
        public static void GetCustomerDetail(CsCustomer thecustomer)
        {
            string eQuery = string.Format(@"SELECT * FROM tblCustomer WHERE customerID = ('{0}');",thecustomer.cNumber);
            cmdString = new SqlCommand(eQuery, cntString);

            try
            {
                cntString.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmdString);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                da.Fill(dt);
                ds.Tables.Add(dt);

                thecustomer.cFirstName = dt.Rows[0]["fName"].ToString();
                thecustomer.cLastName= dt.Rows[0]["lName"].ToString();
                thecustomer.cAddress= dt.Rows[0]["Address"].ToString();
                thecustomer.cCity= dt.Rows[0]["City"].ToString();

                thecustomer.cProvince=dt.Rows[0]["Province"].ToString();
                thecustomer.cPhone= dt.Rows[0]["Phone"].ToString();
                thecustomer.cEmail = dt.Rows[0]["Email"].ToString();
                thecustomer.cNote= dt.Rows[0]["Note"].ToString();
                thecustomer.cRegisterDate= dt.Rows[0]["RegisterDate"].ToString();
                thecustomer.cPostalCode= dt.Rows[0]["PostalCode"].ToString();
            }

            finally
            {
                cntString.Close();
            }
        }

        // Get Province list into dropdownlist 
        // 032 customer_seedetail.aspx press save button

        public static void UpdateCustomerDetail(CsCustomer thiscustomer)
        {
            string fQuery = string.Format(@"UPDATE tblCustomer SET fName=(N'{0}'),lName=(N'{1}'),
            Address=(N'{2}'),City=(N'{3}'),Province=('{4}'),Phone=('{5}'),Email=('{6}'),PostalCode=('{7}'),Note=(N'{8}') WHERE customerID=('{9}');",
            thiscustomer.cFirstName, thiscustomer.cLastName, thiscustomer.cAddress, thiscustomer.cCity,
            thiscustomer.cProvince, thiscustomer.cPhone, thiscustomer.cEmail, thiscustomer.cPostalCode, thiscustomer.cNote, thiscustomer.cNumber);


            cmdString = new SqlCommand(fQuery, cntString);

            try
            {
                cntString.Open();
                cmdString.ExecuteNonQuery();
            }

            finally
            {
                cntString.Close();
            }
        }


        public static void SearchCustomerByName(CsFilteredCustomerList fCustomerlist)
        {
            string gQuery = string.Format(@"SELECT customerID AS NO,(fName + '  '+ lName ) AS NAME, email AS 'E-MAIL',city AS 'CITY',Province AS 'PROVINCE',convert(varchar, RegisterDate,106) AS 'REGISTER DATE' FROM tblCustomer WHERE lOWER(fName+lName) LIKE LOWER(N'%{0}%');", fCustomerlist.kWordName);
            cmdString = new SqlCommand(gQuery, cntString);

            try
            {
                cntString.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmdString);
                //DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                da.Fill(ds);

                //ds.Tables.Add(dt);

                fCustomerlist.fCustomerList = ds.Tables[0];
            }
            catch
            {

            }

            finally
            {
                cntString.Close();
            }
        }




        public static void SearchCustomerByEmail(CsFilteredCustomerList fCustomerlist)
        {
            string hQuery = string.Format(@"SELECT customerID AS NO,(fName + '  '+ lName ) AS NAME, email AS 'E-MAIL',city AS 'CITY',Province AS 'PROVINCE',
convert(varchar, RegisterDate,106) AS 'REGISTER DATE' FROM tblCustomer WHERE lOWER(Email) LIKE LOWER('%{0}%');", fCustomerlist.kWordEmail);
            cmdString = new SqlCommand(hQuery, cntString);

            try
            {
                cntString.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmdString);
                //DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                da.Fill(ds);

                //ds.Tables.Add(dt);

                fCustomerlist.fCustomerList = ds.Tables[0];
            }
            catch
            {

            }

            finally
            {
                cntString.Close();
            }
        }

   // 021 item_add new page    
        public static void RegisterItem(CsItem newItem)
        {
            string iQuery = string.Format(@"INSERT INTO tblItem (itemID,itemCategory,itemName,itemPPrice,itemRPrice,itemNote,itemImage,itemQty,itemRegisterDate) 
            VALUES (NEXT VALUE FOR SQitem,(N'{0}'),(N'{1}'),('{2}'),('{3}'),(N'{4}'),(N'{5}'),('{6}'),GETDATE());", 
            newItem.itemCategory, newItem.itemName, newItem.itemPPrice, newItem.itemRPrice, newItem.itemNote, newItem.itemImage, newItem.itemQuantity);

            cmdString = new SqlCommand(iQuery, cntString);

            try
            {
                cntString.Open();
                cmdString.ExecuteNonQuery();
                cntString.Close();
            }

            finally
            {
                cntString.Close();
            }

        }


        public static void GetItemCat(CsItemCat itemcat)
        {
            string bQuery = string.Format(@"SELECT * FROM tblCategory;");
            cmdString = new SqlCommand(bQuery, cntString);

            try
            {
                cntString.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmdString);
                //DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                da.Fill(ds);
                itemcat.itemCategory = ds.Tables[0];

                
            }

            finally
            {
                cntString.Close();
            }
        }



        //020 item page
        public static void GetItemList(CsItemlist itemtable)
        {
            string kQuery = string.Format(@"SELECT itemID AS NO,itemCategory AS CATEGORY,itemName AS NAME, itemPPrice AS PurchasePrice,itemRPrice AS RetailPrice,
itemQty AS Quantity, convert(varchar, itemRegisterDate,106) AS 'REGISTER DATE' from tblItem order by itemID;");

            cmdString = new SqlCommand(kQuery, cntString);

            try
            {
                cntString.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmdString);

                DataSet ds = new DataSet();
                da.Fill(ds);
                itemtable.itemList = ds.Tables[0];
            }

            finally
            {
                cntString.Close();
            }
        }


        public static void SearchItemByName(CsFilteredItemList flist)
        {
            string iQuery = string.Format(@"SELECT itemID AS NO,itemCategory AS CATEGORY,itemName AS NAME, 
itemPPrice AS PurchasePrice,itemRPrice AS RetailPrice,
itemQty AS Quantity, convert(varchar, itemRegisterDate,106) AS 'REGISTER DATE'
from tblItem WHERE lOWER(itemName) LIKE LOWER(N'%{0}%')order by itemID;",flist.keyiName);
            cmdString = new SqlCommand(iQuery, cntString);

            try
            {
                cntString.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmdString);
                //DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                da.Fill(ds);

                //ds.Tables.Add(dt);

                flist.fiTable = ds.Tables[0];
            }
            catch
            {

            }

            finally
            {
                cntString.Close();
            }
        }



        public static void SearchItemByNote(CsFilteredItemList flist)
        {
            string iQuery = string.Format(@"SELECT itemID AS NO,itemCategory AS CATEGORY,itemName AS NAME, 
itemPPrice AS PurchasePrice,itemRPrice AS RetailPrice,
itemQty AS Quantity, convert(varchar, itemRegisterDate,106) AS 'REGISTER DATE'
from tblItem WHERE lOWER(itemNote) LIKE LOWER(N'%{0}%')order by itemID;", flist.keyiNote);
            cmdString = new SqlCommand(iQuery, cntString);

            try
            {
                cntString.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmdString);
                //DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                da.Fill(ds);

                //ds.Tables.Add(dt);

                flist.fiTable = ds.Tables[0];
            }
            catch
            {

            }

            finally
            {
                cntString.Close();
            }
        }


        // POS Page

        public static void GetItemAll(CsItemlist itable)
        {
            string kQuery = string.Format(@"SELECT itemID AS NO,itemCategory AS CATEGORY,itemName AS NAME, 
           itemPPrice AS PurchasePrice,itemRPrice AS RetailPrice,
           itemQty AS Quantity,itemImage AS URL from tblItem order by itemID;");

            cmdString = new SqlCommand(kQuery, cntString);

            try
            {
                cntString.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmdString);

                DataSet ds = new DataSet();
                da.Fill(ds);
                itable.itemList = ds.Tables[0];
            }

            finally
            {
                cntString.Close();
            }
        }

        public static void GetItemByCat(CsFilteredItemList fitem)
        {
            string kQuery = string.Format(@"SELECT itemID AS NO,itemCategory AS CATEGORY,itemName AS NAME, 
           itemPPrice AS PurchasePrice,itemRPrice AS RetailPrice,
           itemQty AS Quantity,itemImage AS URL from tblItem WHERE itemCategory=('{0}') order by itemID;",fitem.keyiName);

            cmdString = new SqlCommand(kQuery, cntString);

            try
            {
                cntString.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmdString);

                DataSet ds = new DataSet();
                da.Fill(ds);
                fitem.fiTable= ds.Tables[0];
            }

            finally
            {
                cntString.Close();
            }
        }












        // 022 item_seedetail page
        // page load

        public static void GetItemDetail(CsItem itemdetail)
        {
            string iQuery = string.Format(@"SELECT * FROM tblItem WHERE itemID = ('{0}');", itemdetail.itemNumber);
            cmdString = new SqlCommand(iQuery, cntString);

            try
            {
                cntString.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmdString);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                da.Fill(dt);
                ds.Tables.Add(dt);


                itemdetail.itemCategory = dt.Rows[0]["itemCategory"].ToString();
                itemdetail.itemName = dt.Rows[0]["itemName"].ToString();
                itemdetail.itemQuantity= dt.Rows[0]["itemQty"].ToString();
                itemdetail.itemNote= dt.Rows[0]["itemNote"].ToString();

                itemdetail.itemPPrice= dt.Rows[0]["itemPPrice"].ToString();
                itemdetail.itemRPrice= dt.Rows[0]["itemRPrice"].ToString();

                itemdetail.itemImage= dt.Rows[0]["itemImage"].ToString();
               
            }

            finally
            {
                cntString.Close();
            }
        }



        public static void UpdateItemDetail(CsItem olditem)
        {
            string iQuery = string.Format(@"UPDATE tblItem SET itemCategory=(N'{0}'),itemName=(N'{1}'),
            itemPPrice=('{2}'),itemRPrice=('{3}'),itemNote=(N'{4}'),itemImage=(N'{5}'),itemQty=('{6}') 
			WHERE itemID=('{7}');",
            olditem.itemCategory, olditem.itemName, olditem.itemPPrice, olditem.itemRPrice, olditem.itemNote,
            olditem.itemImage,olditem.itemQuantity, olditem.itemNumber);
          
            cmdString = new SqlCommand(iQuery, cntString);

            try
            {
                cntString.Open();
                cmdString.ExecuteNonQuery();
            }

            finally
            {
                cntString.Close();
            }
        }













    }
}