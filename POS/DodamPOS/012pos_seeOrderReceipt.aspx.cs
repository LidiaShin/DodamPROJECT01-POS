using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DodamPOS
{
    public partial class _012pos_seeOrderReceipt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Session["ONUM"] = newOrder.OrderNumber; 

            if (Session["ONUM"] != null && Session["CNAME"] != null && !IsPostBack)
            {
                lblONum.Text = Session["ONUM"].ToString();
                lblCName.Text = Session["CNAME"].ToString();






            }
            else
            {

            }

        }
    }
}