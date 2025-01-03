namespace GUI
{
    partial class ProductManagement
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Processor", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Motherboard", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("CPU Cooler", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Case", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Graphic Card", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("RAM", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup7 = new System.Windows.Forms.ListViewGroup("Storage", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup8 = new System.Windows.Forms.ListViewGroup("Case Cooler", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup9 = new System.Windows.Forms.ListViewGroup("Power Supply", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductManagement));
            this.lstProduct = new System.Windows.Forms.ListView();
            this.imageListProducts = new System.Windows.Forms.ImageList(this.components);
            this.rtbSpecs = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbProduct = new System.Windows.Forms.PictureBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbPrice = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddUpdatePic = new System.Windows.Forms.Button();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbProduct)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstProduct
            // 
            this.lstProduct.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstProduct.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstProduct.FullRowSelect = true;
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
            this.lstProduct.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4,
            listViewGroup5,
            listViewGroup6,
            listViewGroup7,
            listViewGroup8,
            listViewGroup9});
            this.lstProduct.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstProduct.HideSelection = false;
            this.lstProduct.Location = new System.Drawing.Point(395, 171);
            this.lstProduct.MultiSelect = false;
            this.lstProduct.Name = "lstProduct";
            this.lstProduct.Size = new System.Drawing.Size(770, 400);
            this.lstProduct.SmallImageList = this.imageListProducts;
            this.lstProduct.TabIndex = 0;
            this.lstProduct.TileSize = new System.Drawing.Size(500, 30);
            this.lstProduct.UseCompatibleStateImageBehavior = false;
            this.lstProduct.View = System.Windows.Forms.View.Details;
            this.lstProduct.Click += new System.EventHandler(this.lstProduct_Click);
            // 
            // imageListProducts
            // 
            this.imageListProducts.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListProducts.ImageSize = new System.Drawing.Size(35, 35);
            this.imageListProducts.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // rtbSpecs
            // 
            this.rtbSpecs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbSpecs.Font = new System.Drawing.Font("Bahnschrift", 12.75F);
            this.rtbSpecs.Location = new System.Drawing.Point(26, 406);
            this.rtbSpecs.Name = "rtbSpecs";
            this.rtbSpecs.Size = new System.Drawing.Size(281, 217);
            this.rtbSpecs.TabIndex = 17;
            this.rtbSpecs.Text = "";
            this.rtbSpecs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtbDetail_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label8.Location = new System.Drawing.Point(22, 381);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 22);
            this.label8.TabIndex = 16;
            this.label8.Text = "Specifications:";
            // 
            // txtProductID
            // 
            this.txtProductID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductID.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.txtProductID.Location = new System.Drawing.Point(110, 24);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Size = new System.Drawing.Size(100, 28);
            this.txtProductID.TabIndex = 9;
            this.txtProductID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductID_KeyDown);
            // 
            // cmbBrand
            // 
            this.cmbBrand.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(367, 21);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(150, 29);
            this.cmbBrand.TabIndex = 7;
            this.cmbBrand.SelectedIndexChanged += new System.EventHandler(this.cmbBrand_SelectedIndexChanged);
            // 
            // cmbCategory
            // 
            this.cmbCategory.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(102, 21);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(150, 29);
            this.cmbCategory.TabIndex = 6;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label3.Location = new System.Drawing.Point(30, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Product ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label2.Location = new System.Drawing.Point(312, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Brand:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label1.Location = new System.Drawing.Point(30, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Category:";
            // 
            // pbProduct
            // 
            this.pbProduct.Location = new System.Drawing.Point(92, 20);
            this.pbProduct.Name = "pbProduct";
            this.pbProduct.Size = new System.Drawing.Size(178, 176);
            this.pbProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProduct.TabIndex = 0;
            this.pbProduct.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.txtSearch.Location = new System.Drawing.Point(366, 24);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(185, 28);
            this.txtSearch.TabIndex = 18;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label9.Location = new System.Drawing.Point(276, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 22);
            this.label9.TabIndex = 19;
            this.label9.Text = "Model name:";
            // 
            // cmbPrice
            // 
            this.cmbPrice.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.cmbPrice.FormattingEnabled = true;
            this.cmbPrice.Location = new System.Drawing.Point(79, 21);
            this.cmbPrice.Name = "cmbPrice";
            this.cmbPrice.Size = new System.Drawing.Size(150, 29);
            this.cmbPrice.TabIndex = 20;
            this.cmbPrice.SelectedIndexChanged += new System.EventHandler(this.cmbPrice_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label6.Location = new System.Drawing.Point(18, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 22);
            this.label6.TabIndex = 21;
            this.label6.Text = "Price:";
            // 
            // btnReload
            // 
            this.btnReload.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReload.BackgroundImage")));
            this.btnReload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReload.Font = new System.Drawing.Font("Bahnschrift", 12.75F);
            this.btnReload.Location = new System.Drawing.Point(1113, 8);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(52, 52);
            this.btnReload.TabIndex = 22;
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.btnAdd.Location = new System.Drawing.Point(47, 19);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.TabIndex = 24;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.btnUpdate.Location = new System.Drawing.Point(206, 19);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 30);
            this.btnUpdate.TabIndex = 25;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.btnDelete.Location = new System.Drawing.Point(366, 19);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.TabIndex = 26;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddUpdatePic
            // 
            this.btnAddUpdatePic.Font = new System.Drawing.Font("Bahnschrift", 11F);
            this.btnAddUpdatePic.Location = new System.Drawing.Point(145, 202);
            this.btnAddUpdatePic.Name = "btnAddUpdatePic";
            this.btnAddUpdatePic.Size = new System.Drawing.Size(75, 30);
            this.btnAddUpdatePic.TabIndex = 27;
            this.btnAddUpdatePic.Text = "Picture";
            this.btnAddUpdatePic.UseVisualStyleBackColor = true;
            this.btnAddUpdatePic.Click += new System.EventHandler(this.btnAddUpdatePic_Click);
            // 
            // txtCategory
            // 
            this.txtCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCategory.Font = new System.Drawing.Font("Bahnschrift Condensed", 11F);
            this.txtCategory.Location = new System.Drawing.Point(107, 247);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(163, 25);
            this.txtCategory.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label5.Location = new System.Drawing.Point(22, 249);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 22);
            this.label5.TabIndex = 28;
            this.label5.Text = "Category:";
            // 
            // txtModel
            // 
            this.txtModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtModel.Font = new System.Drawing.Font("Bahnschrift Condensed", 11F);
            this.txtModel.Location = new System.Drawing.Point(107, 278);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(163, 25);
            this.txtModel.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label7.Location = new System.Drawing.Point(22, 280);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 22);
            this.label7.TabIndex = 30;
            this.label7.Text = "Model:";
            // 
            // txtBrand
            // 
            this.txtBrand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBrand.Font = new System.Drawing.Font("Bahnschrift Condensed", 11F);
            this.txtBrand.Location = new System.Drawing.Point(107, 313);
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.Size = new System.Drawing.Size(163, 25);
            this.txtBrand.TabIndex = 33;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label10.Location = new System.Drawing.Point(22, 315);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 22);
            this.label10.TabIndex = 32;
            this.label10.Text = "Brand:";
            // 
            // txtPrice
            // 
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrice.Font = new System.Drawing.Font("Bahnschrift Condensed", 11F);
            this.txtPrice.Location = new System.Drawing.Point(107, 344);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(163, 25);
            this.txtPrice.TabIndex = 35;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label11.Location = new System.Drawing.Point(22, 346);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 22);
            this.label11.TabIndex = 34;
            this.label11.Text = "Price:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Font = new System.Drawing.Font("Bahnschrift", 10F);
            this.groupBox1.Location = new System.Drawing.Point(395, 577);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(517, 64);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Features:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSearch);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtProductID);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Font = new System.Drawing.Font("Bahnschrift", 10F);
            this.groupBox2.Location = new System.Drawing.Point(395, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(589, 65);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search by: ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbCategory);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.cmbBrand);
            this.groupBox3.Font = new System.Drawing.Font("Bahnschrift", 10F);
            this.groupBox3.Location = new System.Drawing.Point(395, 89);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(529, 65);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filter by:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmbPrice);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Font = new System.Drawing.Font("Bahnschrift", 10F);
            this.groupBox4.Location = new System.Drawing.Point(930, 89);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(235, 65);
            this.groupBox4.TabIndex = 39;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Sort by:";
            // 
            // ProductManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtBrand);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAddUpdatePic);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.rtbSpecs);
            this.Controls.Add(this.lstProduct);
            this.Controls.Add(this.pbProduct);
            this.Font = new System.Drawing.Font("Bahnschrift", 8F);
            this.Name = "ProductManagement";
            this.Size = new System.Drawing.Size(1177, 653);
            ((System.ComponentModel.ISupportInitialize)(this.pbProduct)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstProduct;
        private System.Windows.Forms.PictureBox pbProduct;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.TextBox txtProductID;
        private System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.RichTextBox rtbSpecs;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ImageList imageListProducts;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAddUpdatePic;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}
