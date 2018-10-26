using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DodamPOS
{
    public partial class _004report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnDailyReport_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.Page.GetType(), "",
"window.open('041report_today.aspx','window','toolbar=0,scrollbars=0,location=0,statusbar=0,menubar=0,resizable=0,height=540,width=800,left=130,top=40');", true);
        }
    }
}