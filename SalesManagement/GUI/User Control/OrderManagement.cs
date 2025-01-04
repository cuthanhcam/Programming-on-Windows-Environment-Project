﻿using BUS;
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
        }

        // Load danh sách đơn hàng
        private void LoadOrderList(string searchOrderID = null, DateTime? searchOrderDateStart = null, DateTime? searchOrderDateEnd = null, string sortByTotalAmount = null)
        {
            try
            {
                var orders = _orderService.GetOrdersWithCustomerInfo(searchOrderID, searchOrderDateStart, searchOrderDateEnd, sortByTotalAmount);
                lstOrderList.Items.Clear();

                // Nhóm đơn hàng theo trạng thái
                var groupedOrders = orders
                    .GroupBy(o => o.Status)
                    .OrderBy(g => g.Key); // Sắp xếp theo thứ tự Pending, Completed, Canceled

                foreach (var group in groupedOrders)
                {
                    // Thêm tiêu đề nhóm
                    var groupHeader = new ListViewItem($"Status: {group.Key}");
                    groupHeader.Font = new Font(lstOrderList.Font, FontStyle.Bold);
                    groupHeader.BackColor = Color.LightGray;
                    lstOrderList.Items.Add(groupHeader);

                    // Thêm các đơn hàng trong nhóm
                    foreach (var order in group)
                    {
                        var item = new ListViewItem(order.OrderID.ToString());
                        item.SubItems.Add(order.CustomerID.ToString());
                        item.SubItems.Add(order.EmployeeID?.ToString() ?? "N/A");
                        item.SubItems.Add(order.OrderDate.ToString("dd/MM/yyyy"));
                        item.SubItems.Add(order.TotalAmount.ToString("C"));
                        item.SubItems.Add(order.Status);
                        item.SubItems.Add(order.Note ?? "N/A");
                        lstOrderList.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading order list: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load danh sách sản phẩm
        private void LoadProducts()
        {
            var products = _productService.GetAllProducts();
            lstProduct.Items.Clear();
            foreach (var product in products)
            {
                var item = new ListViewItem(product.ProductID.ToString());
                item.SubItems.Add(product.Model);
                item.SubItems.Add(product.Price.ToString("C"));
                item.SubItems.Add(product.StockQuantity.ToString());
                lstProduct.Items.Add(item);
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
                    _orderService.UpdateOrderStatus(orderID, "Completed");
                    LoadOrderList();
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


        private void txtOrderID_TextChanged(object sender, EventArgs e)
        {
            LoadOrderList(txtOrderID.Text, dtpOrderDateStart.Value, dtpOrderDateEnd.Value, cmbTotalAmount.SelectedItem?.ToString());
        }

        private void cmbTotalAmount_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadOrderList(txtOrderID.Text, dtpOrderDateStart.Value, dtpOrderDateEnd.Value, cmbTotalAmount.SelectedItem?.ToString());
        }


        private void txtOrderID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoadOrderList(txtOrderID.Text, dtpOrderDateStart.Value, dtpOrderDateEnd.Value, cmbTotalAmount.SelectedItem?.ToString());
                e.Handled = true; // Ngăn phát ra tiếng
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

        private void dtpOrderDateStart_ValueChanged(object sender, EventArgs e)
        {
            LoadOrderList(txtOrderID.Text, dtpOrderDateStart.Value, dtpOrderDateEnd.Value, cmbTotalAmount.SelectedItem?.ToString());
        }

        private void dtpOrderDateEnd_ValueChanged(object sender, EventArgs e)
        {
            LoadOrderList(txtOrderID.Text, dtpOrderDateStart.Value, dtpOrderDateEnd.Value, cmbTotalAmount.SelectedItem?.ToString());
        }
    }
}
