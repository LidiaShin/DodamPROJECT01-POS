using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;


namespace DodamPOS
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LINQforREPORTDataContext Sample = new LINQforREPORTDataContext();

            var linkQuery = from tblProvince in Sample.tblProvinces
                                   select tblProvince;
            GridView1.DataSource = linkQuery;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

           


        }
    }
}