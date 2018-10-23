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

                iTable.Columns.Add("No", typeof(string));
                iTable.Columns.Add("name", typeof(string));

                iTable.Columns.Add("unit price", typeof(double));
                iTable.Columns.Add("qty", typeof(double));
                iTable.Columns.Add("price", typeof(double));

                iTable.Columns.Add("tax", typeof(double));

                //Label2.Text= lblCustomerName.Value.ToString();

            }

            else if (!IsPostBack && Session["itemCat"] == null)
            {
                CurrentPageIndex = 0;
                ItemViewByCat("All");

                Session["iTable"] = new DataTable();

                iTable.Columns.Add("No", typeof(string)); //Cell [0]
                iTable.Columns.Add("name", typeof(string)); // Cell[1]

                iTable.Columns.Add("unit price", typeof(double)); // Cell[2]
                iTable.Columns.Add("qty", typeof(double)); // Cell [3]
                iTable.Columns.Add("price", typeof(double)); //Cell[4]

                iTable.Columns.Add("tax", typeof(double)); // Cell [5]

                //Label2.Text = lblCustomerName.Value.ToString();

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
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('error');</script>");
                }
                //finally
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


        protected void LinkButton2_Click(object sender, EventArgs e) // page previous
        { 
            CurrentPageIndex++;
            ItemViewByCat(CatSelect.Text);
            
        }
        protected void LinkButton3_Click(object sender, EventArgs e) // page next
        {
            CurrentPageIndex--;
            ItemViewByCat(CatSelect.Text);

        }

        public ArrayList Stock(int inCount)
        {
            ArrayList values = new ArrayList();

            for (int i = -1; i < inCount; i++)
            {
                values.Add("" + (i+1)); // increment i and add.
            }

            return values;
        }


        protected void SelectCat(object sender, EventArgs e) // Select Category Button
                {
                    Button btn = (Button)(sender);
                    string myCat = btn.CommandArgument;
                    CatSelect.Text = myCat;
                    Session["itemCat"] = CatSelect.Text;
                    CurrentPageIndex = 0;
                    ItemViewByCat(myCat);      
                 }

        // CLICK BUTTON FOR CUSTOMER SEARCHING     
        protected void SearchCustomer(object sender,EventArgs e)
        {
            //searchName = SearchBox.Value.ToString();
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


        string name
        {
            get
            { return (string)ViewState["name"]; }

            set
            { ViewState["name"] = value; }
        }

        protected void convert(object sender, EventArgs e)
        {
            ViewState["name"]= IptHdn.Value.ToString();
            lblCustomerName.Text = name;
            
        }




        protected void RowDelete(object sender, GridViewDeleteEventArgs e) // Cancel Cart Item
        {
            DataTable jTable = (DataTable)Session["iTable"];

            //Double CancelItemQty = Double.Parse(jTable.Rows[e.RowIndex][3].ToString());
            jTable.Rows[e.RowIndex].Delete();
            
            GridView1.DataSource = jTable;
            GridView1.DataBind();

            
            if (jTable.Rows.Count>0)
            {
                object Sum = jTable.Compute(" SUM(price) ", "");
                double NetTotal = Double.Parse(Sum.ToString());
                double GrandTotal = NetTotal * 1.13;
                subTotal.Text = NetTotal.ToString();
                grandTotal.Text = GrandTotal.ToString();
            }

            else
            {
                subTotal.Text = "0";
            }
        }

        protected void RowCreate(object sender, GridViewRowEventArgs e) // Start Shopping
        {
            e.Row.Cells[0].Width = 100; // Cancel button Cell
            e.Row.Cells[1].Width = 50; // item No Cell
            e.Row.Cells[2].Width = 160; // item Name Cell
            e.Row.Cells[3].Width = 100; // item Unit Price Cell
            e.Row.Cells[4].Width = 50;  // item Qty Cell
            e.Row.Cells[5].Width = 120; // item Price Cell
            e.Row.Cells[6].Width = 120;
            //e.Row.Cells[6].Visible = false; // invoice Customer name Cell (invisible)
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

        DataTable jTable
        {
            get
            { return (DataTable)Session["jTable"]; }

            set
            { Session["jTable"] = value; }
        }

        

        protected void SelectItem(object sender, EventArgs e) // Click Item Image : Select Item into Cart
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

                ConnectionClass.GetItemDetail(theitem);

                bool found = false;

                if (iTable.Rows.Count > 0) //두번째 담을때부터...
                {
                    foreach (DataRow iRow in iTable.Rows)
                    {
                        if (Convert.ToString(iRow["No"]) == itemNo) // 카트에 이미 담겨진 아이템이라면 (=No 가 일치한다면)
                        {
                            double temp = Convert.ToDouble(iRow["qty"]);
                            double uptemp = Convert.ToDouble(Session["ii"]) + temp;

                            if (uptemp > Convert.ToDouble(theitem.itemQuantity))
                            {
                                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Too Many! ');</script>");
                            }

                            else
                            {
                                iRow["qty"] = Convert.ToDouble(Session["ii"]) + temp;
                                iRow["price"] = Convert.ToDouble(iRow["qty"]) * Convert.ToDouble(iRow["price"]);// 아이템 갯수 업데이트                              
                            }
                            found = true;
                        }
                    }

                    if (!found) // 카트에 없는 아이템이라면 (처음으로 추가되는 아이템이라면)
                    {
                        iTable.Rows.Add(itemNo, theitem.itemName, Convert.ToDouble(theitem.itemRPrice), Convert.ToDouble(Session["ii"]),
                         Convert.ToDouble(theitem.itemRPrice) * Convert.ToDouble(Session["ii"]), Convert.ToDouble(theitem.itemRPrice)*0.13);
                    }                 
                }
                
                else // 쇼핑 시작!
                {
                iTable.Rows.Add(itemNo, theitem.itemName, Convert.ToDouble(theitem.itemRPrice), Convert.ToDouble(Session["ii"]),
                            Convert.ToDouble(theitem.itemRPrice) * Convert.ToDouble(Session["ii"]), Convert.ToDouble(theitem.itemRPrice)*0.13);
                }
                GridView1.DataSource = iTable;    //그리드뷰1에 데이터 넣어줌 
                GridView1.DataBind(); 



                object Sum = iTable.Compute(" SUM(price) ", "");
                double NetTotal = Double.Parse(Sum.ToString());
                double GrandTotal = NetTotal * 1.13;

                subTotal.Text = NetTotal.ToString();
                grandTotal.Text = GrandTotal.ToString();
                Session["ii"] = null;
            }
            
        }





        protected void SelectCartQty(object sender, EventArgs e)
        {
            //cast the sender back to a dropdownlist
            DropDownList ddl = sender as DropDownList;

            //get the namingcontainer from the dropdownlist and cast it as a datalistitem
            DataListItem item = ddl.NamingContainer as DataListItem;

            //now use findcontrol to find the label in the datalistitem
            Label lbl = item.FindControl("QtySelect") as Label;

            lbl.Text = ddl.SelectedValue.ToString();
            Session["ii"] = lbl.Text;
        }



        protected void CheckOut(object sender, EventArgs e)
        {
            if (subTotal.Text == "0")
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Please Choose Item');</script>");
            }

            else
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Thank you ');</script>");
               

                string test = iTable.Rows[0]["name"].ToString();
                Label2.Text = test;


            }

        }

    }
}