namespace GUI
{
    partial class EmployeeManagement
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Processor", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Motherboard", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("CPU Cooler", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Case", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Graphic Card", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("RAM", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup7 = new System.Windows.Forms.ListViewGroup("Storage", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup8 = new System.Windows.Forms.ListViewGroup("Case Cooler", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup9 = new System.Windows.Forms.ListViewGroup("Power Supply", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeManagement));
            this.lstEmployees = new System.Windows.Forms.ListView();
            this.btnReload = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmployeeID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbPositionFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmbSalary = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dtpHireDate = new System.Windows.Forms.DateTimePicker();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            this.txtSalary = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstEmployees
            // 
            this.lstEmployees.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstEmployees.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstEmployees.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstEmployees.FullRowSelect = true;
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
            this.lstEmployees.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4,
            listViewGroup5,
            listViewGroup6,
            listViewGroup7,
            listViewGroup8,
            listViewGroup9});
            this.lstEmployees.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstEmployees.HideSelection = false;
            this.lstEmployees.Location = new System.Drawing.Point(395, 166);
            this.lstEmployees.MultiSelect = false;
            this.lstEmployees.Name = "lstEmployees";
            this.lstEmployees.Size = new System.Drawing.Size(770, 405);
            this.lstEmployees.TabIndex = 1;
            this.lstEmployees.TileSize = new System.Drawing.Size(500, 30);
            this.lstEmployees.UseCompatibleStateImageBehavior = false;
            this.lstEmployees.View = System.Windows.Forms.View.Details;
            this.lstEmployees.SelectedIndexChanged += new System.EventHandler(this.lstEmployees_SelectedIndexChanged);
            // 
            // btnReload
            // 
            this.btnReload.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReload.BackgroundImage")));
            this.btnReload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReload.Font = new System.Drawing.Font("Bahnschrift", 12.75F);
            this.btnReload.Location = new System.Drawing.Point(1113, 8);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(52, 52);
            this.btnReload.TabIndex = 23;
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
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
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Features:";
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSearchName);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtEmployeeID);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Font = new System.Drawing.Font("Bahnschrift", 10F);
            this.groupBox2.Location = new System.Drawing.Point(395, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(527, 65);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search by: ";
            // 
            // txtSearchName
            // 
            this.txtSearchName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchName.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.txtSearchName.Location = new System.Drawing.Point(314, 24);
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(185, 28);
            this.txtSearchName.TabIndex = 18;
            this.txtSearchName.TextChanged += new System.EventHandler(this.txtSearchName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label3.Location = new System.Drawing.Point(30, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Employee ID:";
            // 
            // txtEmployeeID
            // 
            this.txtEmployeeID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmployeeID.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.txtEmployeeID.Location = new System.Drawing.Point(120, 24);
            this.txtEmployeeID.Name = "txtEmployeeID";
            this.txtEmployeeID.Size = new System.Drawing.Size(100, 28);
            this.txtEmployeeID.TabIndex = 9;
            this.txtEmployeeID.TextChanged += new System.EventHandler(this.txtEmployeeID_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label9.Location = new System.Drawing.Point(260, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 22);
            this.label9.TabIndex = 19;
            this.label9.Text = "Name:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbPositionFilter);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Font = new System.Drawing.Font("Bahnschrift", 10F);
            this.groupBox3.Location = new System.Drawing.Point(395, 83);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(286, 65);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filter by:";
            // 
            // cmbPositionFilter
            // 
            this.cmbPositionFilter.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.cmbPositionFilter.FormattingEnabled = true;
            this.cmbPositionFilter.Location = new System.Drawing.Point(102, 21);
            this.cmbPositionFilter.Name = "cmbPositionFilter";
            this.cmbPositionFilter.Size = new System.Drawing.Size(150, 29);
            this.cmbPositionFilter.TabIndex = 6;
            this.cmbPositionFilter.SelectedIndexChanged += new System.EventHandler(this.cmbPositionFilter_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label1.Location = new System.Drawing.Point(30, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Position:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmbSalary);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Font = new System.Drawing.Font("Bahnschrift", 10F);
            this.groupBox4.Location = new System.Drawing.Point(930, 83);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(235, 65);
            this.groupBox4.TabIndex = 40;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Sort by:";
            // 
            // cmbSalary
            // 
            this.cmbSalary.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.cmbSalary.FormattingEnabled = true;
            this.cmbSalary.Location = new System.Drawing.Point(79, 21);
            this.cmbSalary.Name = "cmbSalary";
            this.cmbSalary.Size = new System.Drawing.Size(150, 29);
            this.cmbSalary.TabIndex = 20;
            this.cmbSalary.SelectedIndexChanged += new System.EventHandler(this.cmbSalary_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label6.Location = new System.Drawing.Point(18, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 22);
            this.label6.TabIndex = 21;
            this.label6.Text = "Salary:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dtpHireDate);
            this.groupBox5.Controls.Add(this.cmbPosition);
            this.groupBox5.Controls.Add(this.txtSalary);
            this.groupBox5.Controls.Add(this.txtAddress);
            this.groupBox5.Controls.Add(this.txtPhone);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.txtName);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Font = new System.Drawing.Font("Bahnschrift", 10F);
            this.groupBox5.Location = new System.Drawing.Point(15, 8);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(361, 332);
            this.groupBox5.TabIndex = 41;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Employee Information:";
            // 
            // dtpHireDate
            // 
            this.dtpHireDate.CalendarFont = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.dtpHireDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHireDate.Location = new System.Drawing.Point(98, 285);
            this.dtpHireDate.Name = "dtpHireDate";
            this.dtpHireDate.Size = new System.Drawing.Size(241, 24);
            this.dtpHireDate.TabIndex = 30;
            // 
            // cmbPosition
            // 
            this.cmbPosition.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.cmbPosition.FormattingEnabled = true;
            this.cmbPosition.Location = new System.Drawing.Point(99, 185);
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.Size = new System.Drawing.Size(240, 29);
            this.cmbPosition.TabIndex = 29;
            // 
            // txtSalary
            // 
            this.txtSalary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSalary.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.txtSalary.Location = new System.Drawing.Point(99, 237);
            this.txtSalary.Name = "txtSalary";
            this.txtSalary.Size = new System.Drawing.Size(240, 28);
            this.txtSalary.TabIndex = 28;
            // 
            // txtAddress
            // 
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.txtAddress.Location = new System.Drawing.Point(99, 137);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(240, 28);
            this.txtAddress.TabIndex = 27;
            // 
            // txtPhone
            // 
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.txtPhone.Location = new System.Drawing.Point(99, 90);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(240, 28);
            this.txtPhone.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label10.Location = new System.Drawing.Point(21, 285);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 22);
            this.label10.TabIndex = 25;
            this.label10.Text = "Hire Date:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label8.Location = new System.Drawing.Point(21, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 22);
            this.label8.TabIndex = 24;
            this.label8.Text = "Address:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label7.Location = new System.Drawing.Point(21, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 22);
            this.label7.TabIndex = 23;
            this.label7.Text = "Phone:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label5.Location = new System.Drawing.Point(21, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 22);
            this.label5.TabIndex = 22;
            this.label5.Text = "Salary:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label2.Location = new System.Drawing.Point(22, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 22);
            this.label2.TabIndex = 21;
            this.label2.Text = "Position:";
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.txtName.Location = new System.Drawing.Point(99, 41);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(240, 28);
            this.txtName.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label4.Location = new System.Drawing.Point(21, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 22);
            this.label4.TabIndex = 19;
            this.label4.Text = "Name:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtPassword);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.txtUsername);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Font = new System.Drawing.Font("Bahnschrift", 10F);
            this.groupBox6.Location = new System.Drawing.Point(15, 359);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(361, 166);
            this.groupBox6.TabIndex = 42;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Account Information:";
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.txtPassword.Location = new System.Drawing.Point(99, 81);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(240, 28);
            this.txtPassword.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label11.Location = new System.Drawing.Point(21, 81);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 22);
            this.label11.TabIndex = 21;
            this.label11.Text = "Password:";
            // 
            // txtUsername
            // 
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.txtUsername.Location = new System.Drawing.Point(99, 41);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(240, 28);
            this.txtUsername.TabIndex = 18;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label12.Location = new System.Drawing.Point(21, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 22);
            this.label12.TabIndex = 19;
            this.label12.Text = "Username:";
            // 
            // EmployeeManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.lstEmployees);
            this.Font = new System.Drawing.Font("Bahnschrift", 8F);
            this.Name = "EmployeeManagement";
            this.Size = new System.Drawing.Size(1177, 653);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstEmployees;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmployeeID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbPositionFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cmbSalary;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.TextBox txtSalary;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpHireDate;
    }
}
