using BUS;
using DAL.Entities;
using GUI.User_Control;
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
        private readonly OrderService _orderService;
        private readonly CustomerService _customerService;
        private readonly StockService _stockService;
        private readonly StatisticsService _statisticsService;
        private readonly EmployeeService _employeeService;
        private string _username;
        private string _role;

        public frmMain(string role, string username)
        {
            InitializeComponent();
            _username = username;
            _role = role;

            _productService = new ProductService(new SalesManagementContext());
            _orderService = new OrderService(new SalesManagementContext());
            _customerService = new CustomerService(new SalesManagementContext());
            _stockService = new StockService(new SalesManagementContext());
            _statisticsService = new StatisticsService(new SalesManagementContext());
            _employeeService = new EmployeeService(new SalesManagementContext());

            InitializeTabPages();
            DisplayUserInfo();
        }

        private void DisplayUserInfo()
        {
            lblUser.Text = _username;
            lblRole.Text = _role;
        }

        private void InitializeTabPages()
        {
            AddUserControlToTab(tpProducts, new ProductManagement(_productService));
            AddUserControlToTab(tpOrders, new OrderManagement(_orderService, _customerService, _productService ));
            AddUserControlToTab(tpCustomers, new CustomerManagement(_customerService));
            AddUserControlToTab(tpStock, new StockManagement(_stockService));
            AddUserControlToTab(tpStatistics, new StatisticsManagement(_statisticsService));
            //AddUserControlToTab(tpEmployees, new EmployeeManagement(_employeeService);

        }
        private void AddUserControlToTab(TabPage tabPage, UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            tabPage.Controls.Add(userControl);
        }

        private void btnProductsManagement_Click(object sender, EventArgs e)
        {
            tcMain.SelectedIndex = 0;
            //tcMain.SelectedTab = tpProducts;
        }

        private void btnOrdersManagement_Click(object sender, EventArgs e)
        {
            tcMain.SelectedIndex = 1;
            //tcMain.SelectedTab = tpOrders;
        }

        private void btnCustomersManagement_Click(object sender, EventArgs e)
        {
            tcMain.SelectedIndex = 2;
            //tcMain.SelectedTab = tpCustomers;
        }

        private void btnStockManagement_Click(object sender, EventArgs e)
        {
            tcMain.SelectedIndex = 3;
            //tcMain.SelectedTab = tpStock;
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            tcMain.SelectedIndex = 4;
            //tcMain.SelectedTab = tpStatistics;
        }

        private void btnEmployeesManagement_Click(object sender, EventArgs e)
        {
            tcMain.SelectedIndex = 5;
            //tcMain.SelectedTab = tpEmployees;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin loginForm = new frmLogin();
            loginForm.ShowDialog();
            this.Close();
        }
    }
}
