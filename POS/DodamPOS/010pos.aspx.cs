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

   
                Session["sub"] = new double();
                Session["cart"] = new List<string>();
                Session["cartprice"] = new List<string>();
                Session["cartqty"] = new List<string>();
                Session["cartname"] = new List<string>();

                Session["iTable"] = new DataTable();

                iTable.Columns.Add("No", typeof(string));
                iTable.Columns.Add("name", typeof(string));
                iTable.Columns.Add("price", typeof(double));
                iTable.Columns.Add("qty", typeof(double));

                iTable.Columns.Add("subtotal", typeof(double));

            }

            else if (!IsPostBack && Session["itemCat"] == null)
            {
                CurrentPageIndex = 0;
                ItemViewByCat("All");

                Session["sub"] = new double();
                Session["cart"] = new List<string>();
                Session["cartprice"] = new List<string>();
                Session["cartqty"] = new List<string>();
                Session["cartname"] = new List<string>();

                Session["iTable"] = new DataTable();

                iTable.Columns.Add("No", typeof(string));
                iTable.Columns.Add("name", typeof(string));
                iTable.Columns.Add("price", typeof(string));
                iTable.Columns.Add("qty", typeof(string));
                iTable.Columns.Add("subtotal", typeof(double));
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


        protected void LinkButton2_Click(object sender, EventArgs e)
        { 
            CurrentPageIndex++;
            ItemViewByCat(CatSelect.Text);
            
        }
        protected void LinkButton3_Click(object sender, EventArgs e)
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


        protected void SelectCat(object sender, EventArgs e)
                {
                    Button btn = (Button)(sender);
                    string myCat = btn.CommandArgument;
                    CatSelect.Text = myCat;
                    Session["itemCat"] = CatSelect.Text;
                    CurrentPageIndex = 0;
                    ItemViewByCat(myCat); 
            
                 }


        //List<string> cart {
        //    get
        //    {return (List<string>)Session["cart"];}
            
        //    set
        //    {Session["cart"] = value;}
        //}


        //List<string> cartprice
        //{
        //    get
        //    { return (List<string>)Session["cartprice"]; }

        //    set
        //    { Session["cartprice"] = value; }
        //}

        //List<string> cartqty
        //{
        //    get
        //    { return (List<string>)Session["cartqty"]; }

        //    set
        //    { Session["cartqty"] = value; }
        //}

        //List<string> cartname
        //{
        //    get
        //    { return (List<string>)Session["cartname"]; }

        //    set
        //    { Session["cartname"] = value; }
        //}


        
        public double subtotal
        {
            get
            {
                if (Session["sub"] == null)
                    return 0;
                else
                    return Convert.ToDouble(Session["sub"]);
            }
            set
            {
                Session["sub"] = value;
            }
        }

        protected void RowDelete(object sender, GridViewDeleteEventArgs e)
        {
            DataTable jTable = (DataTable)Session["iTable"];

            jTable.Rows[e.RowIndex].Delete();
            GridView1.DataSource = jTable;
            GridView1.DataBind();

            object Sum = jTable.Compute(" SUM(subtotal) ", "");
            double NetTotal = Double.Parse(Sum.ToString());
            subTotal.Text = NetTotal.ToString();


        }

        protected void RowCreate(object sender, GridViewRowEventArgs e)
        {

            e.Row.Cells[0].Width = 100;
            e.Row.Cells[1].Width = 50;
            e.Row.Cells[2].Width = 160;
            e.Row.Cells[3].Width = 100;
            e.Row.Cells[4].Width = 50;
            e.Row.Cells[5].Width = 120;

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

    
            protected void SelectItem(object sender, EventArgs e)
        {

            if (Session["ii"] == null)
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Please  ');</script>");
            }

            else
            {
                ImageButton ibtn = (ImageButton)(sender);
                string itemNo = Convert.ToString(ibtn.CommandArgument);

                CsItem theitem = new CsItem(itemNo, iCategory, iName, iPPrice, iRPrice, iNote, iImage, iQuantity, iRday);

                ConnectionClass.GetItemDetail(theitem);


                iTable.Rows.Add(itemNo,theitem.itemName, theitem.itemRPrice, Convert.ToString(Session["ii"]),
                    Convert.ToDouble(theitem.itemRPrice) * Convert.ToDouble(Session["ii"]));

                GridView1.DataSource = iTable;     
                GridView1.DataBind();

                object Sum = iTable.Compute(" SUM(subtotal) ", "");
                double NetTotal = Double.Parse(Sum.ToString());

                subTotal.Text = NetTotal.ToString();
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

        protected void test(object sender, EventArgs e)
        {           
            subtotal = 0;
            subTotal.Text = "0";
        }

       
    }
}