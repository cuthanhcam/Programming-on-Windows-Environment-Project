using BUS;
using DAL.Entities;
using GUI.Form_Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class OrderManagement : UserControl
    {
        private readonly OrderService _orderService;
        private readonly CustomerService _customerService;
        private readonly ProductService _productService;

        private List<Order> _orders;
        private List<Product> _addProducts;
        public OrderManagement(OrderService orderService, CustomerService customerService, ProductService productService)
        {
            InitializeComponent();
            _orderService = orderService;
            InitializeListViewColumns();
            LoadOrderList();
        }

        private void InitializeListViewColumns()
        {
            lstOrderList.Columns.Clear();
            lstOrderList.Columns.Add("Order ID", 100);
            lstOrderList.Columns.Add("Customer ID", 120);
            lstOrderList.Columns.Add("Employee ID", 120);
            lstOrderList.Columns.Add("Order Date", 170);
            lstOrderList.Columns.Add("Total Amount", 120);
            lstOrderList.Columns.Add("Status", 100);
            lstOrderList.Columns.Add("Note", 220);

            lstOrderList.ShowGroups = true;
            lstOrderList.View = View.Details;

            // Khởi tạo cmbTotalAmount
            cmbTotalAmount.Items.Add("All");
            cmbTotalAmount.Items.Add("Ascending");
            cmbTotalAmount.Items.Add("Descending");
            cmbTotalAmount.SelectedIndex = 0;
        }

        // Load danh sách đơn hàng
        private void LoadOrderList(string searchOrderID = null, DateTime? searchOrderDateStart = null, DateTime? searchOrderDateEnd = null, string sortByTotalAmount = null)
        {
            try
            {
                var orders = _orderService.GetOrdersWithCustomerInfo(searchOrderID, searchOrderDateStart, searchOrderDateEnd, sortByTotalAmount);
                lstOrderList.Items.Clear();
                lstOrderList.Groups.Clear();

                // Nhóm đơn hàng theo trạng thái
                var groupedOrders = orders
                    .GroupBy(o => o.Status)
                    .OrderBy(g => g.Key); // Sắp xếp theo thứ tự Pending, Completed, Canceled

                foreach (var group in groupedOrders)
                {
                    // Tạo nhóm mới
                    var groupHeader = new ListViewGroup($"Status: {group.Key}", HorizontalAlignment.Left);
                    lstOrderList.Groups.Add(groupHeader);

                    // Thêm các đơn hàng vào nhóm
                    foreach (var order in group)
                    {
                        var item = new ListViewItem(order.OrderID.ToString());
                        item.SubItems.Add(order.CustomerID.ToString());
                        item.SubItems.Add(order.EmployeeID?.ToString() ?? "N/A");
                        item.SubItems.Add(order.OrderDate.ToString("dd/MM/yyyy")); // "dd/MM/yyyy"
                        item.SubItems.Add(order.TotalAmount.ToString("C"));
                        item.SubItems.Add(order.Status);
                        item.SubItems.Add(order.Note ?? "N/A");
                        item.Group = groupHeader; // Gán đơn hàng vào nhóm
                        lstOrderList.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading order list: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (lstOrderList.SelectedItems.Count > 0)
            {
                int orderID = int.Parse(lstOrderList.SelectedItems[0].Text);
                string currentStatus = lstOrderList.SelectedItems[0].SubItems[5].Text;

                if (currentStatus == "Pending")
                {
                    try
                    {
                        _orderService.UpdateOrderStatus(orderID, "Completed");
                        LoadOrderList();
                        MessageBox.Show("Order completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error completing order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Only orders with status 'Pending' can be completed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (lstOrderList.SelectedItems.Count > 0)
            {
                int orderID = int.Parse(lstOrderList.SelectedItems[0].Text);
                string currentStatus = lstOrderList.SelectedItems[0].SubItems[5].Text;

                if (currentStatus == "Pending")
                {
                    _orderService.UpdateOrderStatus(orderID, "Canceled");
                    LoadOrderList();
                }
                else
                {
                    MessageBox.Show("Only orders with status 'Pending' can be canceled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnOrderDetail_Click(object sender, EventArgs e)
        {
            if (lstOrderList.SelectedItems.Count > 0)
            {
                int orderID = int.Parse(lstOrderList.SelectedItems[0].Text);
                var orderDetailsForm = new frmOrderDetail(orderID, _orderService);
                orderDetailsForm.ShowDialog();
            }
        }

        private void lstOrderList_DoubleClick(object sender, EventArgs e)
        {
            if (lstOrderList.SelectedItems.Count > 0)
            {
                int orderID = int.Parse(lstOrderList.SelectedItems[0].Text);
                var orderDetailsForm = new frmOrderDetail(orderID, _orderService);
                orderDetailsForm.ShowDialog();
            }
        }

        private void txtOrderID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoadOrderList(txtOrderID.Text, dtpOrderDateStart.Value, dtpOrderDateEnd.Value, cmbTotalAmount.SelectedItem?.ToString());
                e.Handled = true;
            }
        }

        private void cmbTotalAmount_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadOrderList(txtOrderID.Text, dtpOrderDateStart.Value, dtpOrderDateEnd.Value, cmbTotalAmount.SelectedItem?.ToString());
        }

        private void dtpOrderDateStart_ValueChanged(object sender, EventArgs e)
        {
            if (dtpOrderDateStart.Value > dtpOrderDateEnd.Value)
            {
                MessageBox.Show("Start date cannot be greater than end date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LoadOrderList(txtOrderID.Text, dtpOrderDateStart.Value, dtpOrderDateEnd.Value, cmbTotalAmount.SelectedItem?.ToString());
        }

        private void dtpOrderDateEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dtpOrderDateEnd.Value < dtpOrderDateStart.Value)
            {
                MessageBox.Show("End date cannot be less than start date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LoadOrderList(txtOrderID.Text, dtpOrderDateStart.Value, dtpOrderDateEnd.Value, cmbTotalAmount.SelectedItem?.ToString());
        }
    }
}
