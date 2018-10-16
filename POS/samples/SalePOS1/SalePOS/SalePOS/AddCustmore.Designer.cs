namespace SalePOS
{
    partial class AddCustmore
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
            this.ucCustomerInfo1 = new SalePOS.ucCustomerInfo();
            this.SuspendLayout();
            // 
            // ucCustomerInfo1
            // 
            this.ucCustomerInfo1.Location = new System.Drawing.Point(85, 35);
            this.ucCustomerInfo1.Name = "ucCustomerInfo1";
            this.ucCustomerInfo1.Size = new System.Drawing.Size(793, 418);
            this.ucCustomerInfo1.TabIndex = 0;
            this.ucCustomerInfo1.Load += new System.EventHandler(this.ucCustomerInfo1_Load);
            // 
            // AddCustmore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 482);
            this.Controls.Add(this.ucCustomerInfo1);
            this.Name = "AddCustmore";
            this.Text = "AddCustmore";
            this.ResumeLayout(false);

        }

        #endregion

        private ucCustomerInfo ucCustomerInfo1;
    }
}