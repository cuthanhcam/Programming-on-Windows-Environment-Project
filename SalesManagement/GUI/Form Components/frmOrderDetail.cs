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
    public partial class frmOrderDetail : Form
    {
        private readonly int _orderID;
        private readonly OrderService _orderService;

        public frmOrderDetail(int orderID, OrderService orderService)
        {
            InitializeComponent();
            _orderID = orderID;
            _orderService = orderService;
            //LoadOrderDetails();
        }

        //private void LoadOrderDetails()
        //{
        //    // Lấy chi tiết đơn hàng từ OrderService
        //    var orderDetails = _orderService.GetOrderDetails(_orderID);

        //    // Hiển thị dữ liệu lên giao diện
        //    DisplayOrderDetails(orderDetails);
        //}

        //private void DisplayOrderDetails(List<OrderDetail> orderDetails)
        //{
        //    // Xóa dữ liệu cũ (nếu có)
        //    lstOrderDetails.Items.Clear();

        //    // Thêm dữ liệu mới
        //    foreach (var detail in orderDetails)
        //    {
        //        var item = new ListViewItem(detail.ProductID.ToString());
        //        item.SubItems.Add(detail.Product.Model); // Giả sử Product được include trong OrderDetail
        //        item.SubItems.Add(detail.Quantity.ToString());
        //        item.SubItems.Add(detail.Price.ToString("C"));
        //        item.SubItems.Add((detail.Quantity * detail.Price).ToString("C")); // Tính tổng tiền
        //        lstOrderDetails.Items.Add(item);
        //    }

        //    // Hiển thị tổng tiền đơn hàng
        //    decimal totalAmount = orderDetails.Sum(od => od.Quantity * od.Price);
        //    lblTotalAmount.Text = totalAmount.ToString("C");
        //}
    }
}
