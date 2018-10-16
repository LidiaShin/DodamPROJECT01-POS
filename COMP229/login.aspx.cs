using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COMP229
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        string email { get; set; }
        string password { get; set; }
        string username { get; set; }

        protected void btn_Click(object sender, EventArgs e)
        {
            email = eMail.Text;
            password = pWord.Text;

            SignUpInfo userinfo = new SignUpInfo(username, email, password);

            if (ConnectionClass.SignIn(userinfo))
            {
                FormsAuthentication.RedirectFromLoginPage(email, CheckBox.Checked);
                Session["login"] = email;
            }

            else
            {
                Response.Write("<script type='text/javascript'>");
                Response.Write("alert('Please check your email and password');");
                //Response.Write("document.location.href='login.aspx';");
                Response.Write("</script>");
            }

            ConnectionClass.SignIn(userinfo);


            /*ConnectionClass.SignIn(userinfo);

            if (userinfo.eMailAddress == "EM") //Email Matching
            {
                Session["login"] = userinfo.userName;






                Response.Write("<script type='text/javascript'>");
                Response.Write("alert('welcome');");
                Response.Write("document.location.href='main.aspx';");
                Response.Write("</script>");
            }

            else
            {

                Response.Write("<script type='text/javascript'>");
                Response.Write("alert('Please check your email and password');");
                //Response.Write("document.location.href='login.aspx';");
                Response.Write("</script>");
            }

          */
            
        }
    }
}