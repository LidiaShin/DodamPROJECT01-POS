using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DodamPOS
{
    public partial class _011pos_seeCustomerList : System.Web.UI.Page
    {

        DataTable CustomerTable { get; set; }
        string nameKeyword { get; set; }
        string emailKeyword { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SearchName"] != null && !IsPostBack)
            {
                SearchListView();
            }
            else
            {

            }

        }


        protected void SelectName(object sender, EventArgs e)
        {
      
            LinkButton lbtn = (LinkButton)(sender);          
            String CustomerName = Convert.ToString(lbtn.CommandArgument);
        
            CustomerSelection.Value = CustomerName;        
            Page.ClientScript.RegisterStartupScript(GetType(),"MyKey", "SendName();", true);

        }
        public void SearchListView()
        {
            nameKeyword = Session["SearchName"].ToString();
            CsFilteredCustomerList nfcustomerlist = new CsFilteredCustomerList(nameKeyword, emailKeyword, CustomerTable);

            try
            {
              
                ConnectionClass.SearchCustomerByName(nfcustomerlist);
                CustomerList.DataSource = nfcustomerlist.fCustomerList;
                CustomerList.DataBind();               
            }

            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('error');</script>");
            }

            finally
            {

            }
        }

   
    }
}