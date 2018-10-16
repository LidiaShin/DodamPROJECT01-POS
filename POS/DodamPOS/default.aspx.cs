using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DodamPOS
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                Response.Redirect("main.aspx");
            }

        }
        string username { get; set; }
        string password { get; set; }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            username = uname.Text;
            password = pword.Text;

            CsUserlist userinfo = new CsUserlist(username, password);

            if (ConnectionClass.SignIn(userinfo))
            {
                FormsAuthentication.RedirectFromLoginPage(username, CheckBox.Checked);
                
            }


           

            else
            {
                Response.Write("<script type='text/javascript'>");
                Response.Write("alert('Please check your username and password');");
                Response.Write("</script>");
            }

          

        }
    }
}