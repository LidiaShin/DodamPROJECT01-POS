using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SalePOS
{
    public partial class ucCustomerInfo : UserControl
    {
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-1SRPC5I;Initial Catalog=posMidtermDatabase;Integrated Security=True");
        SqlCommand cmd;
        public ucCustomerInfo()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if (txtContactName.Text == "" || txtPhone.Text == "")
            {
                MessageBox.Show("Please Add Contact name and phone number.");
                return;
            }
            try
            {
                
               string sql = "Insert Into tblCustomerInfo(custID,compName,contactName,contactTitle,address,city,province,country,POSTALCODE,phone,FAX)values(Next value for addValue.seq_custID,'" + txtCompanyName.Text + "','" + txtContactName.Text + "','" + txtContactTitle.Text + "','" + txtAddress.Text + "','" + txtCity.Text + "','" + txtRegion.Text + "','" + txtCountry.Text + "','" + txtPostalCode.Text + "','" + txtPhone.Text + "','" + txtFax.Text + "')";
                if (cn.State != ConnectionState.Open)
                    cn.Open();
                cmd = new SqlCommand(sql, cn);
               
                int x = cmd.ExecuteNonQuery();
                cn.Close();
                
                MessageBox.Show(x.ToString() + "record(s) saved");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cn.Close();
            }
        }
        void clear()
        {
            txtAddress.Text = "";
            txtCity.Text = "";
            txtCompanyName.Text = "";
            txtContactName.Text = "";
            txtCountry.Text = "";
            txtContactTitle.Text = "";
            txtFax.Text = "";
            txtPostalCode.Text = "";
            txtPhone.Text = "";
            txtRegion.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
