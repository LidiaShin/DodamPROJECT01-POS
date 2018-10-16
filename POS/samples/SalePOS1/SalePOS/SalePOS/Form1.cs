using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalePOS
{
    public partial class Form1 : Form
    {
        string imgLoc = "";
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-1SRPC5I;Initial Catalog=posMidtermDatabase;Integrated Security=True");
        SqlCommand cmd;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "JPG Files(*.jpg)|*.jpg|GIF image(*.gif)|*.gif|PNG image(*.png)|*.png|All Files (*.*)|*.*";
                dlg.Title = "Select Item Picture";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    imgLoc = dlg.FileName.ToString();
                    MessageBox.Show(dlg.FileName.ToString());
                    picItem.ImageLocation = imgLoc;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            
            if (txtCategory.Text == "" || txtItemName.Text == "" || txtPrice.Text == "")
            {
                return;
            }
            double parsedValue;
            if (!double.TryParse(txtPrice.Text, out parsedValue))
            {
                MessageBox.Show("Please Add Correct Price(Only Numbers)");
                return;
            }
            try
            {
                byte[] img = null;
                FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                BinaryReader rdr = new BinaryReader(fs);
                img = rdr.ReadBytes((int)fs.Length);
                string sql = "Insert Into tblMenuItems(itemID,itemName,itemCategory,itemPrice,itemImage)values(Next value for createID.seq_MenuID,'" + txtItemName.Text + "','" + txtCategory.Text + "','" + txtPrice.Text + "',@img)";
                if (cn.State != ConnectionState.Open)
                    cn.Open();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(new SqlParameter("@img", img));
                int x = cmd.ExecuteNonQuery();
                cn.Close();
                txtPrice.Text = "";
                txtItemName.Text = "";
                txtCategory.Text = "";
                picItem.Image = null;
                MessageBox.Show(x.ToString() + "record(s) saved");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cn.Close();
            }
        }

        private void btnADDUSER_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "" || txtPassword.Text == "" || txtPosition.Text == "")
            {
                MessageBox.Show("Please Enter required information");
                return;
            }
            try
            {
                string sql = "Insert Into tblEmployeeInfo(userID,userName,password,position,firstName,lastName,phone,address)values(Next value for addValue.seq_userID,'" + txtUserName.Text + "','" + txtPassword.Text + "','" + txtPosition.Text + "','" + txtFirstName.Text + "','" + txtLastName.Text + "','" + txtPhone.Text+ "','" + txtAddress.Text+ "')";
                if (cn.State != ConnectionState.Open)
                    cn.Open();
                cmd = new SqlCommand(sql, cn);
                int x = cmd.ExecuteNonQuery();
                cn.Close();
                txtUserName.Text = "";
                txtAddress.Text = "";
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtPassword.Text = "";
                txtPhone.Text = "";
                txtPosition.Text = "";

                MessageBox.Show(x.ToString() + "record(s) saved");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnGetUser_Click(object sender, EventArgs e)
        {
            if(txtUserName.Text=="")
            {
                MessageBox.Show("Please Enter User Name");
                return;
            }
            try
            {
                string sql = "select password,position,firstName,lastName,phone,address from tblEmployeeInfo where userName="+txtUserName.Text; 
                if (cn.State != ConnectionState.Open)
                    cn.Open();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();

        }
    }
}
