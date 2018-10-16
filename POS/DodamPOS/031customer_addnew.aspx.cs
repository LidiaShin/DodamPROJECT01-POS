using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DodamPOS
{
    public partial class _031customer_addnew : System.Web.UI.Page
    {
        DataTable ProvinceTable { get; set; }

        // customer information
        string customernum { get; set; }
        string firstname { get; set; }
        string lastname { get; set; }
        string email { get; set; }
        string phone { get; set; }
        string address { get; set; }
        string city { get; set; }
        string province { get; set; }
        string postalcode { get; set; }
        string note { get; set; }

        string registerdate { get; set; }
        string level { get; set; }

        //email information
        string subject { get; set; }
        string content { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
           
            // Calling ProvinceList From DB
            if (!IsPostBack)
            {
                //provincelist.BackColor= System.Drawing.ColorTranslator.FromHtml(listcolor);
                //provincelist.Style.Add("border-radius", "5px");
                //provincelist.Style.Add("background-color", "rgba(142,150,175, 0.5)");

                //provincelist.Style.Add("outline", "1px dotted #333");

                //provincelist.BorderStyle= (BorderStyle)Enum.Parse(typeof(BorderStyle),
                //             provincelist.SelectedItem.Text);

                CsProvincelist ProvinceList = new CsProvincelist(ProvinceTable);

                try
                {
                    ConnectionClass.GetPVlist(ProvinceList);
                    provincelist.DataSource = ProvinceList.Provinces;
                    provincelist.DataTextField = ProvinceList.Provinces.Columns["provinceName"].ToString();
                    provincelist.DataValueField = ProvinceList.Provinces.Columns["provinceCode"].ToString();
                    provincelist.DataBind();
                }
                finally
                {

                }

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            firstname = fnamebox.Text;
            lastname = lnamebox.Text;
            email = emailbox.Text;
            phone = phonebox.Text;
            address = addressbox.Text;
            city = citybox.Text;
            province = provincelist.SelectedValue.ToString();
            postalcode = postalcodebox.Text;
            note = notebox.Text;

            CsCustomer newcustomer = new CsCustomer(customernum,firstname, lastname, address, city, province, postalcode, phone, email, note,registerdate, level);

            subject = "Thank you for registering, " + fnamebox.Text;
            content = @"<h2 style='color:blue;'> Hello " + fnamebox.Text + " ," + " Your account is created successfully. </h2> ";

            CsRegisterEmail newemail = new CsRegisterEmail(subject, content, email);

            try
            {
                ConnectionClass.RegistrationCustomer(newcustomer);

                ConnectionClass.SendRegisterEmail(newemail);

                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('New Customer Registered successfully and Confirmation email sent out.');</script>");



                ClearTextBoxes(Page);
                provincelist.ClearSelection();
            }

            catch
            {
                Response.Write("<script type='text/javascript'>");
                Response.Write("alert('please fill out all required fields ');");
                Response.Write("</script>");
            }

            finally
            {

            }
        }


        protected void ClearTextBoxes(Control p1)
        {
            foreach (Control ctrl in p1.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox t = ctrl as TextBox;

                    if (t != null)
                    {
                        t.Text = String.Empty;
                    }
                }

                else if(ctrl is DropDownList){
                    DropDownList d = ctrl as DropDownList;
                    if (d != null)
                    {

                        d.ClearSelection();
                    }
                }
                else
                {
                    if (ctrl.Controls.Count > 0)
                    {
                        ClearTextBoxes(ctrl);
                    }
                }
            }
        }



    }
}