using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DodamPOS
{
    public partial class _012pos_seeOrderReceipt : System.Web.UI.Page
    {
        // RECEIPT INFO
        public string orderNum { get; set; }
        public DataTable reTable { get; set; }
        public DataTable toTable { get; set; }

        // CUSTOMER INFO

        public string Cnum { get; set; } // CUSTOMER ID
        public string CFname { get; set; }
        public string CLname { get; set; }

        public string CAddress { get; set; }
        public string Ccity { get; set; }
        public string Cprovince { get; set; }
        public string CPcode { get; set; }
        public string CPhone { get; set; }
        public string CEmail { get; set; } // EMAIL
        public string CRDate { get; set; }
        public string Clv { get; set; }

        public string CNote { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (Session["ONUM"] != null && Session["CNAME"] != null && !IsPostBack)
            {
                lblONum.Text = Session["ONUM"].ToString();
                lblCName.Text = Session["CNAME"].ToString();
                lblCNum.Text = Session["CNUM"].ToString();

                Cnum = Session["CNUM"].ToString();

                orderNum = lblONum.Text;

                try
                {
                    CsReceipt recept = new CsReceipt(orderNum, reTable, toTable);
                    ConnectionClass.DisplayReceipt(recept);


                    GridView1.DataSource = recept.ReceiptTable;
                    GridView1.DataBind();

                    CsCustomer thisCustomer = new CsCustomer(Cnum, CFname, CLname, CAddress, Ccity, Cprovince, CPcode, 
                    CPhone, CEmail, CNote, CRDate, Clv);
                    ConnectionClass.GetCustomerDetail(thisCustomer);

                    lblCEmail.Text = thisCustomer.cEmail;

                    lblOrderDate.Text = recept.TotalTable.Rows[0][4].ToString();
                    lblTQty.Text = recept.TotalTable.Rows[0][0].ToString();
                    lblTAmt.Text = recept.TotalTable.Rows[0][1].ToString();
                    lblTTax.Text = recept.TotalTable.Rows[0][2].ToString();
                    lblGTotal.Text = recept.TotalTable.Rows[0][3].ToString();
                }

                catch
                {
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('error');</script>");
                }
                finally
                {

                }
            }



            else
            {
                //ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('No Order');</script>");
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }

        protected void RowCreate(object sender, GridViewRowEventArgs e) 
        {
            e.Row.Cells[0].Width = 20; // CODE
            e.Row.Cells[1].Width = 160; //  ITEM NAME
            e.Row.Cells[2].Width = 60; // PRICE
            e.Row.Cells[3].Width = 40; // QTY
            e.Row.Cells[4].Width = 80;  // AMOUNT
            e.Row.Cells[5].Width = 40; // TAX
         
           
        }

        string email { get; set; }
        string subject { get; set; }
        string content { get; set; }

        private string GridViewToHtml(GridView gv)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gv.RenderControl(hw);
            return sb.ToString();
        }
        protected void btnEmail_Click(object sender, EventArgs e)
        {
            email = lblCEmail.Text;

            subject = "Thank you for your purchase, " + lblCName.Text;

            string content1 = "<body style=\"text-align:center; background-color:#d8dfe5; padding-right:20%; padding-left:20%; \">";

            string content2 = " <p style=\"font-size:20px;\"> Thank you for your purchase this time, Below is receipt details</p>" + "<br>";

            string content3 = " <p style=\"font-size:14px; font-family:verdana; text-align:left;\"> Receipt #  " + lblONum.Text + "</p>";

            string content4 = GridViewToHtml(GridView1) + "<br>";

            string content5 = "<div style=\"text-align:right; font-size:16px; \">";

            string content6 = "Sales Quantity Total: " + lblTQty.Text + "<br>";
            string content7 = "Net Total : " + lblTAmt.Text + "<br>";
            string content8 = "Grand Total: " + lblGTotal.Text + "</div> <br>";
            string content9 = "<p style=\"color:#405359; \"> For all returns, please bring this receipt with you </p>" + "</body>";

            content = content1 + content2 + content3 + content4 + content5 + content6 + content7 + content8 + content9;

            CsRegisterEmail newemail = new CsRegisterEmail(subject, content, email);

            try
            {
                ConnectionClass.SendRegisterEmail(newemail);
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('email sent out.');</script>");
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