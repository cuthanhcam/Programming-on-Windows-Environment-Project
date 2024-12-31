namespace GUI
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpProducts = new System.Windows.Forms.TabPage();
            this.tpOrders = new System.Windows.Forms.TabPage();
            this.tpCustomers = new System.Windows.Forms.TabPage();
            this.tpStock = new System.Windows.Forms.TabPage();
            this.tpStatistics = new System.Windows.Forms.TabPage();
            this.tpEmployees = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnProductsManagement = new System.Windows.Forms.Button();
            this.btnOrdersManagement = new System.Windows.Forms.Button();
            this.btnCustomersManagement = new System.Windows.Forms.Button();
            this.btnStockManagement = new System.Windows.Forms.Button();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.btnEmployeesManagement = new System.Windows.Forms.Button();
            this.tcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tpProducts);
            this.tcMain.Controls.Add(this.tpOrders);
            this.tcMain.Controls.Add(this.tpCustomers);
            this.tcMain.Controls.Add(this.tpStock);
            this.tcMain.Controls.Add(this.tpStatistics);
            this.tcMain.Controls.Add(this.tpEmployees);
            this.tcMain.Font = new System.Drawing.Font("Bahnschrift", 8F);
            this.tcMain.ItemSize = new System.Drawing.Size(0, 1);
            this.tcMain.Location = new System.Drawing.Point(0, 149);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(1185, 662);
            this.tcMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tcMain.TabIndex = 7;
            // 
            // tpProducts
            // 
            this.tpProducts.Font = new System.Drawing.Font("Bahnschrift", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpProducts.Location = new System.Drawing.Point(4, 5);
            this.tpProducts.Margin = new System.Windows.Forms.Padding(0);
            this.tpProducts.Name = "tpProducts";
            this.tpProducts.Size = new System.Drawing.Size(1177, 653);
            this.tpProducts.TabIndex = 0;
            this.tpProducts.Text = "Products";
            this.tpProducts.UseVisualStyleBackColor = true;
            // 
            // tpOrders
            // 
            this.tpOrders.Location = new System.Drawing.Point(4, 5);
            this.tpOrders.Name = "tpOrders";
            this.tpOrders.Padding = new System.Windows.Forms.Padding(3);
            this.tpOrders.Size = new System.Drawing.Size(1177, 653);
            this.tpOrders.TabIndex = 1;
            this.tpOrders.Text = "Orders";
            this.tpOrders.UseVisualStyleBackColor = true;
            // 
            // tpCustomers
            // 
            this.tpCustomers.Location = new System.Drawing.Point(4, 5);
            this.tpCustomers.Name = "tpCustomers";
            this.tpCustomers.Padding = new System.Windows.Forms.Padding(3);
            this.tpCustomers.Size = new System.Drawing.Size(1177, 653);
            this.tpCustomers.TabIndex = 2;
            this.tpCustomers.Text = "Customers";
            this.tpCustomers.UseVisualStyleBackColor = true;
            // 
            // tpStock
            // 
            this.tpStock.Location = new System.Drawing.Point(4, 5);
            this.tpStock.Name = "tpStock";
            this.tpStock.Padding = new System.Windows.Forms.Padding(3);
            this.tpStock.Size = new System.Drawing.Size(1177, 653);
            this.tpStock.TabIndex = 3;
            this.tpStock.Text = "Stock";
            this.tpStock.UseVisualStyleBackColor = true;
            // 
            // tpStatistics
            // 
            this.tpStatistics.Location = new System.Drawing.Point(4, 5);
            this.tpStatistics.Name = "tpStatistics";
            this.tpStatistics.Padding = new System.Windows.Forms.Padding(3);
            this.tpStatistics.Size = new System.Drawing.Size(1177, 653);
            this.tpStatistics.TabIndex = 4;
            this.tpStatistics.Text = "Statistics";
            this.tpStatistics.UseVisualStyleBackColor = true;
            // 
            // tpEmployees
            // 
            this.tpEmployees.Location = new System.Drawing.Point(4, 5);
            this.tpEmployees.Name = "tpEmployees";
            this.tpEmployees.Padding = new System.Windows.Forms.Padding(3);
            this.tpEmployees.Size = new System.Drawing.Size(1177, 653);
            this.tpEmployees.TabIndex = 5;
            this.tpEmployees.Text = "Employees";
            this.tpEmployees.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(57, 57);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // btnProductsManagement
            // 
            this.btnProductsManagement.BackColor = System.Drawing.Color.White;
            this.btnProductsManagement.Font = new System.Drawing.Font("Bahnschrift", 12.75F);
            this.btnProductsManagement.Location = new System.Drawing.Point(8, 102);
            this.btnProductsManagement.Name = "btnProductsManagement";
            this.btnProductsManagement.Size = new System.Drawing.Size(190, 50);
            this.btnProductsManagement.TabIndex = 10;
            this.btnProductsManagement.Text = "Products Management";
            this.btnProductsManagement.UseVisualStyleBackColor = false;
            this.btnProductsManagement.Click += new System.EventHandler(this.btnProductsManagement_Click);
            // 
            // btnOrdersManagement
            // 
            this.btnOrdersManagement.BackColor = System.Drawing.Color.White;
            this.btnOrdersManagement.Font = new System.Drawing.Font("Bahnschrift", 12.75F);
            this.btnOrdersManagement.Location = new System.Drawing.Point(204, 102);
            this.btnOrdersManagement.Name = "btnOrdersManagement";
            this.btnOrdersManagement.Size = new System.Drawing.Size(190, 50);
            this.btnOrdersManagement.TabIndex = 11;
            this.btnOrdersManagement.Text = "Orders Management";
            this.btnOrdersManagement.UseVisualStyleBackColor = false;
            this.btnOrdersManagement.Click += new System.EventHandler(this.btnOrdersManagement_Click);
            // 
            // btnCustomersManagement
            // 
            this.btnCustomersManagement.BackColor = System.Drawing.Color.White;
            this.btnCustomersManagement.Font = new System.Drawing.Font("Bahnschrift", 12.75F);
            this.btnCustomersManagement.Location = new System.Drawing.Point(400, 102);
            this.btnCustomersManagement.Name = "btnCustomersManagement";
            this.btnCustomersManagement.Size = new System.Drawing.Size(190, 50);
            this.btnCustomersManagement.TabIndex = 12;
            this.btnCustomersManagement.Text = "Customers";
            this.btnCustomersManagement.UseVisualStyleBackColor = false;
            this.btnCustomersManagement.Click += new System.EventHandler(this.btnCustomersManagement_Click);
            // 
            // btnStockManagement
            // 
            this.btnStockManagement.BackColor = System.Drawing.Color.White;
            this.btnStockManagement.Font = new System.Drawing.Font("Bahnschrift", 12.75F);
            this.btnStockManagement.Location = new System.Drawing.Point(596, 102);
            this.btnStockManagement.Name = "btnStockManagement";
            this.btnStockManagement.Size = new System.Drawing.Size(190, 50);
            this.btnStockManagement.TabIndex = 13;
            this.btnStockManagement.Text = "Stock Transactions";
            this.btnStockManagement.UseVisualStyleBackColor = false;
            this.btnStockManagement.Click += new System.EventHandler(this.btnStockManagement_Click);
            // 
            // btnStatistics
            // 
            this.btnStatistics.BackColor = System.Drawing.Color.White;
            this.btnStatistics.Font = new System.Drawing.Font("Bahnschrift", 12.75F);
            this.btnStatistics.Location = new System.Drawing.Point(792, 102);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(190, 50);
            this.btnStatistics.TabIndex = 14;
            this.btnStatistics.Text = "Statistics";
            this.btnStatistics.UseVisualStyleBackColor = false;
            this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
            // 
            // btnEmployeesManagement
            // 
            this.btnEmployeesManagement.BackColor = System.Drawing.Color.White;
            this.btnEmployeesManagement.Font = new System.Drawing.Font("Bahnschrift", 12.75F);
            this.btnEmployeesManagement.Location = new System.Drawing.Point(986, 102);
            this.btnEmployeesManagement.Name = "btnEmployeesManagement";
            this.btnEmployeesManagement.Size = new System.Drawing.Size(190, 50);
            this.btnEmployeesManagement.TabIndex = 15;
            this.btnEmployeesManagement.Text = "Employees";
            this.btnEmployeesManagement.UseVisualStyleBackColor = false;
            this.btnEmployeesManagement.Click += new System.EventHandler(this.btnEmployeesManagement_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 811);
            this.Controls.Add(this.btnEmployeesManagement);
            this.Controls.Add(this.btnStatistics);
            this.Controls.Add(this.btnStockManagement);
            this.Controls.Add(this.btnCustomersManagement);
            this.Controls.Add(this.btnOrdersManagement);
            this.Controls.Add(this.btnProductsManagement);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tcMain);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.tcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpProducts;
        private System.Windows.Forms.TabPage tpOrders;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tpCustomers;
        private System.Windows.Forms.TabPage tpStock;
        private System.Windows.Forms.TabPage tpStatistics;
        private System.Windows.Forms.TabPage tpEmployees;
        private System.Windows.Forms.Button btnProductsManagement;
        private System.Windows.Forms.Button btnOrdersManagement;
        private System.Windows.Forms.Button btnCustomersManagement;
        private System.Windows.Forms.Button btnStockManagement;
        private System.Windows.Forms.Button btnStatistics;
        private System.Windows.Forms.Button btnEmployeesManagement;
    }
}