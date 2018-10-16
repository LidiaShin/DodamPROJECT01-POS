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
    public partial class btnLogOut : Form
    {
        Timer timer;
        public AddCustmore newCustomer = new AddCustmore();
        Form1 managementForm = new Form1();
        //ser currentUser = null;
        LogIn logInPage = new LogIn();
        public static int logInStatus = 0;
        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-1SRPC5I;Initial Catalog=posMidtermDatabase;Integrated Security=True");
        SqlCommand cmd;
        DataTable dt;
        List<Custmor> customerList;
        List<MenuItem> allItems;
        List<OrderItem> allOrderItems;
        List<Label> imageList;
        MenuItem currentItem=null;
        double subTotal = 0;
        double totalTax = 0;
        double total;
        const double Tax = 0.13;
        List<Label> logInList;

        //Timer method
        
       
        public btnLogOut()
        {

            InitializeComponent();
        }
        
        
        private void orderScreenSplit_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        void setDataTable()
        {
            dt = new DataTable("tblOrderItemList");
            
            dt.Columns.Add(new DataColumn("ID", typeof(string)));
            dt.Columns.Add(new DataColumn("Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Qty", typeof(string)));
            dt.Columns.Add(new DataColumn("Prize", typeof(string)));
           
        }
        void loadItems()
        {
            try
            {
                allItems = new List<MenuItem>();
                string sql = "Select itemID,itemName,itemCategory,itemPrice,itemImage from tblMenuItems";
                if (cn.State != ConnectionState.Open)
                    cn.Open();
                cmd = new SqlCommand(sql, cn);
                Image im=null;
                string id, name, category, prize;
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        byte[] img = (byte[])(rdr[4]);
                        if (img != null)
                        {
                            MemoryStream ms = new MemoryStream(img);
                            im = Image.FromStream(ms);
                        }
                        id = rdr[0].ToString();
                        id = id.Replace(" ", "");
                        name = rdr[1].ToString();
                        name = name.Replace(" ", "");
                        category = rdr[2].ToString();
                        category = category.Replace(" ", "");
                        prize = rdr[3].ToString();
                        prize = prize.Replace(" ", "");
                        allItems.Add(new MenuItem(id, name, category, prize, im));

                    }
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        void loadItemIntoFlowLayout()
        {
            foreach (var item in allItems)
            {
                //Label l = label(item);
                if(item.Category=="Food")
                    flpFood.Controls.Add(label(item));
                else if(item.Category=="Drink")
                    flpDrinks.Controls.Add(label(item));
                else if (item.Category == "Hardware")
                    flpFood.Controls.Add(label(item));
                else if (item.Category == "Misc")
                    flpFood.Controls.Add(label(item));
                //l.Click += L_Click;
            }
        }

        private void L_Click(object sender, EventArgs e)
        {
            
        }

        Label label(MenuItem item)
        {
            Label l = new Label();
            l.Name = "lbl_" + item.ID;
            l.Text = item.Name;
            
            l.Font = new Font("Serif", 8, FontStyle.Regular);
            l.Width = 50;
            l.Height = 80;
            l.Image = item.itemImage;
            l.TextAlign = ContentAlignment.BottomCenter;
            l.Margin = new Padding(2);
            l.Click += L_Click1;
            return l;
        }
        Label logIn(string location)
        {
            FileStream fs = new FileStream(location, FileMode.Open, FileAccess.Read);
            Image i = Image.FromStream(fs);
            
            Label l = new Label();
            l.Width = 80;
            l.Height = 80;
            l.Image = i;
            
           // l.Text = "l";
            return l;
            
        }
        Label BlueButton(string location)
        {
            FileStream fs = new FileStream(location, FileMode.Open, FileAccess.Read);
            Image i = Image.FromStream(fs);

            Label l = new Label();
            l.Width = 20;
            l.Height = 20;
            l.Image = i;

            // l.Text = "l";
            return l;

        }

        private void L_Click1(object sender, EventArgs e)
        {
            Label lb=null;
            if (sender is Label)
            {
                lb = sender as Label;
            }
            //lb.Text;
            foreach (var item in allItems)
            {
                if (item.Name.Equals(lb.Text))
                {
                    currentItem = item;
                    txtItemID.Text = Convert.ToString(item.ID);
                    //MessageBox.Show(item.ToString());
                }
            }
            
                
        }
        void setUpDatGridView()
        {
            dgvOrderedItem.DataSource = dt;
            dgvOrderedItem.Columns[0].Width = 25;
            dgvOrderedItem.Columns[1].Width = 100;
            dgvOrderedItem.Columns[2].Width = 25;
            dgvOrderedItem.BorderStyle = BorderStyle.FixedSingle;
        }
        
        private void OrderScreen_Load(object sender, EventArgs e)
        {
            
            timer = new Timer();
            allOrderItems = new List<OrderItem>();
            logInList = new List<Label>();
            mainSplit.SplitterDistance = 100;
            orderScreenSplit.SplitterDistance = 350;
            menuItemContainer.SplitterDistance = 425;
            loadCutomer();
            loadCustomerCB();
            setDataTable();
            setUpDatGridView();
            loadItems();
            loadItemIntoFlowLayout();
            loadLoginButton();
            loadStatus();
            timer.Interval = 2000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            changeStatus();
        }
        void loadStatus()
        {
            imageList = new List<Label>();
            imageList.Add(BlueButton(@"C:\Users\Siddarth\Desktop\Midterm\allREF\ALL_ICON\Red.png"));
            imageList.Add(BlueButton(@"C:\Users\Siddarth\Desktop\Midterm\allREF\ALL_ICON\Green.png"));
            flpStatus.Controls.Add(imageList[0]);

        }
        

        void loadLoginButton()
        {

            logInList.Add(logIn(@"C:\Users\Siddarth\Desktop\Midterm\allREF\ALL_ICON\LOGIN80.png"));
            logInList.Add(logIn(@"C:\Users\Siddarth\Desktop\Midterm\allREF\ALL_ICON\LOGOUT80.png"));
            flpLogIn.Controls.Add(logInList[0]);
            logInList[0].Click += BtnLogIN_Click;
            logInList[1].Click += BtnLogOut_Click;
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            logInStatus = 0;
            changeStatus();
        }

        private void BtnLogIN_Click(object sender, EventArgs e)
        {
            logInPage.Show();
             
        }
        public void changeStatus()
        {
            if (logInStatus == 1)
            {
                lblActiveUser.Text = "Hi, "+ logInPage.currentUser.FirstName;
                flpLogIn.Controls.Clear();
                flpStatus.Controls.Clear();
                flpLogIn.Controls.Add(logInList[1]);
                flpStatus.Controls.Add(imageList[1]);
            }
            if (logInStatus == 0)
            {
                lblActiveUser.Text = "";
                flpLogIn.Controls.Clear();
                flpStatus.Controls.Clear();
                flpLogIn.Controls.Add(logInList[0]);
                flpStatus.Controls.Add(imageList[0]);
            }
        }
        void loadCustomerCB()
        {
            for (int i = 0; i < customerList.Count; i++)
            {
                cbCustomer.Items.Add(customerList[i].ContactName);
            }

            //foreach (var item in customerList)
            //{
            //    cbCustomer.Items.Add(item.ContactName);
            //}
            
        }
        private void btnADDITEM_Click(object sender, EventArgs e)
        {
            changeStatus();
            if (logInStatus==0)
            {
                MessageBox.Show("Please LogIn!!");
                return;
            }
            if (txtItemID.Text == "")
            {
                return;
            }
            allOrderItems.Add(new OrderItem(Convert.ToString(currentItem.ID), currentItem.Name, currentItem.Category, currentItem.Prize, Convert.ToInt32(txtQTY.Text)));
            dt.Rows.Add(OrderItem.id, currentItem.Name, txtQTY.Text, (Convert.ToInt32(txtQTY.Text) * Convert.ToDouble(currentItem.Prize)));
            subTotal += currentItem.Prize * Convert.ToInt32(txtQTY.Text);
            totalTax = subTotal * Tax;
            total = totalTax + subTotal;
            lblSubtotal.Text = Convert.ToString(subTotal);
            lblTax.Text = Convert.ToString(totalTax);
            lblTotal.Text = Convert.ToString(total);

        }
        void loadCutomer()
        {
            try
            {
                customerList = new List<Custmor>();
                string custID, compName, contactName, contactTitle, address, city, province, country, POSTALCODE, phone, FAX;
                string sql = "Select custID,compName,contactName,contactTitle,address,city,province,country,POSTALCODE,phone,FAX from tblCustomerInfo";
                if (cn.State != ConnectionState.Open)
                    cn.Open();
                cmd = new SqlCommand(sql, cn);
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        
                        custID = rdr[0].ToString();
                        custID = custID.Replace(" ", "");
                        compName = rdr[1].ToString();
                        compName = compName.Replace(" ", "");
                        contactName = rdr[2].ToString();
                        contactName = contactName.Replace(" ", "");
                        contactTitle = rdr[3].ToString();
                        contactTitle = contactTitle.Replace(" ", "");
                        address = rdr[4].ToString();
                        city = rdr[5].ToString();
                        city = city.Replace(" ", "");
                        province = rdr[6].ToString();
                        province = province.Replace(" ", "");
                        country = rdr[7].ToString();
                        POSTALCODE = rdr[8].ToString();
                        phone = rdr[9].ToString();
                        FAX = rdr[10].ToString();
                        FAX = FAX.Replace(" ", "");
                        customerList.Add(new Custmor(custID, compName, contactName, contactTitle, address, city, province, country, POSTALCODE, phone, FAX));

                    }
                }
                cn.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            int currentID=0;
            Custmor currentCustomer = null;
            for (int i = 0; i < customerList.Count; i++)
            {
                if (customerList[i].ContactName.Equals(cbCustomer.Text))
                {
                    currentCustomer = customerList[i];
                }
            }
            if (logInStatus == 0)
            {
                MessageBox.Show("Please LogIn!!");
                return;
            }
            else if (allOrderItems.Count == 0)
            {
                return;
            }
            string sql = "Insert Into tblOrder(orderTime,orderTotalAmount,soldTo,soldBy,totalItem)values(GETDATE(),'" + total + "','" + currentCustomer.CustID + "','" + logInPage.currentUser.userID + "','" + allOrderItems.Count + "')";
            
            if (cn.State != ConnectionState.Open)
                cn.Open();
            cmd = new SqlCommand(sql, cn);
            int x = cmd.ExecuteNonQuery();
            cn.Close();
            string sqlCurrentID = "select IDENT_CURRENT('tblOrder')";
            if (cn.State != ConnectionState.Open)
                cn.Open();
            cmd = new SqlCommand(sqlCurrentID, cn);
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    string ID= rdr[0].ToString();
                    ID = ID.Replace(" ", "");
                    currentID = Convert.ToInt32(ID);
                }
            }
            ///MessageBox.Show(currentID.ToString());
            cn.Close();
            if (cn.State != ConnectionState.Open)
                cn.Open();
            string sqlOderDetail = "Insert Into tblOrderDetail(orderID,productID,productName,productCategory,orderTime,itemTotalPrice,itemQty)values(@orderId,@productID,@productName,@productCategory,GETDATE(),@price,@qty)";
            
            using (cmd = new SqlCommand(sqlOderDetail, cn))
            {
                cmd.Parameters.Add(new SqlParameter("@orderId", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@productID", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@productName", SqlDbType.NChar));
                cmd.Parameters.Add(new SqlParameter("@productCategory", SqlDbType.NChar));
                cmd.Parameters.Add(new SqlParameter("@price", SqlDbType.NChar));
                cmd.Parameters.Add(new SqlParameter("@qty", SqlDbType.NChar));
                for (int i = 0; i < allOrderItems.Count; i++)
                {
                    double price = (allOrderItems[i].Prize * allOrderItems[i].Qty);
                    cmd.Parameters["@orderId"].Value = currentID;
                    cmd.Parameters["@productID"].Value = allOrderItems[i].productID;
                    cmd.Parameters["@productName"].Value = allOrderItems[i].Name;
                    cmd.Parameters["@productCategory"].Value = allOrderItems[i].Category;
                    cmd.Parameters["@price"].Value = price;
                    cmd.Parameters["@qty"].Value = allOrderItems[i].Qty;
                    cmd.ExecuteNonQuery();
                    //string sqlOderDetail = "Insert Into tblOrderDetail(orderID,productID,productName,productCategory,orderTime,itemTotalPrice,itemQty)values('"+currentID+"','" + allOrderItems[i].productID + "','" + allOrderItems[i].Name + "','" + allOrderItems[i].Category + "',GETDATE(),'" + (allOrderItems[i].Prize * allOrderItems[i].Qty) + "','" + allOrderItems[i].Qty + "')";
                    //cmd = new SqlCommand(sqlOderDetail, cn);
                    //cmd.BeginExecuteNonQuery();
                }
            }

            cn.Close();
            MessageBox.Show("Done!!");
        }

        private void lblPOS_Click(object sender, EventArgs e)
        {

        }

        private void lblMenu_Click(object sender, EventArgs e)
        {
            managementForm.Show();
        }

        private void btnAddCust_Click(object sender, EventArgs e)
        {
            newCustomer.Show();
        }
    }
}
