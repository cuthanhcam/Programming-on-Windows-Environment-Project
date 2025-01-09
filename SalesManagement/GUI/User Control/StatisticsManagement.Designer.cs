namespace GUI.User_Control
{
    partial class StatisticsManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatisticsManagement));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tpSummaryReports = new System.Windows.Forms.TabPage();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.btnReloadSummaryReports = new System.Windows.Forms.Button();
            this.lstSummary = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTable = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tpRevenue = new System.Windows.Forms.TabPage();
            this.chartRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lstRevenueDetails = new System.Windows.Forms.ListView();
            this.btnRevenueFilter = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbRevenueProductCategory = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpRevenueEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpRevenueStartDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.lblRevenueTitle = new System.Windows.Forms.Label();
            this.btnReloadRevenueStatistics = new System.Windows.Forms.Button();
            this.tcStatistics = new System.Windows.Forms.TabControl();
            this.tpSummaryReports.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tpRevenue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tcStatistics.SuspendLayout();
            this.SuspendLayout();
            // 
            // tpSummaryReports
            // 
            this.tpSummaryReports.BackColor = System.Drawing.Color.White;
            this.tpSummaryReports.Controls.Add(this.btnExportToExcel);
            this.tpSummaryReports.Controls.Add(this.btnReloadSummaryReports);
            this.tpSummaryReports.Controls.Add(this.lstSummary);
            this.tpSummaryReports.Controls.Add(this.groupBox1);
            this.tpSummaryReports.Controls.Add(this.label2);
            this.tpSummaryReports.Location = new System.Drawing.Point(4, 34);
            this.tpSummaryReports.Name = "tpSummaryReports";
            this.tpSummaryReports.Padding = new System.Windows.Forms.Padding(3);
            this.tpSummaryReports.Size = new System.Drawing.Size(1169, 615);
            this.tpSummaryReports.TabIndex = 6;
            this.tpSummaryReports.Text = "Summary Reports";
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.btnExportToExcel.Location = new System.Drawing.Point(939, 553);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(200, 40);
            this.btnExportToExcel.TabIndex = 49;
            this.btnExportToExcel.Text = "Export To Excel";
            this.btnExportToExcel.UseVisualStyleBackColor = true;
            // 
            // btnReloadSummaryReports
            // 
            this.btnReloadSummaryReports.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReloadSummaryReports.BackgroundImage")));
            this.btnReloadSummaryReports.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReloadSummaryReports.Font = new System.Drawing.Font("Bahnschrift", 12.75F);
            this.btnReloadSummaryReports.Location = new System.Drawing.Point(1108, 10);
            this.btnReloadSummaryReports.Name = "btnReloadSummaryReports";
            this.btnReloadSummaryReports.Size = new System.Drawing.Size(52, 52);
            this.btnReloadSummaryReports.TabIndex = 48;
            this.btnReloadSummaryReports.UseVisualStyleBackColor = true;
            this.btnReloadSummaryReports.Click += new System.EventHandler(this.btnReloadSummaryReports_Click);
            // 
            // lstSummary
            // 
            this.lstSummary.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstSummary.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.lstSummary.FullRowSelect = true;
            this.lstSummary.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstSummary.HideSelection = false;
            this.lstSummary.Location = new System.Drawing.Point(19, 166);
            this.lstSummary.MultiSelect = false;
            this.lstSummary.Name = "lstSummary";
            this.lstSummary.Size = new System.Drawing.Size(1120, 371);
            this.lstSummary.TabIndex = 47;
            this.lstSummary.TileSize = new System.Drawing.Size(500, 30);
            this.lstSummary.UseCompatibleStateImageBehavior = false;
            this.lstSummary.View = System.Windows.Forms.View.Details;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbTable);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.dtpStart);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Bahnschrift", 10F);
            this.groupBox1.Location = new System.Drawing.Point(19, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(815, 65);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter by: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label3.Location = new System.Drawing.Point(554, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 22);
            this.label3.TabIndex = 48;
            this.label3.Text = "Category:";
            // 
            // cmbTable
            // 
            this.cmbTable.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.cmbTable.FormattingEnabled = true;
            this.cmbTable.Location = new System.Drawing.Point(626, 22);
            this.cmbTable.Name = "cmbTable";
            this.cmbTable.Size = new System.Drawing.Size(150, 29);
            this.cmbTable.TabIndex = 43;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label4.Location = new System.Drawing.Point(250, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 22);
            this.label4.TabIndex = 47;
            this.label4.Text = "-";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CalendarFont = new System.Drawing.Font("Bahnschrift Condensed", 12F);
            this.dtpEnd.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(272, 23);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(165, 28);
            this.dtpEnd.TabIndex = 46;
            // 
            // dtpStart
            // 
            this.dtpStart.CalendarFont = new System.Drawing.Font("Bahnschrift Condensed", 12F);
            this.dtpStart.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(79, 23);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(165, 28);
            this.dtpStart.TabIndex = 45;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label5.Location = new System.Drawing.Point(33, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 22);
            this.label5.TabIndex = 10;
            this.label5.Text = "Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(437, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(276, 39);
            this.label2.TabIndex = 26;
            this.label2.Text = "Summary Reports";
            // 
            // tpRevenue
            // 
            this.tpRevenue.BackColor = System.Drawing.Color.White;
            this.tpRevenue.Controls.Add(this.chartRevenue);
            this.tpRevenue.Controls.Add(this.lstRevenueDetails);
            this.tpRevenue.Controls.Add(this.btnRevenueFilter);
            this.tpRevenue.Controls.Add(this.groupBox2);
            this.tpRevenue.Controls.Add(this.lblRevenueTitle);
            this.tpRevenue.Controls.Add(this.btnReloadRevenueStatistics);
            this.tpRevenue.Location = new System.Drawing.Point(4, 34);
            this.tpRevenue.Name = "tpRevenue";
            this.tpRevenue.Padding = new System.Windows.Forms.Padding(3);
            this.tpRevenue.Size = new System.Drawing.Size(1169, 615);
            this.tpRevenue.TabIndex = 0;
            this.tpRevenue.Text = "Revenue Statistics";
            // 
            // chartRevenue
            // 
            chartArea1.Name = "ChartArea1";
            this.chartRevenue.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartRevenue.Legends.Add(legend1);
            this.chartRevenue.Location = new System.Drawing.Point(740, 177);
            this.chartRevenue.Name = "chartRevenue";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartRevenue.Series.Add(series1);
            this.chartRevenue.Size = new System.Drawing.Size(400, 350);
            this.chartRevenue.TabIndex = 47;
            this.chartRevenue.Text = "Revenue";
            // 
            // lstRevenueDetails
            // 
            this.lstRevenueDetails.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstRevenueDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstRevenueDetails.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.lstRevenueDetails.FullRowSelect = true;
            this.lstRevenueDetails.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstRevenueDetails.HideSelection = false;
            this.lstRevenueDetails.Location = new System.Drawing.Point(26, 177);
            this.lstRevenueDetails.MultiSelect = false;
            this.lstRevenueDetails.Name = "lstRevenueDetails";
            this.lstRevenueDetails.Size = new System.Drawing.Size(700, 352);
            this.lstRevenueDetails.TabIndex = 46;
            this.lstRevenueDetails.TileSize = new System.Drawing.Size(500, 30);
            this.lstRevenueDetails.UseCompatibleStateImageBehavior = false;
            this.lstRevenueDetails.View = System.Windows.Forms.View.Details;
            // 
            // btnRevenueFilter
            // 
            this.btnRevenueFilter.Font = new System.Drawing.Font("Bahnschrift", 13F);
            this.btnRevenueFilter.Location = new System.Drawing.Point(864, 96);
            this.btnRevenueFilter.Name = "btnRevenueFilter";
            this.btnRevenueFilter.Size = new System.Drawing.Size(150, 40);
            this.btnRevenueFilter.TabIndex = 45;
            this.btnRevenueFilter.Text = "Revenue Filter";
            this.btnRevenueFilter.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmbRevenueProductCategory);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.dtpRevenueEndDate);
            this.groupBox2.Controls.Add(this.dtpRevenueStartDate);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Font = new System.Drawing.Font("Bahnschrift", 10F);
            this.groupBox2.Location = new System.Drawing.Point(26, 81);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(815, 65);
            this.groupBox2.TabIndex = 42;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter by: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label1.Location = new System.Drawing.Point(554, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 22);
            this.label1.TabIndex = 48;
            this.label1.Text = "Category:";
            // 
            // cmbRevenueProductCategory
            // 
            this.cmbRevenueProductCategory.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.cmbRevenueProductCategory.FormattingEnabled = true;
            this.cmbRevenueProductCategory.Location = new System.Drawing.Point(626, 22);
            this.cmbRevenueProductCategory.Name = "cmbRevenueProductCategory";
            this.cmbRevenueProductCategory.Size = new System.Drawing.Size(150, 29);
            this.cmbRevenueProductCategory.TabIndex = 43;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label10.Location = new System.Drawing.Point(250, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 22);
            this.label10.TabIndex = 47;
            this.label10.Text = "-";
            // 
            // dtpRevenueEndDate
            // 
            this.dtpRevenueEndDate.CalendarFont = new System.Drawing.Font("Bahnschrift Condensed", 12F);
            this.dtpRevenueEndDate.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.dtpRevenueEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRevenueEndDate.Location = new System.Drawing.Point(272, 23);
            this.dtpRevenueEndDate.Name = "dtpRevenueEndDate";
            this.dtpRevenueEndDate.Size = new System.Drawing.Size(165, 28);
            this.dtpRevenueEndDate.TabIndex = 46;
            // 
            // dtpRevenueStartDate
            // 
            this.dtpRevenueStartDate.CalendarFont = new System.Drawing.Font("Bahnschrift Condensed", 12F);
            this.dtpRevenueStartDate.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.dtpRevenueStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRevenueStartDate.Location = new System.Drawing.Point(79, 23);
            this.dtpRevenueStartDate.Name = "dtpRevenueStartDate";
            this.dtpRevenueStartDate.Size = new System.Drawing.Size(165, 28);
            this.dtpRevenueStartDate.TabIndex = 45;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Bahnschrift Condensed", 13F);
            this.label9.Location = new System.Drawing.Point(33, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 22);
            this.label9.TabIndex = 10;
            this.label9.Text = "Date:";
            // 
            // lblRevenueTitle
            // 
            this.lblRevenueTitle.AutoSize = true;
            this.lblRevenueTitle.Font = new System.Drawing.Font("Bahnschrift", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevenueTitle.Location = new System.Drawing.Point(424, 19);
            this.lblRevenueTitle.Name = "lblRevenueTitle";
            this.lblRevenueTitle.Size = new System.Drawing.Size(281, 39);
            this.lblRevenueTitle.TabIndex = 25;
            this.lblRevenueTitle.Text = "Revenue Statistics";
            // 
            // btnReloadRevenueStatistics
            // 
            this.btnReloadRevenueStatistics.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReloadRevenueStatistics.BackgroundImage")));
            this.btnReloadRevenueStatistics.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReloadRevenueStatistics.Font = new System.Drawing.Font("Bahnschrift", 12.75F);
            this.btnReloadRevenueStatistics.Location = new System.Drawing.Point(1108, 10);
            this.btnReloadRevenueStatistics.Name = "btnReloadRevenueStatistics";
            this.btnReloadRevenueStatistics.Size = new System.Drawing.Size(52, 52);
            this.btnReloadRevenueStatistics.TabIndex = 24;
            this.btnReloadRevenueStatistics.UseVisualStyleBackColor = true;
            // 
            // tcStatistics
            // 
            this.tcStatistics.Controls.Add(this.tpRevenue);
            this.tcStatistics.Controls.Add(this.tpSummaryReports);
            this.tcStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcStatistics.Font = new System.Drawing.Font("Bahnschrift", 12.75F);
            this.tcStatistics.ItemSize = new System.Drawing.Size(150, 30);
            this.tcStatistics.Location = new System.Drawing.Point(0, 0);
            this.tcStatistics.Name = "tcStatistics";
            this.tcStatistics.SelectedIndex = 0;
            this.tcStatistics.Size = new System.Drawing.Size(1177, 653);
            this.tcStatistics.TabIndex = 1;
            // 
            // StatisticsManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tcStatistics);
            this.Name = "StatisticsManagement";
            this.Size = new System.Drawing.Size(1177, 653);
            this.tpSummaryReports.ResumeLayout(false);
            this.tpSummaryReports.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tpRevenue.ResumeLayout(false);
            this.tpRevenue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tcStatistics.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tpSummaryReports;
        private System.Windows.Forms.TabPage tpRevenue;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRevenue;
        private System.Windows.Forms.ListView lstRevenueDetails;
        private System.Windows.Forms.Button btnRevenueFilter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbRevenueProductCategory;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpRevenueEndDate;
        private System.Windows.Forms.DateTimePicker dtpRevenueStartDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblRevenueTitle;
        private System.Windows.Forms.Button btnReloadRevenueStatistics;
        private System.Windows.Forms.TabControl tcStatistics;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lstSummary;
        private System.Windows.Forms.Button btnReloadSummaryReports;
        private System.Windows.Forms.Button btnExportToExcel;
    }
}
