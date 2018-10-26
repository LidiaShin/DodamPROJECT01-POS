using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DodamPOS
{
    public partial class _001pos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["itemCat"] != null)
            {
                CurrentPageIndex = 0;
                ItemViewByCat(Session["itemCat"].ToString());

                Session["iTable"] = new DataTable();

                iTable.Columns.Add("orderno", typeof(string)); // Column[0] invisible
                iTable.Columns.Add("No", typeof(string));  // Column[1] 
                iTable.Columns.Add("name", typeof(string));  // Column[2] 
                iTable.Columns.Add("unitprice", typeof(double));  // Column[3] 
                iTable.Columns.Add("qty", typeof(double));  // Column[4] 
                iTable.Columns.Add("amount", typeof(double));  // Column[5] 
                iTable.Columns.Add("tax", typeof(double));  // Column[6] 

            }

            else if (!IsPostBack && Session["itemCat"] == null)
            {
                CurrentPageIndex = 0;
                ItemViewByCat("All");

                Session["iTable"] = new DataTable();

                iTable.Columns.Add("orderno", typeof(string));   // Column[0] invisible
                iTable.Columns.Add("No", typeof(string));  // Column[1] 
                iTable.Columns.Add("name", typeof(string));  // Column[2] 
                iTable.Columns.Add("unitprice", typeof(double));  // Column[3] 
                iTable.Columns.Add("qty", typeof(double));  // Column[4] 
                iTable.Columns.Add("amount", typeof(double));  // Column[5] 
                iTable.Columns.Add("tax", typeof(double));  // Column[6] 

            }
        }
        DataTable itemTable { get; set; }
       
        int pg = 0;
        public int CurrentPageIndex
        {
            get
            {
                if (ViewState["pg"] == null)
                    return 0;
                else
                    return Convert.ToInt32(ViewState["pg"]);
            }
            set
            {
                ViewState["pg"] = value;
            }
        }


        string knote { get; set; }
        void ItemViewByCat(string catName)
        {
            PagedDataSource pgd = new PagedDataSource();

            if (catName == "All")
            {
                try
                {          
                    CsItemlist pos = new CsItemlist(itemTable);
                    ConnectionClass.GetItemAll(pos);
                    pgd.DataSource = pos.itemList.DefaultView; 
                }

                catch
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Sorry, Error Occured during the process, Please select again, ');</script>");
                }
                
            }
            else
            {
                try
                {
                    //PagedDataSource pgd = new PagedDataSource();
                    CsFilteredItemList flist = new CsFilteredItemList(catName, knote, itemTable);
                    ConnectionClass.GetItemByCat(flist);
                    pgd.DataSource = flist.fiTable.DefaultView;
                }
                catch
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('error');</script>");
                }
                //finally
            }
            pgd.CurrentPageIndex = CurrentPageIndex;
            pgd.AllowPaging = true;
            pgd.PageSize = 8;
            itemLists.DataSource = pgd;
            itemLists.DataBind();

            BtnPrevious.Enabled = !(pgd.IsLastPage);
            BtnNext.Enabled = !(pgd.IsFirstPage);  
        }


        protected void LinkButton2_Click(object sender, EventArgs e) // PAGE PREVIOUS
        { 
            CurrentPageIndex++;
            ItemViewByCat(CatSelect.Text);
            
        }
        protected void LinkButton3_Click(object sender, EventArgs e) // PAGE NEXT
        {
            CurrentPageIndex--;
            ItemViewByCat(CatSelect.Text);

        }

        public ArrayList Stock(int inCount)
        {
            ArrayList values = new ArrayList();

            for (int i = inCount; i > -1; i--)
            {
                values.Add("" + (i)); // DECREMENT I AND ADD TO DLL
            }

            return values;
        }

        // SELECT ITEM CATEGORY
        protected void SelectCat(object sender, EventArgs e)
                {
                    Button btn = (Button)(sender);
                    string myCat = btn.CommandArgument;
                    CatSelect.Text = myCat;
                    Session["itemCat"] = CatSelect.Text;
                    CurrentPageIndex = 0;
                    ItemViewByCat(myCat);      
                 }

        // CART TABLE CREATE
        protected void RowCreate(object sender, GridViewRowEventArgs e) // Start Shopping
        {
            e.Row.Cells[0].Width = 70; // CALCEL BUTTON COLUMN
            e.Row.Cells[1].Width = 10; //  ORDER NO COLOMN (INVISIBLE)
            e.Row.Cells[2].Width = 40; // ITEM NO COLUMN
            e.Row.Cells[3].Width = 170; // ITEM NAME CALUMN
            e.Row.Cells[4].Width = 90;  // UNIT PRICE CALUMN
            e.Row.Cells[5].Width = 40; // QUANTITY CALUMN
            e.Row.Cells[6].Width = 90; //AMOUNT CALUMN
            e.Row.Cells[7].Width = 60; //TAX CALUMN
            e.Row.Cells[1].Visible = false;
        }


        // CANCEL ITEM
        protected void RowDelete(object sender, GridViewDeleteEventArgs e) 
        {
            DataTable iTable = (DataTable)Session["iTable"];

           
            iTable.Rows[e.RowIndex].Delete();
            
            GridView1.DataSource = iTable;
            GridView1.DataBind();

            
            if (iTable.Rows.Count>0)
            {
                object Sum = iTable.Compute(" SUM(amount) ", "");
                double NetTotal = Double.Parse(Sum.ToString());
                double GrandTotal = NetTotal * 1.13;
                subTotal.Text = NetTotal.ToString();
                grandTotal.Text = GrandTotal.ToString();
            }

            else
            {
                subTotal.Text = "0";
                grandTotal.Text = "0";
            }
        }

        

        public string iCategory { get; set; }
        public string iName { get; set; }
        public string iPPrice { get; set; }
        public string iRPrice { get; set; }
        public string iNote { get; set; }
        public string iImage { get; set; }
        public string iQuantity { get; set; }
        public string iRday { get; set; }

        DataTable iTable
        {
            get
            { return (DataTable)Session["iTable"]; }

            set
            { Session["iTable"] = value; }
        }



        // SELECT CUSTOMER     
        protected void SearchCustomer(object sender, EventArgs e)
        {
            try
            {
                Session["SearchName"] = SearchBox.Value.ToString();
                ClientScript.RegisterStartupScript(this.Page.GetType(), "",
                "window.open('011pos_seeCustomerList.aspx','window','toolbar=0,scrollbars=0,location=0,statusbar=0,menubar=0,resizable=0,height=350,width=700,left=130,top=220');", true);
            }
            catch
            {

            }
        }


        // DISPLAY CUSTOMER NAME + NUMBER
        protected void convert(object sender, EventArgs e)
        {
            lblCustomerName.Text = HdnCName.Value.ToString();
            lblCustomerNumber.Text = HdnCNum.Value.ToString();

        }



        // SELECT ITEM QUANTITY
        protected void SelectCartQty(object sender, EventArgs e)
        {
            //cast the sender back to a dropdownlist
            DropDownList ddl = sender as DropDownList;

            //get the namingcontainer from the dropdownlist and cast it as a datalistitem
            DataListItem item = ddl.NamingContainer as DataListItem;

            //now use findcontrol to find the label in the datalistitem
            Label lbl = item.FindControl("HdnQtySelect") as Label;

            lbl.Text = ddl.SelectedValue.ToString();
            Session["ii"] = lbl.Text;
        }

        // SELECT ITEM (BY CLICK ITEM IMAGE)
        protected void SelectItem(object sender, EventArgs e) 
        {

            if (Session["ii"] == null)
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Please select quantity ');</script>");
            }

            else
            {
                ImageButton ibtn = (ImageButton)(sender);

                string itemNo = Convert.ToString(ibtn.CommandArgument);

                CsItem theitem = new CsItem(itemNo, iCategory, iName, iPPrice, iRPrice, iNote, iImage, iQuantity, iRday);

                ConnectionClass.GetItemDetails(theitem);

                bool found = false;

                if (iTable.Rows.Count > 0) // IF CART IS NOT EMPTY, 
                {
                    foreach (DataRow iRow in iTable.Rows)
                    {
                        if (Convert.ToString(iRow["No"]) == itemNo) // IF THE ITEM IS ALREADY IN THE CART LIST, UPDATE QTY
                        {
                            //double temp = Convert.ToDouble(iRow["qty"]);

                            double temp = Convert.ToDouble(iRow["qty"]);


                            // double uptemp = Convert.ToDouble(Session["ii"]) + temp;

                            double uptemp = Convert.ToDouble(Session["ii"]) + temp;

                            if (uptemp > Convert.ToDouble(theitem.itemQuantity)) // IF USER TRY TO ADD ITEM MORE THAN AVAILABLE NUMBER (=QUANTITY)
                            {
                                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Too Many! ');</script>"); // ALERT MESSSAGE
                            }

                            else
                            {
                                iRow["qty"] = Convert.ToDouble(Session["ii"]) + temp; // UPDATE QUANTITY

                                // iRow["amount"] = Math.Round(Convert.ToDouble(iRow["qty"]) * Convert.ToDouble(iRow["unitprice"]),2);  
                                iRow["amount"] = Math.Round(Convert.ToDouble(iRow["qty"]) * Convert.ToDouble(iRow["unitprice"]), 2);
                                //iRow["tax"] = Convert.ToDouble(iRow["amount"]) * 0.13;
                                iRow["tax"] = Math.Round(Convert.ToDouble(iRow["amount"]) * 0.13,2);
                            }
                            found = true;
                        }
                    }

                    if (!found) // IF ITEM IS NOT IN THE CART LIST, ADD ROW
                    {
                        iTable.Rows.Add("", itemNo, theitem.itemName,
                         Math.Round(Convert.ToDouble(theitem.itemRPrice), 2),
                         Convert.ToDouble(Session["ii"]),
                         Math.Round(Convert.ToDouble(theitem.itemRPrice) * Convert.ToDouble(Session["ii"]), 2),
                         Math.Round(Convert.ToDouble(theitem.itemRPrice) * Convert.ToDouble(Session["ii"]) * 0.13, 2));
                    }                 
                }
                
                else // IF CART IS EMPTY, 
                {
                iTable.Rows.Add("",itemNo, theitem.itemName, 
                        Math.Round(Convert.ToDouble(theitem.itemRPrice),2), 
                        Convert.ToDouble(Session["ii"]),
                        Math.Round(Convert.ToDouble(theitem.itemRPrice) * Convert.ToDouble(Session["ii"]),2), 
                        Math.Round(Convert.ToDouble(theitem.itemRPrice) * Convert.ToDouble(Session["ii"]) *0.13,2));
                }
                GridView1.DataSource = iTable;    //
                GridView1.DataBind(); 



                object Sum = iTable.Compute(" SUM(amount) ", "");
                double NetTotal = Math.Round(Double.Parse(Sum.ToString()),2);
                double GrandTotal = Math.Round(NetTotal * 1.13,2);

                subTotal.Text = NetTotal.ToString();
                grandTotal.Text = GrandTotal.ToString();
                Session["ii"] = null;
            }
            
        }



        string OrderDate { get; set; }
        String OrderNum { get; set; }
        string CustomerNum { get; set; }

        protected void CheckOut(object sender, EventArgs e)
        {
            if (subTotal.Text == "0" && lblCustomerNumber.Text == "-")
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Please Choose Item and Customer');</script>");
            }


            else if (lblCustomerNumber.Text == "-" && subTotal.Text != "0")
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Please Select Customer (Use Search box above)');</script>");
            }

            else if (lblCustomerNumber.Text != "-" && subTotal.Text == "0")
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Please Add Items to Cart');</script>");
            }



            else 
            {
                // CUSTOMER NUMBER  FROM SEARCH WINDOW
                CustomerNum = lblCustomerNumber.Text;

                try
                {
                    CsOrder newOrder = new CsOrder(OrderNum, CustomerNum, OrderDate);

                    // INSERT ORDER + GET ORDER NUMBER
                    ConnectionClass.CreateOrder(newOrder);


                    // INSERT ORDER NUMBER INTO ORDERITEM TABLE (ITABLE)
                    for (int a = 0; a < iTable.Rows.Count; a++)
                    {
                        iTable.Rows[a]["orderno"] = newOrder.OrderNumber;
                    }

                    // REBUILD GRIDVIEW
                    //GridView1.DataSource = iTable;    
                    //GridView1.DataBind();



                    // UPLOAD ORDERITEM TABLE (ITABLE)
                    ConnectionClass.UploadOrderItem(iTable);



                    // PASS SESSION VALUE (ORDER NUMBER)
                    Session["ONUM"] = newOrder.OrderNumber;
                    Session["CNAME"] = lblCustomerName.Text;
                    Session["CNUM"] = lblCustomerNumber.Text;

                    // EMPTY ITABLE

                    //Session["iTable"] = null;
                    iTable.Clear();
                    //subTotal.Text = "0";
                    //grandTotal.Text = "0";
                    //GridView1.DataSource = iTable;
                    //GridView1.DataBind();
                    //lblCustomerName.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                    //lblCustomerNumber.Text = "-";






                    //SUCCESS MESSAGE 
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Order Confirmed');</script>");
                    ClientScript.RegisterStartupScript(this.Page.GetType(), "","window.open('012pos_seeOrderReceipt.aspx','window','toolbar=0,scrollbars=0,location=0,statusbar=0,menubar=0,resizable=0,height=350,width=700,left=130,top=220');", true);
                    
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "refresh", "window.location.href=window.location;", true);


                }

                catch
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Error Occured,Please try again later. ');</script>");
                }

                finally
                {
     
                  
                }

            }

        }

    }
}