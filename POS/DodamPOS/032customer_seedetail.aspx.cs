using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DodamPOS
{
    public partial class _032customer_seedetail : System.Web.UI.Page
    {

        public string firstName { get; set; }
        public string lastName { get; set; }

        public string address { get; set; }
        public string city { get; set; }
        public string province { get; set; }
       
        public string postalCode { get; set; }
        public string phonenumber { get; set; }
        public string emailAddress { get; set; }
        public string registerDate { get; set; }
        public string levels { get; set; }

        public string notes { get; set; }

        public string cnum { get; set; }


        DataTable ProvinceTable { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customerNum"] != null && !IsPostBack)
            {
                cnumlbl.Text = Session["customerNum"].ToString();

                cnum = cnumlbl.Text;

                DisableTextBoxes(Page);

                try
                {
                    CsCustomer thatCustomer = new CsCustomer(cnum, firstName, lastName, address, city, province, postalCode, phonenumber, emailAddress, notes, registerDate, levels);

                    ConnectionClass.GetCustomerDetail(thatCustomer);

                    fnamebox.Text = thatCustomer.cFirstName;
                    lnamebox.Text = thatCustomer.cLastName;
                    addressbox.Text = thatCustomer.cAddress;
                    citybox.Text = thatCustomer.cCity;


                    emailbox.Text = thatCustomer.cEmail;
                    phonebox.Text = thatCustomer.cPhone;                
                    pcodebox.Text = thatCustomer.cPostalCode;                 
                    notebox.Text = thatCustomer.cNote;

                    provincelist.SelectedItem.Text = thatCustomer.cProvince;
                    //provincelist.Enabled = false;
                }

                catch
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('error');</script>");
                }

                finally
                {

                }
            }

            else if (Session["customerNum"] != null && IsPostBack)
            {
               
                //provincelist.Enabled = true;
            }
        }




        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            
            AbleTextBoxes(Page);
            provincelist.SelectedItem.Text = "- Please select province - ";

            CsProvincelist ProvinceList = new CsProvincelist(ProvinceTable);
            ConnectionClass.GetPVlist(ProvinceList);

           

            provincelist.DataSource = ProvinceList.Provinces;
            provincelist.DataTextField = ProvinceList.Provinces.Columns["provinceName"].ToString();
            provincelist.DataValueField = ProvinceList.Provinces.Columns["provinceCode"].ToString();
            provincelist.DataBind();

            //provincelist.Enabled = true;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
           
            cnum = cnumlbl.Text;
            firstName = fnamebox.Text;
            lastName = lnamebox.Text;
            address = addressbox.Text;


            city = citybox.Text;
            province = provincelist.SelectedValue.ToString();
            postalCode = pcodebox.Text;
            phonenumber = phonebox.Text;

            emailAddress = emailbox.Text;
            notes = notebox.Text;


            CsCustomer oldCustomerInfo = new CsCustomer(cnum, firstName, lastName, address, city, province, postalCode, phonenumber, emailAddress, notes, registerDate, levels);
            
            try
            {

                ConnectionClass.UpdateCustomerDetail(oldCustomerInfo);
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Updated!');</script>");
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Update failed');</script>");

            }

            finally
            {
                DisableTextBoxes(Page);
                provincelist.Enabled = false;

            }

        }


        protected void DisableTextBoxes(Control p1)
        {
            foreach (Control ctrl in p1.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox t = ctrl as TextBox;
                   
                    if (t != null)
                    {
                        t.Enabled = false;
                        t.CssClass = "CustomerOutput";
                    }
                }
               
                else if(ctrl is DropDownList)
                {
                    DropDownList d = ctrl as DropDownList;
                    if (d != null)
                    {
                        d.Enabled = false;
                        d.CssClass= "CustomerOutput";
                    }
                }


             

                else
                {
                    if (ctrl.Controls.Count > 0)
                    {
                        DisableTextBoxes(ctrl);
                    }
                }
            }
        }

        

        protected void AbleTextBoxes(Control p1)
        {
            foreach (Control ctrl in p1.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox t = ctrl as TextBox;
                    if (t != null)
                    {
                        t.Enabled = true;
                        t.CssClass = "CustomerInput";
                    }
                }

                else if (ctrl is DropDownList)
                {
                    DropDownList d = ctrl as DropDownList;
                    if (d != null)
                    {
                        d.Enabled = true;
                        d.CssClass = "ProvinceInput";
                    }
                }


                else
                {
                    if (ctrl.Controls.Count > 0)
                    {
                        AbleTextBoxes(ctrl);
                    }
                }
            }
        }

       
    }
}