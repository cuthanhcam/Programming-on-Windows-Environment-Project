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
        private readonly int _employeeID;
        private List<Order> _orders;
        private List<Product> _addProducts;
        
        public OrderManagement(OrderService orderService, CustomerService customerService, ProductService productService, int employeeID)
        {
            InitializeComponent();
            _orderService = orderService;
            _customerService = customerService;
            _productService = productService;
            _employeeID = employeeID;
            InitializeListViewColumns();
            LoadOrderList();
            LoadProductList();
        }

        
        private void InitializeListViewColumns()
        {
            // lstOrderList
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

            // lstProduct
            lstProduct.Columns.Clear();
            lstProduct.Columns.Add("Product ID", 100);
            lstProduct.Columns.Add("Model", 250);
            lstProduct.Columns.Add("Quantity", 80);
            lstProduct.Columns.Add("Price", 100);

            lstProduct.ShowGroups = true;
            lstProduct.View = View.Details;

            // lstSelectedProduct
            lstSelectedProduct.Columns.Clear();
            lstSelectedProduct.Columns.Add("ID", 70);
            lstSelectedProduct.Columns.Add("Model", 200);
            lstSelectedProduct.Columns.Add("Quantity", 100);
            lstSelectedProduct.Columns.Add("Unit Price", 100);
            lstSelectedProduct.Columns.Add("Price", 100);

            lstSelectedProduct.ShowGroups = false;
            lstSelectedProduct.View = View.Details;

            // Khởi tạo cmbTotalAmount
            cmbTotalAmount.Items.Add("All");
            cmbTotalAmount.Items.Add("Ascending");
            cmbTotalAmount.Items.Add("Descending");
            cmbTotalAmount.SelectedIndex = 0;
        }

        #region tpOrderList
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

                        switch (order.Status)
                        {
                            case "Canceled":
                                item.ForeColor = Color.Red;
                                break;
                            case "Completed":
                                item.ForeColor = Color.Green;
                                break;
                            default:
                                item.ForeColor = SystemColors.WindowText;
                                break;
                        }

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

        private bool _isProductListLoaded = false;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (lstOrderList.SelectedItems.Count > 0)
            {
                int orderID = int.Parse(lstOrderList.SelectedItems[0].Text);
                string currentStatus = lstOrderList.SelectedItems[0].SubItems[5].Text;

                if (currentStatus == "Pending")
                {
                    try
                    {
                        _orderService.UpdateOrderStatus(orderID, "Canceled");
                        LoadOrderList(); // Cập nhật danh sách đơn hàng

                        if (!_isProductListLoaded)
                        {
                            LoadProductList(); // Cập nhật lại danh sách sản phẩm
                            _isProductListLoaded = true;
                        }

                        MessageBox.Show("Order canceled successfully and product list reloaded!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error canceling order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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

        private void btnReloadOrderList_Click(object sender, EventArgs e)
        {
            txtOrderID.Clear();
            rtbNote.Clear();
            dtpOrderDateStart.Value = DateTime.Today;
            dtpOrderDateEnd.Value = DateTime.Today; 
            cmbTotalAmount.SelectedIndex = 0;
            LoadOrderList();
        }

        private void lstOrderList_Click(object sender, EventArgs e)
        {
            if (lstOrderList.SelectedItems.Count > 0)
            {
                // Lấy OrderID từ dòng được chọn
                int orderID = int.Parse(lstOrderList.SelectedItems[0].Text);

                // Lấy thông tin đơn hàng từ OrderService
                var order = _orderService.GetOrderDetails(orderID);

                // Hiển thị Note trong rtbNote
                if (order != null)
                {
                    rtbNote.Text = order.Note ?? string.Empty;
                }
                else
                {
                    rtbNote.Text = string.Empty;
                }
            }
        }

        private void btnSaveNote_Click(object sender, EventArgs e)
        {
            if (lstOrderList.SelectedItems.Count > 0)
            {
                // Lấy OrderID từ dòng được chọn
                int orderID = int.Parse(lstOrderList.SelectedItems[0].Text);

                // Lấy Note mới từ rtbNote
                string newNote = rtbNote.Text;

                try
                {
                    // Cập nhật Note trong cơ sở dữ liệu
                    _orderService.UpdateOrderNote(orderID, newNote);

                    // Hiển thị thông báo thành công
                    MessageBox.Show("Note updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Làm mới danh sách đơn hàng để hiển thị thay đổi
                    LoadOrderList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating note: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select an order to update the note.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region tpCreateOrder
        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                var customer = _customerService.GetCustomerByPhone(txtPhone.Text);
                if (customer != null)
                {
                    // Nếu tìm thấy khách hàng, hiển thị thông tin và vô hiệu hóa nút thêm mới
                    txtCustomerID.Text = customer.CustomerID.ToString();
                    txtName.Text = customer.Name;
                    txtEmail.Text = customer.Email;
                    txtMembershipLevel.Text = customer.MembershipLevel;
                    txtAddress.Text = customer.Address;
                    btnAddNewCustomer.Enabled = false;
                }
                else
                {
                    // Nếu không tìm thấy khách hàng, hiển thị thông báo và kích hoạt nút thêm mới
                    MessageBox.Show("Customer not found. Please add a new customer.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnAddNewCustomer.Enabled = true;

                    // Đặt các ô về trống
                    txtCustomerID.Text = string.Empty;
                    txtName.Text = string.Empty;
                    txtEmail.Text = string.Empty;
                    txtAddress.Text = string.Empty;

                    // Gán giá trị mặc định "Silver" cho txtMembershipLevel
                    txtMembershipLevel.Text = "Silver";
                }
            }
        }

        // Hiển thị danh sách sản phẩm
        private void LoadProductList(string productID = null)
        {
            try
            {
                _productService.RefreshContext();

                // Lấy danh sách sản phẩm từ CSDL
                var products = _productService.GetProducts(productID);
                lstProduct.Items.Clear();
                lstProduct.Groups.Clear();

                var categoryOrder = new List<string>
                {
                    "Processor", "Motherboard", "CPU Cooler", "Case", "Graphic Card", "RAM", "Storage", "Case Cooler", "Power Supply"
                };

                // Nhóm sản phẩm theo Category
                var groupedProducts = products
                    .GroupBy(p => p.Category)
                    .OrderBy(g => categoryOrder.IndexOf(g.Key));

                foreach (var group in groupedProducts)
                {
                    // Tạo nhóm mới
                    var groupHeader = new ListViewGroup($"Category: {group.Key}", HorizontalAlignment.Left);
                    lstProduct.Groups.Add(groupHeader);

                    // Thêm các sản phẩm vào nhóm
                    foreach (var product in group)
                    {
                        var item = new ListViewItem(product.ProductID.ToString());
                        item.SubItems.Add(product.Model);
                        item.SubItems.Add(product.StockQuantity.ToString()); // Hiển thị số lượng tồn kho từ CSDL
                        item.SubItems.Add(product.Price.ToString("C"));
                        item.Group = groupHeader; // Gán sản phẩm vào nhóm

                        lstProduct.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading product list: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtProductID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoadProductList(txtProductID.Text);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lstProduct.SelectedItems.Count > 0 && nudQuantity.Value > 0)
            {
                var selectedProduct = lstProduct.SelectedItems[0];
                int productID = int.Parse(selectedProduct.Text);
                string model = selectedProduct.SubItems[1].Text;
                int stockQuantity = int.Parse(selectedProduct.SubItems[2].Text); // Lấy số lượng tồn kho
                decimal unitPrice = decimal.Parse(selectedProduct.SubItems[3].Text, System.Globalization.NumberStyles.Currency);
                int quantity = (int)nudQuantity.Value;

                // Kiểm tra số lượng tồn kho
                if (stockQuantity == 0)
                {
                    MessageBox.Show($"Product {model} is out of stock.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra số lượng yêu cầu có lớn hơn số lượng tồn kho không
                if (quantity > stockQuantity)
                {
                    MessageBox.Show($"Not enough stock for product {model}. Available: {stockQuantity}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal price = unitPrice * quantity;

                var item = new ListViewItem(productID.ToString());
                item.SubItems.Add(model);
                item.SubItems.Add(quantity.ToString());
                item.SubItems.Add(unitPrice.ToString("C"));
                item.SubItems.Add(price.ToString("C"));

                lstSelectedProduct.Items.Add(item);

                CalculateTotalAmount();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lstSelectedProduct.SelectedItems.Count > 0 && nudQuantity.Value > 0)
            {
                var selectedItem = lstSelectedProduct.SelectedItems[0];
                int quantity = (int)nudQuantity.Value;
                decimal unitPrice = decimal.Parse(selectedItem.SubItems[3].Text, System.Globalization.NumberStyles.Currency);
                decimal newPrice = unitPrice * quantity;

                selectedItem.SubItems[2].Text = quantity.ToString();
                selectedItem.SubItems[4].Text = newPrice.ToString("C");

                CalculateTotalAmount();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstSelectedProduct.SelectedItems.Count > 0)
            {
                lstSelectedProduct.Items.Remove(lstSelectedProduct.SelectedItems[0]);

                CalculateTotalAmount();
            }
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có sản phẩm nào được chọn không
                if (lstSelectedProduct.Items.Count == 0)
                {
                    MessageBox.Show("Please add products to create an order.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra xem khách hàng có tồn tại không
                int customerID = _customerService.GetCustomerByPhone(txtPhone.Text)?.CustomerID ?? 0;
                if (customerID == 0)
                {
                    MessageBox.Show("Customer not found. Please add a customer.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Sử dụng _employeeID đã lưu
                int employeeID = _employeeID;

                // Tính toán tổng giá trị đơn hàng
                decimal totalAmount = lstSelectedProduct.Items.Cast<ListViewItem>()
                    .Sum(item => decimal.Parse(item.SubItems[4].Text, System.Globalization.NumberStyles.Currency));

                // Kiểm tra số lượng sản phẩm trong kho
                foreach (ListViewItem item in lstSelectedProduct.Items)
                {
                    int productID = int.Parse(item.Text);
                    int quantity = int.Parse(item.SubItems[2].Text);
                    var product = _productService.GetProductById(productID);
                    if (product.StockQuantity < quantity)
                    {
                        MessageBox.Show($"Not enough stock for product {product.Model}. Available: {product.StockQuantity}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Tạo đơn hàng mới
                var orderID = _orderService.CreateOrder(customerID, employeeID, totalAmount, "Pending", rtbNote.Text);

                // Thêm chi tiết đơn hàng
                foreach (ListViewItem item in lstSelectedProduct.Items)
                {
                    int productID = int.Parse(item.Text);
                    int quantity = int.Parse(item.SubItems[2].Text);
                    decimal unitPrice = decimal.Parse(item.SubItems[3].Text, System.Globalization.NumberStyles.Currency);
                    decimal price = unitPrice * quantity;

                    _orderService.AddOrderDetail(orderID, productID, quantity, unitPrice);

                    // Cập nhật số lượng sản phẩm trong kho
                    var product = _productService.GetProductById(productID);
                    product.StockQuantity -= quantity;
                    _productService.UpdateProduct(product);
                }

                // Hiển thị thông báo thành công
                MessageBox.Show("Order created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Đặt lại các trường nhập liệu
                lstSelectedProduct.Items.Clear();
                txtPhone.Clear();
                txtName.Clear();
                txtEmail.Clear();
                txtMembershipLevel.Clear();
                txtAddress.Clear();
                txtTotalAmount.Text = "0";
                rtbNote.Clear();

                // Tải lại danh sách sản phẩm từ CSDL
                LoadProductList();
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi
                MessageBox.Show($"Error creating order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateTotalAmount()
        {
            decimal totalAmount = lstSelectedProduct.Items.Cast<ListViewItem>()
                .Sum(item => decimal.Parse(item.SubItems[4].Text, System.Globalization.NumberStyles.Currency));
            txtTotalAmount.Text = totalAmount.ToString("C"); // Hiển thị tổng tiền
        }

        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ các trường nhập liệu
                string name = txtName.Text;
                string phone = txtPhone.Text;
                string email = txtEmail.Text;
                string address = txtAddress.Text;

                // Kiểm tra các trường bắt buộc
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(phone))
                {
                    MessageBox.Show("Name and Phone are required fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Thêm khách hàng mới với MembershipLevel mặc định là "Silver"
                _customerService.AddCustomer(name, phone, email, "Silver", address);

                // Hiển thị thông báo thành công
                MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Đặt lại các trường nhập liệu
                txtName.Clear();
                //txtPhone.Clear();
                txtEmail.Clear();
                txtMembershipLevel.Clear();
                txtAddress.Clear();

                // Vô hiệu hóa nút "Add New Customer" sau khi thêm thành công
                btnAddNewCustomer.Enabled = false;
            }
            catch (Exception ex)
            {
                // Hiển thị chi tiết lỗi từ inner exception
                MessageBox.Show($"Error adding customer: {ex.Message}\nInner Exception: {ex.InnerException?.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstSelectedProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSelectedProduct.SelectedItems.Count > 0)
            {
                // Lấy số lượng từ dòng được chọn
                int quantity = int.Parse(lstSelectedProduct.SelectedItems[0].SubItems[2].Text);

                // Hiển thị số lượng trong nudQuantity
                nudQuantity.Value = quantity;
            }
        }

        private void btnReloadLstProduct_Click(object sender, EventArgs e)
        {
            LoadProductList();
            nudQuantity.Value = 1;
            txtProductID.Clear();
        }

        private void btnReloadTpCreateOrder_Click(object sender, EventArgs e)
        {
            // Đặt lại các control về mặc định
            txtCustomerID.Clear();
            txtPhone.Clear();
            txtName.Clear();
            txtEmail.Clear();
            txtMembershipLevel.Clear();
            txtAddress.Clear();
            txtProductID.Clear();
            nudQuantity.Value = 1;
            lstSelectedProduct.Items.Clear();
            txtTotalAmount.Text = "0";

            // Tải lại danh sách sản phẩm từ CSDL
            LoadProductList();
        }

        #endregion
    }
}
