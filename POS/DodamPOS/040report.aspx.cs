using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DodamPOS
{
    public partial class _004report : System.Web.UI.Page
    {

        // LIST
        DataTable InvoiceTable { get; set; }

        // KEYWORD

        string KeyWordName { get; set; }
        string KeyWordNum { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // SEARCH KEYWORD
                List<string> searchKeywords = new List<string>();
                searchKeywords.Add("Name");
                searchKeywords.Add("No");

                SearchDDL.DataSource = searchKeywords;
                SearchDDL.DataBind();

                InvoiceListView();
            }
        }

        // WHOLE LIST
        public void InvoiceListView()
        {
            CsInvoice list = new CsInvoice(InvoiceTable);
            
            try
            {
                ConnectionClass.DisplayInvoice(list);
                InvoiceList.DataSource = list.InvoiceList;
                InvoiceList.DataBind();
               
            }
            catch
            {
                TEST.Text = "Error Occured, Please try reloading page. Sorry for inconvenience";
            }

            finally
            {

            }
        }


        public void FilterInvoiceByName()
        {
            KeyWordName = keywordbox.Text;
            CsSearchInvoice filist = new CsSearchInvoice(KeyWordName, KeyWordNum, InvoiceTable);

            try
            {
                ConnectionClass.SearchInvoiceByName(filist);
                InvoiceList.DataSource = filist.Invoicelist;
                InvoiceList.DataBind();

            }
            catch
            {
                TEST.Text = "Error Occured, Please try reloading page. Sorry for inconvenience";
            }

            finally
            {

            }
        }


        public void FilterInvoiceByNumber()
        {
            KeyWordNum = keywordbox.Text;
            CsSearchInvoice filist = new CsSearchInvoice(KeyWordName, KeyWordNum, InvoiceTable);

            try
            {
                ConnectionClass.SearchInvoiceByNum(filist);
                InvoiceList.DataSource = filist.Invoicelist;
                InvoiceList.DataBind();

            }
            catch
            {
                TEST.Text = "Error Occured, Please try reloading page. Sorry for inconvenience";
            }

            finally
            {

            }
        }





        protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (InvoiceList.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

            // SEARCH BY NAME

            if (Convert.ToString(SearchDDL.SelectedValue) == "Name")
            {
                FilterInvoiceByName();
            }

            // SEARCH BY NOTE
            else if (Convert.ToString(SearchDDL.SelectedValue) == "No")
            {
                FilterInvoiceByNumber();
            }

            // NO SELECTION
            else
            {
                InvoiceListView();
            }
        }
     



        protected void SearchReceipt(object sender,EventArgs e)
        {

            // SEARCH BY NAME

            if (Convert.ToString(SearchDDL.SelectedValue) == "Name")
            {
                FilterInvoiceByName();
            }

            // SEARCH BY NOTE
            else if (Convert.ToString(SearchDDL.SelectedValue) == "No")
            {
                FilterInvoiceByNumber();
            }

            // NO SELECTION
            else
            {
                InvoiceListView();
            }


        }


        // PRESS ORDERNUMBER LINKBUTTON TO SEE DETAIL
        protected void SeeOrderDetail(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)(sender);

            // PASS ORDERNUMBER AS A SESSION VALUE
            Session["OrderNum"] = Convert.ToString(lbtn.CommandArgument);
            ClientScript.RegisterStartupScript(this.Page.GetType(), "", "window.open('042report_orderdetail.aspx','window','toolbar=0,scrollbars=0,location=0,statusbar=0,menubar=0,resizable=0,height=350,width=700,left=130,top=220');", true);
        }



        protected void BtnDailyReport_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.Page.GetType(), "",
"window.open('041report_today.aspx','window','toolbar=0,scrollbars=0,location=0,statusbar=0,menubar=0,resizable=0,height=560,width=850,left=130,top=40');", true);
        }
    }
}