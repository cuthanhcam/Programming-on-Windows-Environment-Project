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
    public partial class CustomerManagement : UserControl
    {
        private readonly CustomerService _customerService;
        private readonly OrderService _orderService;

        public CustomerManagement(CustomerService customerService, OrderService orderService)
        {
            InitializeComponent();
            _customerService = customerService;
            _orderService = orderService;
            InitializeListViewColumns();
            LoadCustomers();
            lstCustomer.SelectedIndexChanged += lstCustomer_SelectedIndexChanged;

            cmbMembershipLevel.Items.AddRange(new string[] { "Silver", "Gold", "Platinum" });
            cmbMembershipLevel.SelectedIndex = 0;

            cmbTotalSpent.Items.AddRange(new string[] { "All", "Ascending", "Descending" });
            cmbTotalSpent.SelectedIndex = 0; 
        }

        private void InitializeListViewColumns()
        {
            lstCustomer.Columns.Clear();
            lstCustomer.Columns.Add("ID", 50);
            lstCustomer.Columns.Add("Name", 180);
            lstCustomer.Columns.Add("Email", 170);
            lstCustomer.Columns.Add("Phone", 100);
            lstCustomer.Columns.Add("Address", 120);
            lstCustomer.Columns.Add("Level", 80);
            lstCustomer.Columns.Add("Total", 100);

            lstCustomer.ShowGroups = true;
            lstCustomer.View = View.Details;
        }

        private void LoadCustomers(string sortByTotalSpent = "All")
        {
            try
            {
                // Refresh context trước khi lấy dữ liệu
                _customerService.RefreshContext();

                var customers = _customerService.GetAllCustomersWithTotalSpent();

                switch (sortByTotalSpent.ToLower())
                {
                    case "ascending":
                        customers = customers.OrderBy(c => c.TotalSpent).ToList();
                        break;
                    case "descending":
                        customers = customers.OrderByDescending(c => c.TotalSpent).ToList();
                        break;
                }

                lstCustomer.BeginUpdate();
                lstCustomer.Items.Clear();
                lstCustomer.Groups.Clear();

                var groupPlatinum = new ListViewGroup("Platinum", HorizontalAlignment.Left);
                var groupGold = new ListViewGroup("Gold", HorizontalAlignment.Left);
                var groupSilver = new ListViewGroup("Silver", HorizontalAlignment.Left);

                lstCustomer.Groups.AddRange(new ListViewGroup[] { groupPlatinum, groupGold, groupSilver });

                foreach (var customer in customers)
                {
                    var item = new ListViewItem(new[]
                    {
                        customer.CustomerID.ToString(),
                        customer.Name,
                        customer.Email ?? string.Empty,
                        customer.Phone,
                        customer.Address ?? string.Empty,
                        customer.MembershipLevel,
                        customer.TotalSpent.ToString("C")
                    });

                    switch (customer.MembershipLevel.ToUpper())
                    {
                        case "PLATINUM":
                            item.Group = groupPlatinum;
                            break;
                        case "GOLD":
                            item.Group = groupGold;
                            break;
                        case "SILVER":
                            item.Group = groupSilver;
                            break;
                    }

                    lstCustomer.Items.Add(item);
                }

                lstCustomer.EndUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCustomer.SelectedItems.Count > 0)
            {
                var selectedItem = lstCustomer.SelectedItems[0];
                int customerID = int.Parse(selectedItem.Text);

                var customer = _customerService.GetCustomerById(customerID);
                if (customer != null)
                {
                    txtCustomerID.Text = customer.CustomerID.ToString();
                    txtName.Text = customer.Name;
                    txtPhone.Text = customer.Phone;
                    txtEmail.Text = customer.Email;
                    txtAddress.Text = customer.Address;
                    cmbMembershipLevel.SelectedItem = customer.MembershipLevel;
                }
            }
        }

        private void btnPurchaseHistory_Click(object sender, EventArgs e)
        {
            if (lstCustomer.SelectedItems.Count > 0)
            {
                int customerID = int.Parse(lstCustomer.SelectedItems[0].Text);

                try
                {
                    var purchaseHistory = _orderService.GetPurchaseHistoryByCustomer(customerID);
                    var purchaseHistoryForm = new frmPurchaseHistory(purchaseHistory, _orderService);
                    purchaseHistoryForm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading purchase history: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to view purchase history.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var customer = new Customer
                {
                    Name = txtName.Text,
                    Phone = txtPhone.Text,
                    Email = txtEmail.Text,
                    Address = txtAddress.Text,
                    MembershipLevel = cmbMembershipLevel.SelectedItem?.ToString() ?? "Silver",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                _customerService.AddCustomer(customer);
                LoadCustomers(); // Tải lại danh sách khách hàng
                ClearForm(); // Xóa form nhập liệu
                MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtCustomerID.Text, out int customerID))
                {
                    var customer = new Customer
                    {
                        CustomerID = customerID,
                        Name = txtName.Text,
                        Phone = txtPhone.Text,
                        Email = txtEmail.Text,
                        Address = txtAddress.Text,
                        MembershipLevel = cmbMembershipLevel.SelectedItem?.ToString() ?? "Silver",
                        UpdatedAt = DateTime.Now
                    };

                    _customerService.UpdateCustomer(customer);
                    LoadCustomers(); // Tải lại danh sách khách hàng
                    MessageBox.Show("Customer updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Invalid Customer ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtCustomerID.Text, out int customerID))
                {
                    // Hiển thị hộp thoại xác nhận xóa
                    var result = MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        _customerService.DeleteCustomer(customerID);
                        LoadCustomers(); // Tải lại danh sách khách hàng
                        ClearForm(); // Xóa form nhập liệu
                        MessageBox.Show("Customer deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Customer ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    var customer = _customerService.GetCustomerByPhone(txtPhone.Text);
                    if (customer != null)
                    {
                        txtCustomerID.Text = customer.CustomerID.ToString();
                        txtName.Text = customer.Name;
                        txtEmail.Text = customer.Email;
                        txtAddress.Text = customer.Address;
                        cmbMembershipLevel.SelectedItem = customer.MembershipLevel;
                    }
                    else
                    {
                        MessageBox.Show("Customer not found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error searching customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearForm()
        {
            txtCustomerID.Clear();
            txtName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            cmbMembershipLevel.SelectedIndex = 0;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            try
            {
                ClearForm();

                string sortByTotalSpent = cmbTotalSpent.SelectedItem?.ToString() ?? "All";
                LoadCustomers(sortByTotalSpent);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reloading customers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbTotalSpent_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sortByTotalSpent = cmbTotalSpent.SelectedItem?.ToString() ?? "All";
            LoadCustomers(sortByTotalSpent);
        }

        private void lstCustomer_DoubleClick(object sender, EventArgs e)
        {
            if (lstCustomer.SelectedItems.Count > 0)
            {
                int customerID = int.Parse(lstCustomer.SelectedItems[0].Text);

                try
                {
                    var purchaseHistory = _orderService.GetPurchaseHistoryByCustomer(customerID);
                    var purchaseHistoryForm = new frmPurchaseHistory(purchaseHistory, _orderService);
                    purchaseHistoryForm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading purchase history: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
