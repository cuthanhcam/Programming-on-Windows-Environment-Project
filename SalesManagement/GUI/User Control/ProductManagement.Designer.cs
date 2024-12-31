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
            this.lstProduct = new System.Windows.Forms.ListView();
            this.imageListProducts = new System.Windows.Forms.ImageList(this.components);
            this.richTextBoxDetail = new System.Windows.Forms.RichTextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.pbProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // lstProduct
            // 
            this.lstProduct.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstProduct.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstProduct.FullRowSelect = true;
            this.lstProduct.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstProduct.HideSelection = false;
            this.lstProduct.Location = new System.Drawing.Point(395, 142);
            this.lstProduct.MultiSelect = false;
            this.lstProduct.Name = "lstProduct";
            this.lstProduct.Size = new System.Drawing.Size(770, 500);
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
            this.imageListProducts.ImageSize = new System.Drawing.Size(40, 40);
            this.imageListProducts.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // richTextBoxDetail
            // 
            this.richTextBoxDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxDetail.Font = new System.Drawing.Font("Bahnschrift", 12.75F);
            this.richTextBoxDetail.Location = new System.Drawing.Point(26, 309);
            this.richTextBoxDetail.Name = "richTextBoxDetail";
            this.richTextBoxDetail.Size = new System.Drawing.Size(281, 333);
            this.richTextBoxDetail.TabIndex = 17;
            this.richTextBoxDetail.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label8.Location = new System.Drawing.Point(22, 273);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 22);
            this.label8.TabIndex = 16;
            this.label8.Text = "Detail:";
            // 
            // txtProductID
            // 
            this.txtProductID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductID.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.txtProductID.Location = new System.Drawing.Point(107, 225);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Size = new System.Drawing.Size(163, 28);
            this.txtProductID.TabIndex = 9;
            this.txtProductID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProductID_KeyPress);
            // 
            // cmbBrand
            // 
            this.cmbBrand.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(739, 85);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(150, 29);
            this.cmbBrand.TabIndex = 7;
            this.cmbBrand.SelectedIndexChanged += new System.EventHandler(this.cmbBrand_SelectedIndexChanged);
            // 
            // cmbCategory
            // 
            this.cmbCategory.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(463, 85);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(150, 29);
            this.cmbCategory.TabIndex = 6;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label3.Location = new System.Drawing.Point(22, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Product ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label2.Location = new System.Drawing.Point(684, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Brand:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label1.Location = new System.Drawing.Point(391, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Category:";
            // 
            // pbProduct
            // 
            this.pbProduct.Location = new System.Drawing.Point(92, 24);
            this.pbProduct.Name = "pbProduct";
            this.pbProduct.Size = new System.Drawing.Size(178, 176);
            this.pbProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProduct.TabIndex = 0;
            this.pbProduct.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Bahnschrift Condensed", 11F);
            this.txtSearch.Location = new System.Drawing.Point(548, 24);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 25);
            this.txtSearch.TabIndex = 18;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label9.Location = new System.Drawing.Point(391, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(151, 22);
            this.label9.TabIndex = 19;
            this.label9.Text = "Search by model name:";
            // 
            // cmbPrice
            // 
            this.cmbPrice.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.cmbPrice.FormattingEnabled = true;
            this.cmbPrice.Location = new System.Drawing.Point(1006, 85);
            this.cmbPrice.Name = "cmbPrice";
            this.cmbPrice.Size = new System.Drawing.Size(150, 29);
            this.cmbPrice.TabIndex = 20;
            this.cmbPrice.SelectedIndexChanged += new System.EventHandler(this.cmbPrice_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label6.Location = new System.Drawing.Point(951, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 22);
            this.label6.TabIndex = 21;
            this.label6.Text = "Price:";
            // 
            // ProductManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbPrice);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.richTextBoxDetail);
            this.Controls.Add(this.lstProduct);
            this.Controls.Add(this.txtProductID);
            this.Controls.Add(this.pbProduct);
            this.Controls.Add(this.cmbBrand);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Bahnschrift", 8F);
            this.Name = "ProductManagement";
            this.Size = new System.Drawing.Size(1177, 653);
            ((System.ComponentModel.ISupportInitialize)(this.pbProduct)).EndInit();
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
        private System.Windows.Forms.RichTextBox richTextBoxDetail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ImageList imageListProducts;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbPrice;
        private System.Windows.Forms.Label label6;
    }
}
