namespace GUI
{
    partial class StockManagement
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
            System.Windows.Forms.ListViewGroup listViewGroup244 = new System.Windows.Forms.ListViewGroup("Processor", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup245 = new System.Windows.Forms.ListViewGroup("Motherboard", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup246 = new System.Windows.Forms.ListViewGroup("CPU Cooler", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup247 = new System.Windows.Forms.ListViewGroup("Case", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup248 = new System.Windows.Forms.ListViewGroup("Graphic Card", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup249 = new System.Windows.Forms.ListViewGroup("RAM", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup250 = new System.Windows.Forms.ListViewGroup("Storage", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup251 = new System.Windows.Forms.ListViewGroup("Case Cooler", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup252 = new System.Windows.Forms.ListViewGroup("Power Supply", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup235 = new System.Windows.Forms.ListViewGroup("Processor", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup236 = new System.Windows.Forms.ListViewGroup("Motherboard", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup237 = new System.Windows.Forms.ListViewGroup("CPU Cooler", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup238 = new System.Windows.Forms.ListViewGroup("Case", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup239 = new System.Windows.Forms.ListViewGroup("Graphic Card", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup240 = new System.Windows.Forms.ListViewGroup("RAM", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup241 = new System.Windows.Forms.ListViewGroup("Storage", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup242 = new System.Windows.Forms.ListViewGroup("Case Cooler", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup243 = new System.Windows.Forms.ListViewGroup("Power Supply", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockManagement));
            this.tcStockTransactions = new System.Windows.Forms.TabControl();
            this.tpTransactionHistory = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpTransactionDateEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpTransactionDateStart = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lstTransactionHistory = new System.Windows.Forms.ListView();
            this.btnReloadTransactionHistory = new System.Windows.Forms.Button();
            this.tpImportExport = new System.Windows.Forms.TabPage();
            this.btnMakeTransaction = new System.Windows.Forms.Button();
            this.cmbTransactionType = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.rtbNote = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbStockQuantity = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lstProduct = new System.Windows.Forms.ListView();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.btnReloadImportExport = new System.Windows.Forms.Button();
            this.cmbDate = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTransactionID = new System.Windows.Forms.TextBox();
            this.tcStockTransactions.SuspendLayout();
            this.tpTransactionHistory.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tpImportExport.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // tcStockTransactions
            // 
            this.tcStockTransactions.Controls.Add(this.tpTransactionHistory);
            this.tcStockTransactions.Controls.Add(this.tpImportExport);
            this.tcStockTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcStockTransactions.Font = new System.Drawing.Font("Bahnschrift", 12.75F);
            this.tcStockTransactions.ItemSize = new System.Drawing.Size(150, 30);
            this.tcStockTransactions.Location = new System.Drawing.Point(0, 0);
            this.tcStockTransactions.Name = "tcStockTransactions";
            this.tcStockTransactions.SelectedIndex = 0;
            this.tcStockTransactions.Size = new System.Drawing.Size(1177, 653);
            this.tcStockTransactions.TabIndex = 1;
            // 
            // tpTransactionHistory
            // 
            this.tpTransactionHistory.BackColor = System.Drawing.Color.White;
            this.tpTransactionHistory.Controls.Add(this.groupBox2);
            this.tpTransactionHistory.Controls.Add(this.groupBox4);
            this.tpTransactionHistory.Controls.Add(this.lstTransactionHistory);
            this.tpTransactionHistory.Controls.Add(this.btnReloadTransactionHistory);
            this.tpTransactionHistory.Location = new System.Drawing.Point(4, 34);
            this.tpTransactionHistory.Name = "tpTransactionHistory";
            this.tpTransactionHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tpTransactionHistory.Size = new System.Drawing.Size(1169, 615);
            this.tpTransactionHistory.TabIndex = 0;
            this.tpTransactionHistory.Text = "Transaction History";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtTransactionID);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.dtpTransactionDateEnd);
            this.groupBox2.Controls.Add(this.dtpTransactionDateStart);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Font = new System.Drawing.Font("Bahnschrift", 10F);
            this.groupBox2.Location = new System.Drawing.Point(36, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(705, 65);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search by: ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label10.Location = new System.Drawing.Point(509, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 22);
            this.label10.TabIndex = 47;
            this.label10.Text = "-";
            // 
            // dtpTransactionDateEnd
            // 
            this.dtpTransactionDateEnd.CalendarFont = new System.Drawing.Font("Bahnschrift Condensed", 12F);
            this.dtpTransactionDateEnd.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.dtpTransactionDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTransactionDateEnd.Location = new System.Drawing.Point(531, 22);
            this.dtpTransactionDateEnd.Name = "dtpTransactionDateEnd";
            this.dtpTransactionDateEnd.Size = new System.Drawing.Size(165, 28);
            this.dtpTransactionDateEnd.TabIndex = 46;
            this.dtpTransactionDateEnd.ValueChanged += new System.EventHandler(this.dtpTransactionDateEnd_ValueChanged);
            // 
            // dtpTransactionDateStart
            // 
            this.dtpTransactionDateStart.CalendarFont = new System.Drawing.Font("Bahnschrift Condensed", 12F);
            this.dtpTransactionDateStart.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.dtpTransactionDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTransactionDateStart.Location = new System.Drawing.Point(338, 22);
            this.dtpTransactionDateStart.Name = "dtpTransactionDateStart";
            this.dtpTransactionDateStart.Size = new System.Drawing.Size(165, 28);
            this.dtpTransactionDateStart.TabIndex = 45;
            this.dtpTransactionDateStart.ValueChanged += new System.EventHandler(this.dtpTransactionDateStart_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label9.Location = new System.Drawing.Point(218, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 22);
            this.label9.TabIndex = 10;
            this.label9.Text = "Transaction Date:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmbDate);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Font = new System.Drawing.Font("Bahnschrift", 10F);
            this.groupBox4.Location = new System.Drawing.Point(747, 33);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(257, 65);
            this.groupBox4.TabIndex = 40;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Sort by:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label7.Location = new System.Drawing.Point(29, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 22);
            this.label7.TabIndex = 21;
            this.label7.Text = "Date:";
            // 
            // lstTransactionHistory
            // 
            this.lstTransactionHistory.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstTransactionHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstTransactionHistory.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.lstTransactionHistory.FullRowSelect = true;
            listViewGroup244.Header = "Processor";
            listViewGroup244.Name = "listViewGroupProcessor";
            listViewGroup245.Header = "Motherboard";
            listViewGroup245.Name = "listViewGroupMotherboard";
            listViewGroup246.Header = "CPU Cooler";
            listViewGroup246.Name = "listViewGroupCPUCooler";
            listViewGroup247.Header = "Case";
            listViewGroup247.Name = "listViewGroupCase";
            listViewGroup248.Header = "Graphic Card";
            listViewGroup248.Name = "listViewGroupGraphicCard";
            listViewGroup249.Header = "RAM";
            listViewGroup249.Name = "listViewGroupRAM";
            listViewGroup250.Header = "Storage";
            listViewGroup250.Name = "listViewGroupStorage";
            listViewGroup251.Header = "Case Cooler";
            listViewGroup251.Name = "listViewGroupCaseCooler";
            listViewGroup252.Header = "Power Supply";
            listViewGroup252.Name = "listViewGroupPowerSupply";
            this.lstTransactionHistory.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup244,
            listViewGroup245,
            listViewGroup246,
            listViewGroup247,
            listViewGroup248,
            listViewGroup249,
            listViewGroup250,
            listViewGroup251,
            listViewGroup252});
            this.lstTransactionHistory.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstTransactionHistory.HideSelection = false;
            this.lstTransactionHistory.Location = new System.Drawing.Point(36, 117);
            this.lstTransactionHistory.MultiSelect = false;
            this.lstTransactionHistory.Name = "lstTransactionHistory";
            this.lstTransactionHistory.Size = new System.Drawing.Size(1100, 469);
            this.lstTransactionHistory.TabIndex = 31;
            this.lstTransactionHistory.TileSize = new System.Drawing.Size(500, 30);
            this.lstTransactionHistory.UseCompatibleStateImageBehavior = false;
            this.lstTransactionHistory.View = System.Windows.Forms.View.Details;
            // 
            // btnReloadTransactionHistory
            // 
            this.btnReloadTransactionHistory.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReloadTransactionHistory.BackgroundImage")));
            this.btnReloadTransactionHistory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReloadTransactionHistory.Font = new System.Drawing.Font("Bahnschrift", 12.75F);
            this.btnReloadTransactionHistory.Location = new System.Drawing.Point(1111, 6);
            this.btnReloadTransactionHistory.Name = "btnReloadTransactionHistory";
            this.btnReloadTransactionHistory.Size = new System.Drawing.Size(52, 52);
            this.btnReloadTransactionHistory.TabIndex = 24;
            this.btnReloadTransactionHistory.UseVisualStyleBackColor = true;
            this.btnReloadTransactionHistory.Click += new System.EventHandler(this.btnReloadTransactionHistory_Click);
            // 
            // tpImportExport
            // 
            this.tpImportExport.BackColor = System.Drawing.Color.White;
            this.tpImportExport.Controls.Add(this.btnMakeTransaction);
            this.tpImportExport.Controls.Add(this.cmbTransactionType);
            this.tpImportExport.Controls.Add(this.label13);
            this.tpImportExport.Controls.Add(this.label12);
            this.tpImportExport.Controls.Add(this.rtbNote);
            this.tpImportExport.Controls.Add(this.groupBox1);
            this.tpImportExport.Controls.Add(this.groupBox3);
            this.tpImportExport.Controls.Add(this.groupBox5);
            this.tpImportExport.Controls.Add(this.lstProduct);
            this.tpImportExport.Controls.Add(this.nudQuantity);
            this.tpImportExport.Controls.Add(this.label6);
            this.tpImportExport.Controls.Add(this.btnReloadImportExport);
            this.tpImportExport.Location = new System.Drawing.Point(4, 34);
            this.tpImportExport.Name = "tpImportExport";
            this.tpImportExport.Padding = new System.Windows.Forms.Padding(3);
            this.tpImportExport.Size = new System.Drawing.Size(1169, 615);
            this.tpImportExport.TabIndex = 2;
            this.tpImportExport.Text = "Import - Export";
            // 
            // btnMakeTransaction
            // 
            this.btnMakeTransaction.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.btnMakeTransaction.Location = new System.Drawing.Point(42, 525);
            this.btnMakeTransaction.Name = "btnMakeTransaction";
            this.btnMakeTransaction.Size = new System.Drawing.Size(250, 50);
            this.btnMakeTransaction.TabIndex = 48;
            this.btnMakeTransaction.Text = "Make Transaction";
            this.btnMakeTransaction.UseVisualStyleBackColor = true;
            this.btnMakeTransaction.Click += new System.EventHandler(this.btnMakeTransaction_Click);
            // 
            // cmbTransactionType
            // 
            this.cmbTransactionType.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.cmbTransactionType.FormattingEnabled = true;
            this.cmbTransactionType.Location = new System.Drawing.Point(170, 170);
            this.cmbTransactionType.Name = "cmbTransactionType";
            this.cmbTransactionType.Size = new System.Drawing.Size(150, 29);
            this.cmbTransactionType.TabIndex = 22;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label13.Location = new System.Drawing.Point(38, 173);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(110, 22);
            this.label13.TabIndex = 23;
            this.label13.Text = "Transaction Type";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label12.Location = new System.Drawing.Point(38, 275);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 22);
            this.label12.TabIndex = 47;
            this.label12.Text = "Note:";
            // 
            // rtbNote
            // 
            this.rtbNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbNote.Font = new System.Drawing.Font("Bahnschrift", 12.75F);
            this.rtbNote.Location = new System.Drawing.Point(42, 300);
            this.rtbNote.Name = "rtbNote";
            this.rtbNote.Size = new System.Drawing.Size(278, 104);
            this.rtbNote.TabIndex = 46;
            this.rtbNote.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbStockQuantity);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Bahnschrift", 10F);
            this.groupBox1.Location = new System.Drawing.Point(855, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 65);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sort by:";
            // 
            // cmbStockQuantity
            // 
            this.cmbStockQuantity.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.cmbStockQuantity.FormattingEnabled = true;
            this.cmbStockQuantity.Location = new System.Drawing.Point(110, 21);
            this.cmbStockQuantity.Name = "cmbStockQuantity";
            this.cmbStockQuantity.Size = new System.Drawing.Size(150, 29);
            this.cmbStockQuantity.TabIndex = 20;
            this.cmbStockQuantity.SelectedIndexChanged += new System.EventHandler(this.cmbStockQuantity_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 22);
            this.label2.TabIndex = 21;
            this.label2.Text = "Stock Quantity:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbCategory);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.cmbBrand);
            this.groupBox3.Font = new System.Drawing.Font("Bahnschrift", 10F);
            this.groupBox3.Location = new System.Drawing.Point(351, 85);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(498, 65);
            this.groupBox3.TabIndex = 43;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filter by:";
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
            this.label3.Location = new System.Drawing.Point(276, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 22);
            this.label3.TabIndex = 3;
            this.label3.Text = "Brand:";
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
            // cmbBrand
            // 
            this.cmbBrand.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(331, 21);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(150, 29);
            this.cmbBrand.TabIndex = 7;
            this.cmbBrand.SelectedIndexChanged += new System.EventHandler(this.cmbBrand_SelectedIndexChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtModel);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.txtProductID);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Font = new System.Drawing.Font("Bahnschrift", 10F);
            this.groupBox5.Location = new System.Drawing.Point(351, 14);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(589, 65);
            this.groupBox5.TabIndex = 42;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Search by: ";
            // 
            // txtModel
            // 
            this.txtModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtModel.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.txtModel.Location = new System.Drawing.Point(366, 24);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(185, 28);
            this.txtModel.TabIndex = 18;
            this.txtModel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtModel_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label4.Location = new System.Drawing.Point(30, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 22);
            this.label4.TabIndex = 4;
            this.label4.Text = "Product ID:";
            // 
            // txtProductID
            // 
            this.txtProductID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductID.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.txtProductID.Location = new System.Drawing.Point(110, 24);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Size = new System.Drawing.Size(100, 28);
            this.txtProductID.TabIndex = 9;
            this.txtProductID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProductID_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label5.Location = new System.Drawing.Point(276, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 22);
            this.label5.TabIndex = 19;
            this.label5.Text = "Model name:";
            // 
            // lstProduct
            // 
            this.lstProduct.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstProduct.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstProduct.FullRowSelect = true;
            listViewGroup235.Header = "Processor";
            listViewGroup235.Name = "listViewGroupProcessor";
            listViewGroup236.Header = "Motherboard";
            listViewGroup236.Name = "listViewGroupMotherboard";
            listViewGroup237.Header = "CPU Cooler";
            listViewGroup237.Name = "listViewGroupCPUCooler";
            listViewGroup238.Header = "Case";
            listViewGroup238.Name = "listViewGroupCase";
            listViewGroup239.Header = "Graphic Card";
            listViewGroup239.Name = "listViewGroupGraphicCard";
            listViewGroup240.Header = "RAM";
            listViewGroup240.Name = "listViewGroupRAM";
            listViewGroup241.Header = "Storage";
            listViewGroup241.Name = "listViewGroupStorage";
            listViewGroup242.Header = "Case Cooler";
            listViewGroup242.Name = "listViewGroupCaseCooler";
            listViewGroup243.Header = "Power Supply";
            listViewGroup243.Name = "listViewGroupPowerSupply";
            this.lstProduct.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup235,
            listViewGroup236,
            listViewGroup237,
            listViewGroup238,
            listViewGroup239,
            listViewGroup240,
            listViewGroup241,
            listViewGroup242,
            listViewGroup243});
            this.lstProduct.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstProduct.HideSelection = false;
            this.lstProduct.Location = new System.Drawing.Point(351, 170);
            this.lstProduct.MultiSelect = false;
            this.lstProduct.Name = "lstProduct";
            this.lstProduct.Size = new System.Drawing.Size(770, 405);
            this.lstProduct.TabIndex = 41;
            this.lstProduct.TileSize = new System.Drawing.Size(500, 30);
            this.lstProduct.UseCompatibleStateImageBehavior = false;
            this.lstProduct.View = System.Windows.Forms.View.Details;
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(170, 221);
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(50, 28);
            this.nudQuantity.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label6.Location = new System.Drawing.Point(38, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 22);
            this.label6.TabIndex = 34;
            this.label6.Text = "Quantity:";
            // 
            // btnReloadImportExport
            // 
            this.btnReloadImportExport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReloadImportExport.BackgroundImage")));
            this.btnReloadImportExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReloadImportExport.Font = new System.Drawing.Font("Bahnschrift", 12.75F);
            this.btnReloadImportExport.Location = new System.Drawing.Point(1103, 14);
            this.btnReloadImportExport.Name = "btnReloadImportExport";
            this.btnReloadImportExport.Size = new System.Drawing.Size(52, 52);
            this.btnReloadImportExport.TabIndex = 23;
            this.btnReloadImportExport.UseVisualStyleBackColor = true;
            this.btnReloadImportExport.Click += new System.EventHandler(this.btnReloadImportExport_Click);
            // 
            // cmbDate
            // 
            this.cmbDate.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.cmbDate.FormattingEnabled = true;
            this.cmbDate.Location = new System.Drawing.Point(75, 21);
            this.cmbDate.Name = "cmbDate";
            this.cmbDate.Size = new System.Drawing.Size(150, 29);
            this.cmbDate.TabIndex = 22;
            this.cmbDate.SelectedIndexChanged += new System.EventHandler(this.cmbDate_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label8.Location = new System.Drawing.Point(15, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 22);
            this.label8.TabIndex = 48;
            this.label8.Text = "Transaction ID:";
            // 
            // txtTransactionID
            // 
            this.txtTransactionID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTransactionID.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.txtTransactionID.Location = new System.Drawing.Point(118, 22);
            this.txtTransactionID.Name = "txtTransactionID";
            this.txtTransactionID.Size = new System.Drawing.Size(75, 28);
            this.txtTransactionID.TabIndex = 49;
            this.txtTransactionID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTransactionID_KeyPress);
            // 
            // StockManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tcStockTransactions);
            this.Name = "StockManagement";
            this.Size = new System.Drawing.Size(1177, 653);
            this.tcStockTransactions.ResumeLayout(false);
            this.tpTransactionHistory.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tpImportExport.ResumeLayout(false);
            this.tpImportExport.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcStockTransactions;
        private System.Windows.Forms.TabPage tpTransactionHistory;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpTransactionDateEnd;
        private System.Windows.Forms.DateTimePicker dtpTransactionDateStart;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView lstTransactionHistory;
        private System.Windows.Forms.Button btnReloadTransactionHistory;
        private System.Windows.Forms.TabPage tpImportExport;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnReloadImportExport;
        private System.Windows.Forms.ListView lstProduct;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbStockQuantity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProductID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RichTextBox rtbNote;
        private System.Windows.Forms.ComboBox cmbTransactionType;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnMakeTransaction;
        private System.Windows.Forms.ComboBox cmbDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTransactionID;
    }
}
