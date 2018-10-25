using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DodamPOS
{
    public partial class _012pos_seeOrderReceipt : System.Web.UI.Page
    {

        string orderNum { get; set; }
        DataTable reTable { get; set; }
        DataTable toTable { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            // Session["ONUM"] = newOrder.OrderNumber; 

            if (Session["ONUM"] != null && Session["CNAME"] != null && !IsPostBack)
            {
                lblONum.Text = Session["ONUM"].ToString();
                lblCName.Text = Session["CNAME"].ToString();

                orderNum = lblONum.Text;

                try
                {
                    CsReceipt recept = new CsReceipt(orderNum, reTable, toTable);
                    ConnectionClass.DisplayReceipt(recept);

                    GridView1.DataSource = recept.ReceiptTable;
                    GridView1.DataBind();
                   

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
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('No Order');</script>");
            }
        }



        protected void RowCreate(object sender, GridViewRowEventArgs e) // Start Shopping
        {
            e.Row.Cells[0].Width = 20; // CODE
            e.Row.Cells[1].Width = 160; //  ITEM NAME
            e.Row.Cells[2].Width = 60; // PRICE
            e.Row.Cells[3].Width = 40; // QTY
            e.Row.Cells[4].Width = 80;  // AMOUNT
            e.Row.Cells[5].Width = 40; // TAX
         
           
        }
    }
}