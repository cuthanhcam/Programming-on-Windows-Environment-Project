namespace GUI.Form_Components
{
    partial class frmPurchaseHistory
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
            System.Windows.Forms.ListViewGroup listViewGroup10 = new System.Windows.Forms.ListViewGroup("Processor", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup11 = new System.Windows.Forms.ListViewGroup("Motherboard", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup12 = new System.Windows.Forms.ListViewGroup("CPU Cooler", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup13 = new System.Windows.Forms.ListViewGroup("Case", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup14 = new System.Windows.Forms.ListViewGroup("Graphic Card", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup15 = new System.Windows.Forms.ListViewGroup("RAM", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup16 = new System.Windows.Forms.ListViewGroup("Storage", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup17 = new System.Windows.Forms.ListViewGroup("Case Cooler", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup18 = new System.Windows.Forms.ListViewGroup("Power Supply", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPurchaseHistory));
            this.lstPurchaseHistory = new System.Windows.Forms.ListView();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstPurchaseHistory
            // 
            this.lstPurchaseHistory.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstPurchaseHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstPurchaseHistory.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstPurchaseHistory.FullRowSelect = true;
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
            this.lstPurchaseHistory.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup10,
            listViewGroup11,
            listViewGroup12,
            listViewGroup13,
            listViewGroup14,
            listViewGroup15,
            listViewGroup16,
            listViewGroup17,
            listViewGroup18});
            this.lstPurchaseHistory.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstPurchaseHistory.HideSelection = false;
            this.lstPurchaseHistory.Location = new System.Drawing.Point(12, 12);
            this.lstPurchaseHistory.MultiSelect = false;
            this.lstPurchaseHistory.Name = "lstPurchaseHistory";
            this.lstPurchaseHistory.Size = new System.Drawing.Size(470, 501);
            this.lstPurchaseHistory.TabIndex = 37;
            this.lstPurchaseHistory.TileSize = new System.Drawing.Size(500, 30);
            this.lstPurchaseHistory.UseCompatibleStateImageBehavior = false;
            this.lstPurchaseHistory.View = System.Windows.Forms.View.Details;
            this.lstPurchaseHistory.DoubleClick += new System.EventHandler(this.lstPurchaseHistory_DoubleClick);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.btnClose.Location = new System.Drawing.Point(382, 530);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.TabIndex = 38;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmPurchaseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(494, 572);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lstPurchaseHistory);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPurchaseHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer History";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPurchaseHistory_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstPurchaseHistory;
        private System.Windows.Forms.Button btnClose;
    }
}