using BUS;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Form_Components
{
    public partial class frmPurchaseHistory : Form
    {
        private readonly List<Order> _purchaseHistory;
        private readonly OrderService _orderService;

        public frmPurchaseHistory(List<Order> purchaseHistory, OrderService orderService)
        {
            InitializeComponent();
            _purchaseHistory = purchaseHistory;
            _orderService = orderService;
            InitializeListViewColumns();
            LoadPurchaseHistory();
            
        }

        private void InitializeListViewColumns()
        {
            lstPurchaseHistory.Columns.Clear();
            lstPurchaseHistory.Columns.Add("OrderID", 100);
            lstPurchaseHistory.Columns.Add("OrderDate", 150);
            lstPurchaseHistory.Columns.Add("TotalAmount", 120);
            lstPurchaseHistory.Columns.Add("Status", 100);

            lstPurchaseHistory.View = View.Details;
        }

        private void LoadPurchaseHistory()
        {
            lstPurchaseHistory.Items.Clear();
            lstPurchaseHistory.Groups.Clear();
            foreach (var order in _purchaseHistory)
            {
                var item = new ListViewItem(order.OrderID.ToString());
                item.SubItems.Add(order.OrderDate.ToString("dd/MM/yyyy"));
                item.SubItems.Add(order.TotalAmount.ToString("C"));
                item.SubItems.Add(order.Status);

                lstPurchaseHistory.Items.Add(item);
            }
        }

        private void frmPurchaseHistory_FormClosing(object sender, FormClosingEventArgs e)
        {
            //var result = MessageBox.Show("Are you sure you want to close this window?", "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (result == DialogResult.No)
            //{
            //    e.Cancel = true; // Hủy sự kiện đóng form
            //}
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstPurchaseHistory_DoubleClick(object sender, EventArgs e)
        {
            if (lstPurchaseHistory.SelectedItems.Count > 0)
            {
                int orderID = int.Parse(lstPurchaseHistory.SelectedItems[0].Text);

                try
                {
                    var orderDetailForm = new frmOrderDetail(orderID, _orderService);
                    orderDetailForm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading order details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
