using BUS;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class EmployeeManagement : UserControl
    {
        private readonly EmployeeService _employeeService;
        private List<Employee> _allEmployees;
        private List<Employee> _filteredEmployees;
        public EmployeeManagement(EmployeeService employeeService)
        {
            InitializeComponent();
            _employeeService = employeeService;
            _allEmployees = _employeeService.GetAllEmployees();
            _filteredEmployees = _allEmployees;

            InitializeListViewColumns();
            LoadEmployees(_filteredEmployees);
            InitializeComboBoxes();
            InitializeSearch();

            // Kết nối sự kiện
            lstEmployees.SelectedIndexChanged += lstEmployees_SelectedIndexChanged;
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnReload.Click += btnReload_Click;
        }

        private void InitializeListViewColumns()
        {
            lstEmployees.Columns.Clear();
            lstEmployees.Groups.Clear();
            lstEmployees.Columns.Add("ID", 50);
            lstEmployees.Columns.Add("Name", 220);
            lstEmployees.Columns.Add("Phone", 100);
            lstEmployees.Columns.Add("Address", 100);
            lstEmployees.Columns.Add("Position", 100);
            lstEmployees.Columns.Add("Salary", 100);
            lstEmployees.Columns.Add("Hire Date", 100);
        }
        private void LoadEmployees(List<Employee> employees)
        {
            lstEmployees.Items.Clear();
            foreach (var employee in employees)
            {
                var item = new ListViewItem(employee.EmployeeID.ToString());
                item.SubItems.Add(employee.Name);
                item.SubItems.Add(employee.Phone);
                item.SubItems.Add(employee.Address);
                item.SubItems.Add(employee.Role);
                item.SubItems.Add((employee.Salary ?? 0).ToString("C"));
                item.SubItems.Add(employee.HireDate.ToShortDateString());
                lstEmployees.Items.Add(item);
            }
        }
        private void InitializeComboBoxes()
        {
            cmbPositionFilter.Items.Add("All");
            cmbPositionFilter.Items.Add("Admin");
            cmbPositionFilter.Items.Add("Staff");
            cmbPositionFilter.SelectedIndex = 0;

            cmbSalary.Items.Add("All");
            cmbSalary.Items.Add("Salary Ascending");
            cmbSalary.Items.Add("Salary Descending");
            cmbSalary.SelectedIndex = 0;

            cmbRole.Items.Add("Admin");
            cmbRole.Items.Add("Staff");
            cmbRole.SelectedIndex = 0;
        }
        private void InitializeSearch()
        {
            txtSearchName.TextChanged += txtSearchName_TextChanged;
            cmbPositionFilter.SelectedIndexChanged += cmbPositionFilter_SelectedIndexChanged;
            cmbSalary.SelectedIndexChanged += cmbSalary_SelectedIndexChanged;
        }

        private void FilterEmployees()
        {
            string searchName = txtSearchName.Text.Trim();
            string role = cmbPositionFilter.SelectedItem?.ToString() ?? "All";
            string salarySort = cmbSalary.SelectedItem?.ToString() ?? "All";

            _filteredEmployees = _employeeService.FilterEmployees(searchName, role, salarySort);
            LoadEmployees(_filteredEmployees);
        }

        private void lstEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstEmployees.SelectedItems.Count > 0)
            {
                var selectedEmployeeId = int.Parse(lstEmployees.SelectedItems[0].Text);
                var employee = _employeeService.GetEmployeeById(selectedEmployeeId);

                if (employee != null)
                {
                    // Hiển thị thông tin nhân viên
                    txtName.Text = employee.Name;
                    txtPhone.Text = employee.Phone;
                    txtAddress.Text = employee.Address;
                    cmbRole.SelectedItem = employee.Role ?? "Staff"; // Giá trị mặc định nếu Role là null
                    txtSalary.Text = (employee.Salary ?? 0).ToString("0.00");
                    dtpHireDate.Value = employee.HireDate;
                    txtUsername.Text = employee.Username;
                    txtPassword.Text = ""; // Không hiển thị mật khẩu
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo đối tượng Employee từ dữ liệu nhập vào
                var employee = new Employee
                {
                    Name = txtName.Text,
                    Phone = txtPhone.Text,
                    Address = txtAddress.Text,
                    Role = cmbRole.SelectedItem.ToString(),
                    Salary = decimal.Parse(txtSalary.Text),
                    HireDate = dtpHireDate.Value,
                    Username = txtUsername.Text,
                    PasswordHash = txtPassword.Text // Mật khẩu gốc
                };

                // Thêm nhân viên vào cơ sở dữ liệu
                _employeeService.AddEmployee(employee);

                // Làm mới danh sách nhân viên
                _allEmployees = _employeeService.GetAllEmployees();
                LoadEmployees(_allEmployees);

                MessageBox.Show("Nhân viên đã được thêm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstEmployees.SelectedItems.Count > 0)
                {
                    var selectedEmployeeId = int.Parse(lstEmployees.SelectedItems[0].Text);
                    var employee = _employeeService.GetEmployeeById(selectedEmployeeId);

                    if (employee != null)
                    {
                        // Cập nhật thông tin nhân viên
                        employee.Name = txtName.Text;
                        employee.Phone = txtPhone.Text;
                        employee.Address = txtAddress.Text;
                        employee.Role = cmbRole.SelectedItem.ToString();
                        employee.Salary = decimal.Parse(txtSalary.Text);
                        employee.HireDate = dtpHireDate.Value;
                        employee.Username = txtUsername.Text;
                        employee.PasswordHash = txtPassword.Text; // Mật khẩu gốc

                        _employeeService.UpdateEmployee(employee);

                        // Làm mới danh sách nhân viên
                        _allEmployees = _employeeService.GetAllEmployees();
                        LoadEmployees(_allEmployees);

                        MessageBox.Show("Thông tin nhân viên đã được cập nhật thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstEmployees.SelectedItems.Count > 0)
                {
                    var selectedEmployeeId = int.Parse(lstEmployees.SelectedItems[0].Text);
                    var employee = _employeeService.GetEmployeeById(selectedEmployeeId);

                    if (employee != null)
                    {
                        // Hiển thị hộp thoại xác nhận
                        var confirmResult = MessageBox.Show(
                            "Bạn có chắc chắn muốn xóa nhân viên này?",
                            "Xác nhận xóa",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (confirmResult == DialogResult.Yes)
                        {
                            // Xóa nhân viên
                            _employeeService.DeleteEmployee(selectedEmployeeId);

                            // Làm mới danh sách nhân viên
                            _allEmployees = _employeeService.GetAllEmployees();
                            LoadEmployees(_allEmployees);

                            MessageBox.Show("Nhân viên đã được xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            // Làm mới danh sách nhân viên
            _allEmployees = _employeeService.GetAllEmployees();
            LoadEmployees(_allEmployees);
            txtEmployeeID.Clear();
            // Xóa dữ liệu trong các control nhập liệu
            txtName.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            cmbRole.SelectedIndex = 0;
            txtSalary.Clear();
            dtpHireDate.Value = DateTime.Now;
            txtUsername.Clear();
            txtPassword.Clear();
        }

        

        private void HighlightEmployeeInList(int employeeId)
        {
            if (lstEmployees.Items != null)
            {
                foreach (ListViewItem item in lstEmployees.Items)
                {
                    if (item.Text == employeeId.ToString())
                    {
                        item.Selected = true;
                        item.EnsureVisible();
                        lstEmployees.Focus();
                        break;
                    }
                }
            }
        }
        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            FilterEmployees();
        }

        private void cmbPositionFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterEmployees();
        }

        private void cmbSalary_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterEmployees();
        }

        private void txtEmployeeID_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtEmployeeID.Text, out int employeeId))
            {
                var employee = _employeeService.GetEmployeeById(employeeId);
                if (employee != null)
                {
                    // Hiển thị thông tin nhân viên
                    txtName.Text = employee.Name;
                    txtPhone.Text = employee.Phone;
                    txtAddress.Text = employee.Address;
                    cmbRole.SelectedItem = employee.Role;
                    txtSalary.Text = (employee.Salary ?? 0).ToString("0.00");
                    dtpHireDate.Value = employee.HireDate;
                    txtUsername.Text = employee.Username;
                    txtPassword.Text = ""; // Không hiển thị mật khẩu

                    // Làm nổi bật nhân viên trong danh sách
                    HighlightEmployeeInList(employeeId);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên với ID này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (string.IsNullOrEmpty(txtEmployeeID.Text))
            {
                // Nếu txtEmployeeID trống, hiển thị lại toàn bộ danh sách
                LoadEmployees(_allEmployees);
            }
        }
    }
}
