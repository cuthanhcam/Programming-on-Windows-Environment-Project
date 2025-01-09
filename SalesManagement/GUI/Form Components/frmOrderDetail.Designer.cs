namespace GUI.Form_Components
{
    partial class frmOrderDetail
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup10 = new System.Windows.Forms.ListViewGroup("Processor", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup11 = new System.Windows.Forms.ListViewGroup("Motherboard", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup12 = new System.Windows.Forms.ListViewGroup("CPU Cooler", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup13 = new System.Windows.Forms.ListViewGroup("Case", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup14 = new System.Windows.Forms.ListViewGroup("Graphic Card", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup15 = new System.Windows.Forms.ListViewGroup("RAM", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup16 = new System.Windows.Forms.ListViewGroup("Storage", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup17 = new System.Windows.Forms.ListViewGroup("Case Cooler", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup18 = new System.Windows.Forms.ListViewGroup("Power Supply", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrderDetail));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstOrderDetail = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblMembershipLevel = new System.Windows.Forms.Label();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblTotalAmountPayable = new System.Windows.Forms.Label();
            this.lblOrderID = new System.Windows.Forms.Label();
            this.lblEmployeeID = new System.Windows.Forms.Label();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 25F);
            this.label1.Location = new System.Drawing.Point(256, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Order Details";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 11F);
            this.label2.Location = new System.Drawing.Point(44, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Order ID:";
            // 
            // lstOrderDetail
            // 
            this.lstOrderDetail.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstOrderDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstOrderDetail.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstOrderDetail.FullRowSelect = true;
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
            this.lstOrderDetail.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup10,
            listViewGroup11,
            listViewGroup12,
            listViewGroup13,
            listViewGroup14,
            listViewGroup15,
            listViewGroup16,
            listViewGroup17,
            listViewGroup18});
            this.lstOrderDetail.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstOrderDetail.HideSelection = false;
            this.lstOrderDetail.Location = new System.Drawing.Point(34, 312);
            this.lstOrderDetail.MultiSelect = false;
            this.lstOrderDetail.Name = "lstOrderDetail";
            this.lstOrderDetail.Size = new System.Drawing.Size(670, 217);
            this.lstOrderDetail.TabIndex = 31;
            this.lstOrderDetail.TileSize = new System.Drawing.Size(500, 30);
            this.lstOrderDetail.UseCompatibleStateImageBehavior = false;
            this.lstOrderDetail.View = System.Windows.Forms.View.Details;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift", 11F);
            this.label3.Location = new System.Drawing.Point(494, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 18);
            this.label3.TabIndex = 32;
            this.label3.Text = "Employee ID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift", 11F);
            this.label4.Location = new System.Drawing.Point(44, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 18);
            this.label4.TabIndex = 33;
            this.label4.Text = "Customer Information:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bahnschrift", 11F);
            this.label5.Location = new System.Drawing.Point(82, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 18);
            this.label5.TabIndex = 34;
            this.label5.Text = "Full Name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bahnschrift", 11F);
            this.label6.Location = new System.Drawing.Point(82, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 18);
            this.label6.TabIndex = 35;
            this.label6.Text = "Phone:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bahnschrift", 11F);
            this.label7.Location = new System.Drawing.Point(82, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 18);
            this.label7.TabIndex = 36;
            this.label7.Text = "Email:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Bahnschrift", 11F);
            this.label8.Location = new System.Drawing.Point(82, 222);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 18);
            this.label8.TabIndex = 37;
            this.label8.Text = "Address:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Bahnschrift", 11F);
            this.label10.Location = new System.Drawing.Point(82, 277);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 18);
            this.label10.TabIndex = 39;
            this.label10.Text = "Order Date:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Bahnschrift", 11F);
            this.label9.Location = new System.Drawing.Point(82, 250);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(135, 18);
            this.label9.TabIndex = 38;
            this.label9.Text = "Membership Level:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Bahnschrift", 11F);
            this.label11.Location = new System.Drawing.Point(362, 543);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 18);
            this.label11.TabIndex = 40;
            this.label11.Text = "Total Amount:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Bahnschrift", 11F);
            this.label12.Location = new System.Drawing.Point(362, 571);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 18);
            this.label12.TabIndex = 41;
            this.label12.Text = "Discount:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Bahnschrift", 11F);
            this.label13.Location = new System.Drawing.Point(362, 602);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(154, 18);
            this.label13.TabIndex = 42;
            this.label13.Text = "Total Amount Payable:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Bahnschrift", 11F);
            this.lblName.Location = new System.Drawing.Point(229, 134);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(64, 18);
            this.lblName.TabIndex = 43;
            this.lblName.Text = "lblName";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Bahnschrift", 11F);
            this.lblEmail.Location = new System.Drawing.Point(229, 162);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(62, 18);
            this.lblEmail.TabIndex = 44;
            this.lblEmail.Text = "lblEmail";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Bahnschrift", 11F);
            this.lblPhone.Location = new System.Drawing.Point(229, 192);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(65, 18);
            this.lblPhone.TabIndex = 45;
            this.lblPhone.Text = "lblPhone";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Bahnschrift", 11F);
            this.lblAddress.Location = new System.Drawing.Point(229, 222);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(80, 18);
            this.lblAddress.TabIndex = 46;
            this.lblAddress.Text = "lblAddress";
            // 
            // lblMembershipLevel
            // 
            this.lblMembershipLevel.AutoSize = true;
            this.lblMembershipLevel.Font = new System.Drawing.Font("Bahnschrift", 11F);
            this.lblMembershipLevel.Location = new System.Drawing.Point(229, 250);
            this.lblMembershipLevel.Name = "lblMembershipLevel";
            this.lblMembershipLevel.Size = new System.Drawing.Size(144, 18);
            this.lblMembershipLevel.TabIndex = 47;
            this.lblMembershipLevel.Text = "lblMembershipLevel";
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Font = new System.Drawing.Font("Bahnschrift", 11F);
            this.lblOrderDate.Location = new System.Drawing.Point(229, 277);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(93, 18);
            this.lblOrderDate.TabIndex = 48;
            this.lblOrderDate.Text = "lblOrderDate";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Bahnschrift", 11F);
            this.lblTotalAmount.Location = new System.Drawing.Point(577, 543);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(107, 18);
            this.lblTotalAmount.TabIndex = 49;
            this.lblTotalAmount.Text = "lblTotalAmount";
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Bahnschrift", 11F);
            this.lblDiscount.Location = new System.Drawing.Point(577, 571);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(82, 18);
            this.lblDiscount.TabIndex = 50;
            this.lblDiscount.Text = "lblDiscount";
            // 
            // lblTotalAmountPayable
            // 
            this.lblTotalAmountPayable.AutoSize = true;
            this.lblTotalAmountPayable.Font = new System.Drawing.Font("Bahnschrift", 11F);
            this.lblTotalAmountPayable.Location = new System.Drawing.Point(577, 602);
            this.lblTotalAmountPayable.Name = "lblTotalAmountPayable";
            this.lblTotalAmountPayable.Size = new System.Drawing.Size(159, 18);
            this.lblTotalAmountPayable.TabIndex = 51;
            this.lblTotalAmountPayable.Text = "lblTotalAmountPayable";
            // 
            // lblOrderID
            // 
            this.lblOrderID.AutoSize = true;
            this.lblOrderID.Font = new System.Drawing.Font("Bahnschrift", 11F);
            this.lblOrderID.Location = new System.Drawing.Point(117, 69);
            this.lblOrderID.Name = "lblOrderID";
            this.lblOrderID.Size = new System.Drawing.Size(76, 18);
            this.lblOrderID.TabIndex = 52;
            this.lblOrderID.Text = "lblOrderID";
            // 
            // lblEmployeeID
            // 
            this.lblEmployeeID.AutoSize = true;
            this.lblEmployeeID.Font = new System.Drawing.Font("Bahnschrift", 11F);
            this.lblEmployeeID.Location = new System.Drawing.Point(594, 69);
            this.lblEmployeeID.Name = "lblEmployeeID";
            this.lblEmployeeID.Size = new System.Drawing.Size(103, 18);
            this.lblEmployeeID.TabIndex = 53;
            this.lblEmployeeID.Text = "lblEmployeeID";
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(35, 35);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // frmOrderDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(734, 661);
            this.Controls.Add(this.lblEmployeeID);
            this.Controls.Add(this.lblOrderID);
            this.Controls.Add(this.lblTotalAmountPayable);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.lblOrderDate);
            this.Controls.Add(this.lblMembershipLevel);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstOrderDetail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOrderDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order Details";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lstOrderDetail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblMembershipLevel;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblTotalAmountPayable;
        private System.Windows.Forms.Label lblOrderID;
        private System.Windows.Forms.Label lblEmployeeID;
        private System.Windows.Forms.ImageList imageList;
    }
}