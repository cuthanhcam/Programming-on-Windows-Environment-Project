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
    public partial class frmMain : Form
    {
        private readonly ProductService _productService;
        public frmMain()
        {
            InitializeComponent();
        }
        public frmMain(string role)
        {
            InitializeComponent();
            _productService = new ProductService(new SalesManagementContext()); // Khởi tạo ProductService
            InitializeTabPages(); // Gọi phương thức khởi tạo các tab

        }
        private void InitializeTabPages()
        {
            // Thêm UserControl vào TabPage sản phẩm
            var productManagement = new ProductManagement(_productService)
            {
                Dock = DockStyle.Fill,
            };
            tpProducts.Controls.Add(productManagement);
        }
    }
}
