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
        public frmMain()
        {
            InitializeComponent();
        }
        public frmMain(string role)
        {
            InitializeComponent();
            // Load form và xử lý sự kiện button
            btnProduct.Click += (s, e) => LoadUserControl(new ProductManagement());
            btnOrder.Click += (s, e) => LoadUserControl(new OrderManagement());
            btnCustomer.Click += (s, e) => LoadUserControl(new CustomerManagement());
            btnStock.Click += (s, e) => LoadUserControl(new StockManagement());
            btnStatistics.Click += (s, e) => LoadUserControl(new Statistics());
            btnEmployee.Click += (s, e) => LoadUserControl(new EmployeeManagement());
            btnLogout.Click += (s, e) => Application.Exit();
        }
        private void LoadUserControl(UserControl uc)
        {
            mainPanel.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(uc);
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ProductManagement());
        }
    }
}
