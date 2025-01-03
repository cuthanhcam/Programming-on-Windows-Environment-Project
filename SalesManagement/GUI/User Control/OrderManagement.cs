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

namespace GUI
{
    public partial class OrderManagement : UserControl
    {
        private readonly OrderService _orderService;
        private readonly ProductService _productService;
        private readonly CustomerService _customerService;
        private List<Order> _orders;
        private List<Product> _addProducts;
        public OrderManagement(OrderService orderService)
        {
            InitializeComponent();
            _orderService = orderService;
            InitializeListViewColumns();
        }

        private void InitializeListViewColumns()
        {
            // Tạo cột cho lstProduct
            lstProduct.Columns.Clear();
            lstProduct.Columns.Add("ID", 50);
            lstProduct.Columns.Add("Model", 250);
            lstProduct.Columns.Add("Price", 100);
            lstProduct.Columns.Add("Quantity", 100);
            lstProduct.ShowGroups = true;

            // Tạo cột cho lstSelectedProduct
            lstSelectedProduct.Columns.Clear();
            lstSelectedProduct.Columns.Add("ID", 50);
            lstSelectedProduct.Columns.Add("Model", 230);
            lstSelectedProduct.Columns.Add("Price", 100);
            lstSelectedProduct.Columns.Add("Quantity", 70);
            lstSelectedProduct.Columns.Add("Total", 100);
        }

        private void LoadProduct(List<Product> products)
        {

        }
    }
}
