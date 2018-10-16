using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COMP229
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        string username { get; set; }
        string email { get; set; }
        string password { get; set; }

        protected void btn_Click(object sender, EventArgs e)
        {
            username = uName.Text;
            email = eMail.Text;
            password = pWord.Text;


            if (Regex.IsMatch(email, "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$"))
            {
                emailcheck.Text = "Valid Email";

                SignUpInfo newUserInfo = new SignUpInfo(username, email, password);
                ConnectionClass.AvoidDuplicateEmail(newUserInfo);

                if (newUserInfo.eMailAddress == "EE")
                {
                    Response.Write("<script type='text/javascript'>");
                    Response.Write("alert('Please use other email');");
                    Response.Write("</script>");
                }

                else
                {
                    try
                    {
                        ConnectionClass.SignUp(newUserInfo);
                        ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Thank you for signup!'); document.location.href='login.aspx';</script>");
                      
                    }

                    catch
                    {
                        Response.Write("<script type='text/javascript'>");
                        Response.Write("alert('Failed ');");
                        Response.Write("</script>");
                    }

                    finally
                    {

                    }

                }
            }

            else
            {
                emailcheck.Text = "invalid email";
                emailcheck.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}