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
            InitializeListViewColumnsCreateNewOrder();
        }

        private void InitializeListViewColumnsCreateNewOrder()
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

        // Load danh sách đơn hàng
        private void LoadOrderList()
        {
            var orders = _orderService.GetPendingOrders();
            lstOrderList.Items.Clear();
            foreach (var order in orders)
            {
                var item = new ListViewItem(order.OrderID.ToString());
                item.SubItems.Add(order.CustomerID.ToString());
                item.SubItems.Add(order.OrderDate.ToString("dd/MM/yyyy"));
                item.SubItems.Add(order.TotalAmount.ToString("C"));
                item.SubItems.Add(order.Status);
                lstOrderList.Items.Add(item);
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
        // Tìm kiếm khách hàng bằng số điện thoại
        private void SearchCustomerByPhone(string phone)
        {
            var customer = _customerService.GetCustomerByPhone(phone);
            if (customer != null)
            {
                txtName.Text = customer.Name;
                txtEmail.Text = customer.Email;
                txtMembershipLevel.Text = customer.MembershipLevel;
                lblAddress.Text = customer.Address;
                btnAddNewCustomer.Visible = false;
            }
            else
            {
                ClearCustomerFields();
                btnAddNewCustomer.Visible = true;
            }
        }

        // Xóa thông tin khách hàng
        private void ClearCustomerFields()
        {
            txtName.Clear();
            txtEmail.Clear();
            txtMembershipLevel.Clear();
            txtAddress.Clear();
        }

        // Thêm khách hàng mới
        private void AddNewCustomer()
        {
            var customer = new Customer
            {
                Name = txtName.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text,
                Address = lblAddress.Text,
                MembershipLevel = txtMembershipLevel.Text
            };
            _customerService.AddCustomer(customer);
            MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Thêm sản phẩm vào danh sách đã chọn
        private void AddProductToSelectedList()
        {
            if (lstProduct.SelectedItems.Count > 0)
            {
                var selectedProduct = lstProduct.SelectedItems[0];
                int productID = int.Parse(selectedProduct.SubItems[0].Text);
                string model = selectedProduct.SubItems[1].Text;
                decimal price = decimal.Parse(selectedProduct.SubItems[2].Text.Replace("$", ""));
                int quantity = (int)nudQuantity.Value;

                var item = new ListViewItem(productID.ToString());
                item.SubItems.Add(model);
                item.SubItems.Add(price.ToString("C"));
                item.SubItems.Add(quantity.ToString());
                item.SubItems.Add((price * quantity).ToString("C"));
                lstSelectedProduct.Items.Add(item);
            }
        }

        // Xóa sản phẩm khỏi danh sách đã chọn
        private void DeleteSelectedProduct()
        {
            if (lstSelectedProduct.SelectedItems.Count > 0)
            {
                lstSelectedProduct.Items.Remove(lstSelectedProduct.SelectedItems[0]);
            }
        }

        // Tạo đơn hàng mới
        private void CreateOrder()
        {
            if (lstSelectedProduct.Items.Count == 0)
            {
                MessageBox.Show("Please add products to the order.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var order = new Order
            {
                CustomerID = _customerService.GetCustomerByPhone(txtPhone.Text).CustomerID,
                OrderDate = DateTime.Now,
                TotalAmount = lstSelectedProduct.Items.Cast<ListViewItem>().Sum(item => decimal.Parse(item.SubItems[4].Text.Replace("$", ""))),
                Status = "Pending"
            };

            var orderDetails = lstSelectedProduct.Items.Cast<ListViewItem>().Select(item => new OrderDetail
            {
                ProductID = int.Parse(item.SubItems[0].Text),
                Quantity = int.Parse(item.SubItems[3].Text),
                Price = decimal.Parse(item.SubItems[4].Text.Replace("$", ""))
            }).ToList();

            _orderService.CreateOrder(order, orderDetails);
            MessageBox.Show("Order created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearOrderFields();
        }

        // Xóa thông tin đơn hàng
        private void ClearOrderFields()
        {
            lstSelectedProduct.Items.Clear();
            txtPhone.Clear();
            ClearCustomerFields();
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (lstOrderList.SelectedItems.Count > 0)
            {
                int orderID = int.Parse(lstOrderList.SelectedItems[0].Text);
                _orderService.UpdateOrderStatus(orderID, "Completed");
                LoadOrderList();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (lstOrderList.SelectedItems.Count > 0)
            {
                int orderID = int.Parse(lstOrderList.SelectedItems[0].Text);
                _orderService.UpdateOrderStatus(orderID, "Canceled");
                LoadOrderList();
            }
        }

        private void btnOrderDetail_Click(object sender, EventArgs e)
        {
            if (lstOrderList.SelectedItems.Count > 0)
            {
                int orderID = int.Parse(lstOrderList.SelectedItems[0].Text);
                var orderDetailsForm = new OrderDetailsForm(orderID, _orderService);
                orderDetailsForm.ShowDialog();
            }
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            SearchCustomerByPhone(txtPhone.Text);
        }

        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            AddNewCustomer();
        }

        private void btnAddUpdate_Click(object sender, EventArgs e)
        {
            AddProductToSelectedList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectedProduct();
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            CreateOrder();
        }
    }
}
