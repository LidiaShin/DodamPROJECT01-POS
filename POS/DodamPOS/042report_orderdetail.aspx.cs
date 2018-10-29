using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DodamPOS
{
    public partial class _042report_orderdetail : System.Web.UI.Page
    {
        // RECEIPT
        public string orderNum { get; set; }
        public DataTable reTable { get; set; }
        public DataTable toTable { get; set; }

        public DataTable ceTable { get; set; }

        // CUSTOMER

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["OrderNum"] != null && !IsPostBack)
            {

                lblONum.Text = Session["OrderNum"].ToString();
                orderNum = lblONum.Text;

                CsReceipt recept = new CsReceipt(orderNum, reTable, toTable);
                ConnectionClass.DisplayReceipt(recept);


                GridView1.DataSource = recept.ReceiptTable;
                GridView1.DataBind();

                
                lblTQty.Text = recept.TotalTable.Rows[0][0].ToString();
                lblTAmt.Text = recept.TotalTable.Rows[0][1].ToString();
                lblTTax.Text = recept.TotalTable.Rows[0][2].ToString();
                lblGTotal.Text = recept.TotalTable.Rows[0][3].ToString();

                CsReceiptInfo info = new CsReceiptInfo(orderNum, ceTable);
                ConnectionClass.ViewCustomer(info);

                lblCInfo.Text = info.CustomerInfo.Rows[0][2].ToString() + " " +
                                info.CustomerInfo.Rows[0][3].ToString();
                lblDate.Text = info.CustomerInfo.Rows[0][1].ToString();








            }
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
    }
}