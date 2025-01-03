namespace GUI
{
    partial class OrderManagement
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderManagement));
            System.Windows.Forms.ListViewGroup listViewGroup10 = new System.Windows.Forms.ListViewGroup("Processor", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup11 = new System.Windows.Forms.ListViewGroup("Motherboard", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup12 = new System.Windows.Forms.ListViewGroup("CPU Cooler", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup13 = new System.Windows.Forms.ListViewGroup("Case", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup14 = new System.Windows.Forms.ListViewGroup("Graphic Card", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup15 = new System.Windows.Forms.ListViewGroup("RAM", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup16 = new System.Windows.Forms.ListViewGroup("Storage", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup17 = new System.Windows.Forms.ListViewGroup("Case Cooler", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup18 = new System.Windows.Forms.ListViewGroup("Power Supply", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Processor", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Motherboard", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("CPU Cooler", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Case", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Graphic Card", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("RAM", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup7 = new System.Windows.Forms.ListViewGroup("Storage", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup8 = new System.Windows.Forms.ListViewGroup("Case Cooler", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup9 = new System.Windows.Forms.ListViewGroup("Power Supply", System.Windows.Forms.HorizontalAlignment.Left);
            this.tcOrder = new System.Windows.Forms.TabControl();
            this.tpOrderList = new System.Windows.Forms.TabPage();
            this.tpCreateOrder = new System.Windows.Forms.TabPage();
            this.btnReload = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.Label();
            this.lstSelectedProduct = new System.Windows.Forms.ListView();
            this.btnAddNewCustomer = new System.Windows.Forms.Button();
            this.listProduct = new System.Windows.Forms.ListView();
            this.txtMembershipLevel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tcOrder.SuspendLayout();
            this.tpCreateOrder.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcOrder
            // 
            this.tcOrder.Controls.Add(this.tpOrderList);
            this.tcOrder.Controls.Add(this.tpCreateOrder);
            this.tcOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcOrder.Font = new System.Drawing.Font("Bahnschrift", 12.75F);
            this.tcOrder.ItemSize = new System.Drawing.Size(150, 30);
            this.tcOrder.Location = new System.Drawing.Point(0, 0);
            this.tcOrder.Name = "tcOrder";
            this.tcOrder.SelectedIndex = 0;
            this.tcOrder.Size = new System.Drawing.Size(1177, 653);
            this.tcOrder.TabIndex = 0;
            // 
            // tpOrderList
            // 
            this.tpOrderList.Location = new System.Drawing.Point(4, 34);
            this.tpOrderList.Name = "tpOrderList";
            this.tpOrderList.Padding = new System.Windows.Forms.Padding(3);
            this.tpOrderList.Size = new System.Drawing.Size(1169, 615);
            this.tpOrderList.TabIndex = 0;
            this.tpOrderList.Text = "Order List";
            this.tpOrderList.UseVisualStyleBackColor = true;
            // 
            // tpCreateOrder
            // 
            this.tpCreateOrder.Controls.Add(this.listProduct);
            this.tpCreateOrder.Controls.Add(this.btnAddNewCustomer);
            this.tpCreateOrder.Controls.Add(this.lstSelectedProduct);
            this.tpCreateOrder.Controls.Add(this.groupBox1);
            this.tpCreateOrder.Controls.Add(this.btnReload);
            this.tpCreateOrder.Location = new System.Drawing.Point(4, 34);
            this.tpCreateOrder.Name = "tpCreateOrder";
            this.tpCreateOrder.Padding = new System.Windows.Forms.Padding(3);
            this.tpCreateOrder.Size = new System.Drawing.Size(1169, 615);
            this.tpCreateOrder.TabIndex = 2;
            this.tpCreateOrder.Text = "Create New Order";
            this.tpCreateOrder.UseVisualStyleBackColor = true;
            // 
            // btnReload
            // 
            this.btnReload.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReload.BackgroundImage")));
            this.btnReload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReload.Font = new System.Drawing.Font("Bahnschrift", 12.75F);
            this.btnReload.Location = new System.Drawing.Point(1111, 6);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(52, 52);
            this.btnReload.TabIndex = 23;
            this.btnReload.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.txtName.Location = new System.Drawing.Point(350, 27);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(185, 28);
            this.txtName.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label1.Location = new System.Drawing.Point(272, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 22);
            this.label1.TabIndex = 26;
            this.label1.Text = "Full Name:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMembershipLevel);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPhone);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(20, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(562, 178);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer Information:";
            // 
            // txtPhone
            // 
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.txtPhone.Location = new System.Drawing.Point(71, 27);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(185, 28);
            this.txtPhone.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label2.Location = new System.Drawing.Point(7, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 22);
            this.label2.TabIndex = 28;
            this.label2.Text = "Phone:";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.txtEmail.Location = new System.Drawing.Point(71, 68);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(185, 28);
            this.txtEmail.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label3.Location = new System.Drawing.Point(7, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 22);
            this.label3.TabIndex = 30;
            this.label3.Text = "Email:";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.textBox1.Location = new System.Drawing.Point(71, 114);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(464, 28);
            this.textBox1.TabIndex = 31;
            // 
            // txtAddress
            // 
            this.txtAddress.AutoSize = true;
            this.txtAddress.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.txtAddress.Location = new System.Drawing.Point(7, 116);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(60, 22);
            this.txtAddress.TabIndex = 32;
            this.txtAddress.Text = "Address:";
            // 
            // lstSelectedProduct
            // 
            this.lstSelectedProduct.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstSelectedProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstSelectedProduct.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSelectedProduct.FullRowSelect = true;
            listViewGroup10.Header = "Processor";
            listViewGroup10.Name = "listViewGroupProcessor";
            listViewGroup11.Header = "Motherboard";
            listViewGroup11.Name = "listViewGroupMotherboard";
            listViewGroup12.Header = "CPU Cooler";
            listViewGroup12.Name = "listViewGroupCPUCooler";
            listViewGroup13.Header = "Case";
            listViewGroup13.Name = "listViewGroupCase";
            listViewGroup14.Header = "Graphic Card";
            listViewGroup14.Name = "listViewGroupGraphicCard";
            listViewGroup15.Header = "RAM";
            listViewGroup15.Name = "listViewGroupRAM";
            listViewGroup16.Header = "Storage";
            listViewGroup16.Name = "listViewGroupStorage";
            listViewGroup17.Header = "Case Cooler";
            listViewGroup17.Name = "listViewGroupCaseCooler";
            listViewGroup18.Header = "Power Supply";
            listViewGroup18.Name = "listViewGroupPowerSupply";
            this.lstSelectedProduct.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup10,
            listViewGroup11,
            listViewGroup12,
            listViewGroup13,
            listViewGroup14,
            listViewGroup15,
            listViewGroup16,
            listViewGroup17,
            listViewGroup18});
            this.lstSelectedProduct.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstSelectedProduct.HideSelection = false;
            this.lstSelectedProduct.Location = new System.Drawing.Point(20, 266);
            this.lstSelectedProduct.MultiSelect = false;
            this.lstSelectedProduct.Name = "lstSelectedProduct";
            this.lstSelectedProduct.Size = new System.Drawing.Size(562, 265);
            this.lstSelectedProduct.TabIndex = 28;
            this.lstSelectedProduct.TileSize = new System.Drawing.Size(500, 30);
            this.lstSelectedProduct.UseCompatibleStateImageBehavior = false;
            this.lstSelectedProduct.View = System.Windows.Forms.View.Details;
            // 
            // btnAddNewCustomer
            // 
            this.btnAddNewCustomer.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.btnAddNewCustomer.Location = new System.Drawing.Point(20, 205);
            this.btnAddNewCustomer.Name = "btnAddNewCustomer";
            this.btnAddNewCustomer.Size = new System.Drawing.Size(150, 30);
            this.btnAddNewCustomer.TabIndex = 29;
            this.btnAddNewCustomer.Text = "New Customer";
            this.btnAddNewCustomer.UseVisualStyleBackColor = true;
            // 
            // listProduct
            // 
            this.listProduct.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listProduct.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listProduct.FullRowSelect = true;
            listViewGroup1.Header = "Processor";
            listViewGroup1.Name = "listViewGroupProcessor";
            listViewGroup2.Header = "Motherboard";
            listViewGroup2.Name = "listViewGroupMotherboard";
            listViewGroup3.Header = "CPU Cooler";
            listViewGroup3.Name = "listViewGroupCPUCooler";
            listViewGroup4.Header = "Case";
            listViewGroup4.Name = "listViewGroupCase";
            listViewGroup5.Header = "Graphic Card";
            listViewGroup5.Name = "listViewGroupGraphicCard";
            listViewGroup6.Header = "RAM";
            listViewGroup6.Name = "listViewGroupRAM";
            listViewGroup7.Header = "Storage";
            listViewGroup7.Name = "listViewGroupStorage";
            listViewGroup8.Header = "Case Cooler";
            listViewGroup8.Name = "listViewGroupCaseCooler";
            listViewGroup9.Header = "Power Supply";
            listViewGroup9.Name = "listViewGroupPowerSupply";
            this.listProduct.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4,
            listViewGroup5,
            listViewGroup6,
            listViewGroup7,
            listViewGroup8,
            listViewGroup9});
            this.listProduct.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listProduct.HideSelection = false;
            this.listProduct.Location = new System.Drawing.Point(595, 28);
            this.listProduct.MultiSelect = false;
            this.listProduct.Name = "listProduct";
            this.listProduct.Size = new System.Drawing.Size(510, 280);
            this.listProduct.TabIndex = 30;
            this.listProduct.TileSize = new System.Drawing.Size(500, 30);
            this.listProduct.UseCompatibleStateImageBehavior = false;
            this.listProduct.View = System.Windows.Forms.View.Details;
            // 
            // txtMembershipLevel
            // 
            this.txtMembershipLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMembershipLevel.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.txtMembershipLevel.Location = new System.Drawing.Point(350, 68);
            this.txtMembershipLevel.Name = "txtMembershipLevel";
            this.txtMembershipLevel.Size = new System.Drawing.Size(185, 28);
            this.txtMembershipLevel.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label4.Location = new System.Drawing.Point(272, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 22);
            this.label4.TabIndex = 34;
            this.label4.Text = "Rank:";
            // 
            // OrderManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tcOrder);
            this.Name = "OrderManagement";
            this.Size = new System.Drawing.Size(1177, 653);
            this.tcOrder.ResumeLayout(false);
            this.tpCreateOrder.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcOrder;
        private System.Windows.Forms.TabPage tpOrderList;
        private System.Windows.Forms.TabPage tpCreateOrder;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label txtAddress;
        private System.Windows.Forms.ListView lstSelectedProduct;
        private System.Windows.Forms.Button btnAddNewCustomer;
        private System.Windows.Forms.ListView listProduct;
        private System.Windows.Forms.TextBox txtMembershipLevel;
        private System.Windows.Forms.Label label4;
    }
}
