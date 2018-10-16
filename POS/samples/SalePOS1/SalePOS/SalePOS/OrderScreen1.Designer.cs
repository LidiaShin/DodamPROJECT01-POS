namespace SalePOS
{
    partial class btnLogOut
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label lblPOS;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(btnLogOut));
            System.Windows.Forms.Label lblMenu;
            this.mainSplit = new System.Windows.Forms.SplitContainer();
            this.flpLogIn = new System.Windows.Forms.FlowLayoutPanel();
            this.orderScreenSplit = new System.Windows.Forms.SplitContainer();
            this.menuItemContainer = new System.Windows.Forms.SplitContainer();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabFOOD = new System.Windows.Forms.TabPage();
            this.flpFood = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.flpDrinks = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.flpHardware = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.flpMisc = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtItemID = new System.Windows.Forms.TextBox();
            this.btnADDITEM = new System.Windows.Forms.Button();
            this.txtQTY = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblActiveUser = new System.Windows.Forms.Label();
            this.flpStatus = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbCustomer = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPlaceOrder = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTax = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.dgvOrderedItem = new System.Windows.Forms.DataGridView();
            this.btnAddCust = new System.Windows.Forms.Button();
            lblPOS = new System.Windows.Forms.Label();
            lblMenu = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplit)).BeginInit();
            this.mainSplit.Panel1.SuspendLayout();
            this.mainSplit.Panel2.SuspendLayout();
            this.mainSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderScreenSplit)).BeginInit();
            this.orderScreenSplit.Panel1.SuspendLayout();
            this.orderScreenSplit.Panel2.SuspendLayout();
            this.orderScreenSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuItemContainer)).BeginInit();
            this.menuItemContainer.Panel1.SuspendLayout();
            this.menuItemContainer.Panel2.SuspendLayout();
            this.menuItemContainer.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabFOOD.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderedItem)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPOS
            // 
            lblPOS.Image = ((System.Drawing.Image)(resources.GetObject("lblPOS.Image")));
            lblPOS.Location = new System.Drawing.Point(13, 9);
            lblPOS.Name = "lblPOS";
            lblPOS.Size = new System.Drawing.Size(80, 80);
            lblPOS.TabIndex = 0;
            lblPOS.Click += new System.EventHandler(this.lblPOS_Click);
            // 
            // lblMenu
            // 
            lblMenu.Image = ((System.Drawing.Image)(resources.GetObject("lblMenu.Image")));
            lblMenu.Location = new System.Drawing.Point(12, 89);
            lblMenu.Name = "lblMenu";
            lblMenu.Size = new System.Drawing.Size(80, 80);
            lblMenu.TabIndex = 1;
            lblMenu.Click += new System.EventHandler(this.lblMenu_Click);
            // 
            // mainSplit
            // 
            this.mainSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplit.Location = new System.Drawing.Point(0, 0);
            this.mainSplit.Name = "mainSplit";
            // 
            // mainSplit.Panel1
            // 
            this.mainSplit.Panel1.Controls.Add(this.flpLogIn);
            this.mainSplit.Panel1.Controls.Add(lblMenu);
            this.mainSplit.Panel1.Controls.Add(lblPOS);
            // 
            // mainSplit.Panel2
            // 
            this.mainSplit.Panel2.Controls.Add(this.orderScreenSplit);
            this.mainSplit.Size = new System.Drawing.Size(1032, 672);
            this.mainSplit.SplitterDistance = 123;
            this.mainSplit.TabIndex = 0;
            // 
            // flpLogIn
            // 
            this.flpLogIn.Location = new System.Drawing.Point(5, 566);
            this.flpLogIn.Name = "flpLogIn";
            this.flpLogIn.Size = new System.Drawing.Size(112, 90);
            this.flpLogIn.TabIndex = 2;
            // 
            // orderScreenSplit
            // 
            this.orderScreenSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderScreenSplit.Location = new System.Drawing.Point(0, 0);
            this.orderScreenSplit.Name = "orderScreenSplit";
            // 
            // orderScreenSplit.Panel1
            // 
            this.orderScreenSplit.Panel1.Controls.Add(this.menuItemContainer);
            // 
            // orderScreenSplit.Panel2
            // 
            this.orderScreenSplit.Panel2.Controls.Add(this.btnAddCust);
            this.orderScreenSplit.Panel2.Controls.Add(this.lblActiveUser);
            this.orderScreenSplit.Panel2.Controls.Add(this.flpStatus);
            this.orderScreenSplit.Panel2.Controls.Add(this.groupBox3);
            this.orderScreenSplit.Panel2.Controls.Add(this.btnPlaceOrder);
            this.orderScreenSplit.Panel2.Controls.Add(this.groupBox2);
            this.orderScreenSplit.Panel2.Controls.Add(this.dgvOrderedItem);
            this.orderScreenSplit.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.orderScreenSplit_Panel2_Paint);
            this.orderScreenSplit.Size = new System.Drawing.Size(905, 672);
            this.orderScreenSplit.SplitterDistance = 450;
            this.orderScreenSplit.TabIndex = 0;
            // 
            // menuItemContainer
            // 
            this.menuItemContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuItemContainer.Location = new System.Drawing.Point(0, 0);
            this.menuItemContainer.Name = "menuItemContainer";
            this.menuItemContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // menuItemContainer.Panel1
            // 
            this.menuItemContainer.Panel1.Controls.Add(this.tabControl);
            // 
            // menuItemContainer.Panel2
            // 
            this.menuItemContainer.Panel2.Controls.Add(this.groupBox1);
            this.menuItemContainer.Size = new System.Drawing.Size(450, 672);
            this.menuItemContainer.SplitterDistance = 582;
            this.menuItemContainer.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabFOOD);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(450, 582);
            this.tabControl.TabIndex = 0;
            // 
            // tabFOOD
            // 
            this.tabFOOD.Controls.Add(this.flpFood);
            this.tabFOOD.Location = new System.Drawing.Point(4, 25);
            this.tabFOOD.Name = "tabFOOD";
            this.tabFOOD.Padding = new System.Windows.Forms.Padding(3);
            this.tabFOOD.Size = new System.Drawing.Size(442, 553);
            this.tabFOOD.TabIndex = 0;
            this.tabFOOD.Text = "FOOD";
            this.tabFOOD.UseVisualStyleBackColor = true;
            // 
            // flpFood
            // 
            this.flpFood.AutoScroll = true;
            this.flpFood.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpFood.Location = new System.Drawing.Point(3, 3);
            this.flpFood.Name = "flpFood";
            this.flpFood.Size = new System.Drawing.Size(436, 547);
            this.flpFood.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.flpDrinks);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(442, 553);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "DRINKS";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // flpDrinks
            // 
            this.flpDrinks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpDrinks.Location = new System.Drawing.Point(3, 3);
            this.flpDrinks.Name = "flpDrinks";
            this.flpDrinks.Size = new System.Drawing.Size(436, 547);
            this.flpDrinks.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.flpHardware);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(442, 553);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "HARDWARE";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // flpHardware
            // 
            this.flpHardware.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpHardware.Location = new System.Drawing.Point(3, 3);
            this.flpHardware.Name = "flpHardware";
            this.flpHardware.Size = new System.Drawing.Size(436, 547);
            this.flpHardware.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.flpMisc);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(442, 553);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "MISC";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // flpMisc
            // 
            this.flpMisc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMisc.Location = new System.Drawing.Point(3, 3);
            this.flpMisc.Name = "flpMisc";
            this.flpMisc.Size = new System.Drawing.Size(436, 547);
            this.flpMisc.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtItemID);
            this.groupBox1.Controls.Add(this.btnADDITEM);
            this.groupBox1.Controls.Add(this.txtQTY);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(0, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(429, 78);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // txtItemID
            // 
            this.txtItemID.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemID.Location = new System.Drawing.Point(21, 30);
            this.txtItemID.Name = "txtItemID";
            this.txtItemID.Size = new System.Drawing.Size(66, 27);
            this.txtItemID.TabIndex = 0;
            // 
            // btnADDITEM
            // 
            this.btnADDITEM.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnADDITEM.Location = new System.Drawing.Point(228, 29);
            this.btnADDITEM.Name = "btnADDITEM";
            this.btnADDITEM.Size = new System.Drawing.Size(181, 34);
            this.btnADDITEM.TabIndex = 5;
            this.btnADDITEM.Text = "ADD ITEM";
            this.btnADDITEM.UseVisualStyleBackColor = true;
            this.btnADDITEM.Click += new System.EventHandler(this.btnADDITEM_Click);
            // 
            // txtQTY
            // 
            this.txtQTY.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQTY.FormattingEnabled = true;
            this.txtQTY.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.txtQTY.Location = new System.Drawing.Point(126, 30);
            this.txtQTY.Name = "txtQTY";
            this.txtQTY.Size = new System.Drawing.Size(62, 27);
            this.txtQTY.TabIndex = 4;
            this.txtQTY.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(137, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "QTY";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(96, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "ITEM";
            // 
            // lblActiveUser
            // 
            this.lblActiveUser.AutoSize = true;
            this.lblActiveUser.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveUser.Location = new System.Drawing.Point(272, 24);
            this.lblActiveUser.Name = "lblActiveUser";
            this.lblActiveUser.Size = new System.Drawing.Size(54, 19);
            this.lblActiveUser.TabIndex = 14;
            this.lblActiveUser.Text = "label9";
            // 
            // flpStatus
            // 
            this.flpStatus.Location = new System.Drawing.Point(372, 13);
            this.flpStatus.Name = "flpStatus";
            this.flpStatus.Size = new System.Drawing.Size(30, 30);
            this.flpStatus.TabIndex = 13;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbCustomer);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(3, 453);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(131, 100);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            // 
            // cbCustomer
            // 
            this.cbCustomer.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCustomer.FormattingEnabled = true;
            this.cbCustomer.Location = new System.Drawing.Point(8, 39);
            this.cbCustomer.Name = "cbCustomer";
            this.cbCustomer.Size = new System.Drawing.Size(121, 27);
            this.cbCustomer.TabIndex = 1;
            this.cbCustomer.Text = "anonymous";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Customer";
            // 
            // btnPlaceOrder
            // 
            this.btnPlaceOrder.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlaceOrder.Location = new System.Drawing.Point(167, 597);
            this.btnPlaceOrder.Name = "btnPlaceOrder";
            this.btnPlaceOrder.Size = new System.Drawing.Size(218, 48);
            this.btnPlaceOrder.TabIndex = 11;
            this.btnPlaceOrder.Text = "Place Order";
            this.btnPlaceOrder.UseVisualStyleBackColor = true;
            this.btnPlaceOrder.Click += new System.EventHandler(this.btnPlaceOrder_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblTotal);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lblDiscount);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lblTax);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lblSubtotal);
            this.groupBox2.Location = new System.Drawing.Point(138, 445);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(253, 153);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(70, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 19);
            this.label5.TabIndex = 2;
            this.label5.Text = "Subtotal :";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(171, 114);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(46, 29);
            this.lblTotal.TabIndex = 9;
            this.lblTotal.Text = "0.0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(109, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 19);
            this.label6.TabIndex = 3;
            this.label6.Text = "Tax :";
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.Location = new System.Drawing.Point(171, 82);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(46, 29);
            this.lblDiscount.TabIndex = 8;
            this.lblDiscount.Text = "0.0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(4, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 19);
            this.label7.TabIndex = 4;
            this.label7.Text = "Loyalty Discount :";
            // 
            // lblTax
            // 
            this.lblTax.AutoSize = true;
            this.lblTax.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTax.Location = new System.Drawing.Point(171, 48);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(46, 29);
            this.lblTax.TabIndex = 7;
            this.lblTax.Text = "0.0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(98, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 19);
            this.label8.TabIndex = 5;
            this.label8.Text = "Total :";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.Location = new System.Drawing.Point(171, 12);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(46, 29);
            this.lblSubtotal.TabIndex = 6;
            this.lblSubtotal.Text = "0.0";
            // 
            // dgvOrderedItem
            // 
            this.dgvOrderedItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderedItem.Location = new System.Drawing.Point(24, 89);
            this.dgvOrderedItem.Name = "dgvOrderedItem";
            this.dgvOrderedItem.RowTemplate.Height = 24;
            this.dgvOrderedItem.Size = new System.Drawing.Size(378, 350);
            this.dgvOrderedItem.TabIndex = 0;
            // 
            // btnAddCust
            // 
            this.btnAddCust.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCust.Location = new System.Drawing.Point(0, 554);
            this.btnAddCust.Name = "btnAddCust";
            this.btnAddCust.Size = new System.Drawing.Size(134, 44);
            this.btnAddCust.TabIndex = 15;
            this.btnAddCust.Text = "Add Customer";
            this.btnAddCust.UseVisualStyleBackColor = true;
            this.btnAddCust.Click += new System.EventHandler(this.btnAddCust_Click);
            // 
            // btnLogOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 672);
            this.Controls.Add(this.mainSplit);
            this.Name = "btnLogOut";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.OrderScreen_Load);
            this.mainSplit.Panel1.ResumeLayout(false);
            this.mainSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplit)).EndInit();
            this.mainSplit.ResumeLayout(false);
            this.orderScreenSplit.Panel1.ResumeLayout(false);
            this.orderScreenSplit.Panel2.ResumeLayout(false);
            this.orderScreenSplit.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderScreenSplit)).EndInit();
            this.orderScreenSplit.ResumeLayout(false);
            this.menuItemContainer.Panel1.ResumeLayout(false);
            this.menuItemContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.menuItemContainer)).EndInit();
            this.menuItemContainer.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabFOOD.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderedItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainSplit;
        private System.Windows.Forms.SplitContainer orderScreenSplit;
        private System.Windows.Forms.SplitContainer menuItemContainer;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabFOOD;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.FlowLayoutPanel flpFood;
        private System.Windows.Forms.Button btnADDITEM;
        private System.Windows.Forms.ComboBox txtQTY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtItemID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvOrderedItem;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnPlaceOrder;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbCustomer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel flpLogIn;
        private System.Windows.Forms.FlowLayoutPanel flpStatus;
        private System.Windows.Forms.Label lblActiveUser;
        private System.Windows.Forms.FlowLayoutPanel flpDrinks;
        private System.Windows.Forms.FlowLayoutPanel flpHardware;
        private System.Windows.Forms.FlowLayoutPanel flpMisc;
        private System.Windows.Forms.Button btnAddCust;
    }
}

