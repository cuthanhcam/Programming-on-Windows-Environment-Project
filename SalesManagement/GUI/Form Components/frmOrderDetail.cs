using BUS;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Form_Components
{
    public partial class frmOrderDetail : Form
    {
        private readonly int _orderID;
        private readonly OrderService _orderService;
        
        public frmOrderDetail(int orderID, OrderService orderService)
        {
            InitializeComponent();
            _orderID = orderID;
            _orderService = orderService;

            LoadOrderDetails();
            InitializeListViewColumns();
        }

        private void InitializeListViewColumns()
        {
            lstOrderDetail.Columns.Clear();
            lstOrderDetail.Columns.Add("Product ID", 100);
            lstOrderDetail.Columns.Add("Model", 270);
            lstOrderDetail.Columns.Add("Quantity", 100);
            lstOrderDetail.Columns.Add("Unit Price", 100);
            lstOrderDetail.Columns.Add("Total Price", 100);

            lstOrderDetail.View = View.Details; // Đảm bảo hiển thị chi tiết
            lstOrderDetail.FullRowSelect = true; // Chọn toàn bộ dòng
        }

        private void LoadOrderDetails()
        {
            try
            {
                var order = _orderService.GetOrderDetails(_orderID);
                if (order != null)
                {
                    // Hiển thị thông tin đơn hàng
                    lblOrderID.Text = order.OrderID.ToString();
                    lblEmployeeID.Text = order.EmployeeID?.ToString() ?? "N/A";
                    lblOrderDate.Text = order.OrderDate.ToString("dd/MM/yyyy");
                    lblTotalAmount.Text = order.TotalAmount.ToString("C");
                    lblDiscount.Text = order.Discount.ToString("C");

                    // Hiển thị thông tin khách hàng
                    var customer = _orderService.GetCustomerByOrderID(order.OrderID);
                    if (customer != null)
                    {
                        lblName.Text = customer.Name;
                        lblEmail.Text = customer.Email ?? "N/A";
                        lblPhone.Text = customer.Phone ?? "N/A";
                        lblAddress.Text = customer.Address ?? "N/A";
                        lblMembershipLevel.Text = customer.MembershipLevel ?? "N/A";
                    }

                    // Tính toán tổng tiền phải trả
                    decimal discountRate = GetDiscountRate(customer?.MembershipLevel);
                    decimal discountAmount = order.TotalAmount * discountRate;
                    decimal totalAmountPayable = order.TotalAmount - discountAmount;

                    // Hiển thị giá trị giảm giá và phần trăm giảm giá
                    lblDiscount.Text = $"{discountAmount.ToString("C")} ({(discountRate * 100):0}%)";
                    lblTotalAmountPayable.Text = totalAmountPayable.ToString("C");

                    // Hiển thị chi tiết đơn hàng
                    lstOrderDetail.Items.Clear();
                    lstOrderDetail.Groups.Clear();

                    foreach (var detail in order.OrderDetails)
                    {
                        var item = new ListViewItem(detail.ProductID.ToString());
                        item.SubItems.Add(detail.Product.Model);
                        item.SubItems.Add(detail.Quantity.ToString());
                        item.SubItems.Add(detail.UnitPrice.ToString("C"));
                        item.SubItems.Add(detail.Price.ToString("C"));

                        lstOrderDetail.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading order details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal GetDiscountRate(string membershipLevel)
        {
            switch (membershipLevel.ToLower())
            {
                case "silver":
                    return 0m;
                case "gold":
                    return 0.05m;
                case "platinum":
                    return 0.10m;
                default:
                    return 0m;
            }
        }
    }
}
