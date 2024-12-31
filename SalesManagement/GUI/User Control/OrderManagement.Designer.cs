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
            this.tcOrder = new System.Windows.Forms.TabControl();
            this.tpCreateOrder = new System.Windows.Forms.TabPage();
            this.tpOrderDetails = new System.Windows.Forms.TabPage();
            this.tcOrder.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcOrder
            // 
            this.tcOrder.Controls.Add(this.tpCreateOrder);
            this.tcOrder.Controls.Add(this.tpOrderDetails);
            this.tcOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcOrder.ItemSize = new System.Drawing.Size(150, 30);
            this.tcOrder.Location = new System.Drawing.Point(0, 0);
            this.tcOrder.Name = "tcOrder";
            this.tcOrder.SelectedIndex = 0;
            this.tcOrder.Size = new System.Drawing.Size(1177, 653);
            this.tcOrder.TabIndex = 0;
            // 
            // tpCreateOrder
            // 
            this.tpCreateOrder.Location = new System.Drawing.Point(4, 34);
            this.tpCreateOrder.Name = "tpCreateOrder";
            this.tpCreateOrder.Padding = new System.Windows.Forms.Padding(3);
            this.tpCreateOrder.Size = new System.Drawing.Size(1169, 615);
            this.tpCreateOrder.TabIndex = 0;
            this.tpCreateOrder.Text = "Create Order";
            this.tpCreateOrder.UseVisualStyleBackColor = true;
            // 
            // tpOrderDetails
            // 
            this.tpOrderDetails.Location = new System.Drawing.Point(4, 34);
            this.tpOrderDetails.Name = "tpOrderDetails";
            this.tpOrderDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tpOrderDetails.Size = new System.Drawing.Size(1169, 615);
            this.tpOrderDetails.TabIndex = 1;
            this.tpOrderDetails.Text = "Order Details";
            this.tpOrderDetails.UseVisualStyleBackColor = true;
            // 
            // OrderManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tcOrder);
            this.Name = "OrderManagement";
            this.Size = new System.Drawing.Size(1177, 653);
            this.tcOrder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcOrder;
        private System.Windows.Forms.TabPage tpCreateOrder;
        private System.Windows.Forms.TabPage tpOrderDetails;
    }
}
