using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalePOS
{
    public partial class LogIn : Form
    {
        public User currentUser;
        btnLogOut OrderScreen;
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-1SRPC5I;Initial Catalog=posMidtermDatabase;Integrated Security=True");
        SqlCommand cmd;
        List<User> userList;
        public LogIn()
        {
           
            InitializeComponent();
            //loadUsers();
            
        }
        void loadUsers()
        {
            userList = new List<User>();
            string id, userName, pass, position, name, surname, phone, add;
            string sql = "Select userId,userName,password,position,firstName,lastName,phone,address from tblEmployeeInfo";
            try
            {
                if (cn.State != ConnectionState.Open)
                    cn.Open();
                cmd = new SqlCommand(sql, cn);
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        id = rdr[0].ToString();
                        id = id.Replace(" ", "");
                        userName = rdr[1].ToString();
                        userName = userName.Replace(" ", "");
                        pass = rdr[2].ToString();
                        pass = pass.Replace(" ", "");
                        position = rdr[3].ToString();
                        position = position.Replace(" ", "");
                        name = rdr[4].ToString();
                        name = name.Replace(" ", "");
                        surname = rdr[5].ToString();
                        phone = rdr[6].ToString();
                        phone = phone.Replace(" ", "");
                        add = rdr[7].ToString();
                        userList.Add(new User(id, userName, pass, position, name, surname, phone, add));

                    }
                }
                cn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }
        
        private void LogIn_Load(object sender, EventArgs e)
        {
            loadUsers();
            loadCbUserName();
           // OrderScreen = new btnLogOut();
        }
        void loadCbUserName()
        {
            foreach (User item in userList)
            {
                txtUserName.Items.Add(item.UserName);
            }
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < userList.Count; i++)
            {
                if (userList[i].UserName == txtUserName.Text)
                {
                    if (userList[i].Password == txtPassword.Text)
                    {
                        btnLogOut.logInStatus = 1;
                        currentUser = userList[i];
                        //OrderScreen.changeStatus();
                        // OrderScreen.changeStatus();
                    }
                    else
                    {
                        MessageBox.Show(userList[i].Password +"-"+ txtPassword.Text);
                    }
                }
            }
            txtPassword.Text = "";
            txtUserName.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
