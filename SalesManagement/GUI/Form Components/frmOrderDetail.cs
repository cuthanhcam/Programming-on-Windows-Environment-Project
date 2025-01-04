using BUS;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
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

            lstOrderDetail.View = View.Details;
            lstOrderDetail.FullRowSelect = true;
            lstOrderDetail.OwnerDraw = true;
            lstOrderDetail.SmallImageList = new ImageList();
            lstOrderDetail.SmallImageList.ImageSize = new Size(1, 50);

            // Ngăn chọn item
            lstOrderDetail.ItemSelectionChanged += LstOrderDetail_ItemSelectionChanged;

            lstOrderDetail.DrawItem += LstOrderDetail_DrawItem;
            lstOrderDetail.DrawSubItem += LstOrderDetail_DrawSubItem;
            lstOrderDetail.DrawColumnHeader += LstOrderDetail_DrawColumnHeader;
        }

        private void LoadOrderDetails()
        {
            try
            {
                var order = _orderService.GetOrderDetails(_orderID);
                if (order != null)
                {
                    lblOrderID.Text = order.OrderID.ToString();
                    lblEmployeeID.Text = order.EmployeeID?.ToString() ?? "N/A";
                    lblOrderDate.Text = order.OrderDate.ToString("dd/MM/yyyy");
                    lblTotalAmount.Text = order.TotalAmount.ToString("C");
                    lblDiscount.Text = order.Discount.ToString("C");

                    var customer = _orderService.GetCustomerByOrderID(order.OrderID);
                    if (customer != null)
                    {
                        lblName.Text = customer.Name;
                        lblEmail.Text = customer.Email ?? "N/A";
                        lblPhone.Text = customer.Phone ?? "N/A";
                        lblAddress.Text = customer.Address ?? "N/A";
                        lblMembershipLevel.Text = customer.MembershipLevel ?? "N/A";
                    }

                    decimal discountRate = GetDiscountRate(customer?.MembershipLevel);
                    decimal discountAmount = order.TotalAmount * discountRate;
                    decimal totalAmountPayable = order.TotalAmount - discountAmount;

                    lblDiscount.Text = $"{discountAmount.ToString("C")} ({(discountRate * 100):0}%)";
                    lblTotalAmountPayable.Text = totalAmountPayable.ToString("C");

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

        // Ngăn chặn chọn item
        private void LstOrderDetail_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            e.Item.Selected = false;  // Bỏ chọn ngay lập tức
        }

        private void LstOrderDetail_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void LstOrderDetail_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void LstOrderDetail_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.ColumnIndex == 1)  // Cột "Model"
            {
                string text = e.SubItem.Text;
                Rectangle rect = e.Bounds;

                e.Graphics.DrawString(
                    text,
                    lstOrderDetail.Font,
                    Brushes.Black,
                    rect
                );
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private decimal GetDiscountRate(string membershipLevel)
        {
            switch (membershipLevel?.ToLower())
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
