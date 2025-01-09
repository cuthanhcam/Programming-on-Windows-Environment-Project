using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DAL.Entities;

namespace GUI.Form_Components
{
    public partial class frmChangePassword : Form
    {
        private readonly EmployeeService _employeeService;

        public frmChangePassword()
        {
            InitializeComponent();
            _employeeService = new EmployeeService(new SalesManagementContext()); // Khởi tạo EmployeeService
            ApplyPlaceholder();
        }

        private void ApplyPlaceholder()
        {
            // Đặt placeholder cho username
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                txtUsername.Text = "Username";
                txtUsername.ForeColor = Color.Gray;
            }

            // Đặt placeholder cho password
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.Gray;
                txtPassword.PasswordChar = '\0'; // Hiển thị placeholder
            }

            // Đặt placeholder cho retry password
            if (string.IsNullOrWhiteSpace(txtRetryPassword.Text))
            {
                txtRetryPassword.Text = "Retry Password";
                txtRetryPassword.ForeColor = Color.Gray;
                txtRetryPassword.PasswordChar = '\0'; // Hiển thị placeholder
            }
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.Black;
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                txtUsername.Text = "Username";
                txtUsername.ForeColor = Color.Gray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
                txtPassword.PasswordChar = '•'; // Ẩn mật khẩu
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.Gray;
                txtPassword.PasswordChar = '\0'; // Hiển thị placeholder
            }
        }

        private void txtRetryPassword_Enter(object sender, EventArgs e)
        {
            if (txtRetryPassword.Text == "Retry Password")
            {
                txtRetryPassword.Text = "";
                txtRetryPassword.ForeColor = Color.Black;
                txtRetryPassword.PasswordChar = '•'; // Ẩn mật khẩu
            }
        }

        private void txtRetryPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRetryPassword.Text))
            {
                txtRetryPassword.Text = "Retry Password";
                txtRetryPassword.ForeColor = Color.Gray;
                txtRetryPassword.PasswordChar = '\0'; // Hiển thị placeholder
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';  // Hiển thị mật khẩu
                txtRetryPassword.PasswordChar = '\0';  // Hiển thị mật khẩu
            }
            else
            {
                if (txtPassword.Text != "Password")
                {
                    txtPassword.PasswordChar = '•';  // Ẩn mật khẩu
                }
                if (txtRetryPassword.Text != "Retry Password")
                {
                    txtRetryPassword.PasswordChar = '•';  // Ẩn mật khẩu
                }
            }
        }
        private bool IsValidPassword(string password)
        {
            if (password.Length < 6)
                return false;

            // Kiểm tra có ít nhất 1 chữ cái và 1 số
            bool hasLetter = password.Any(char.IsLetter);
            bool hasDigit = password.Any(char.IsDigit);

            return hasLetter && hasDigit;
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string newPassword = txtPassword.Text.Trim();
                string retryPassword = txtRetryPassword.Text.Trim();

                // Kiểm tra các trường nhập liệu
                if (string.IsNullOrWhiteSpace(username) ||
                    string.IsNullOrWhiteSpace(newPassword) ||
                    string.IsNullOrWhiteSpace(retryPassword) ||
                    username == "Username" ||
                    newPassword == "Password" ||
                    retryPassword == "Retry Password")
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra mật khẩu mới và nhập lại mật khẩu có khớp nhau không
                if (newPassword != retryPassword)
                {
                    MessageBox.Show("Mật khẩu mới và nhập lại mật khẩu không khớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtRetryPassword.Clear();
                    txtPassword.Focus();
                    return;
                }

                // Kiểm tra xem username có tồn tại không
                var currentEmployee = _employeeService.GetEmployeeByUsername(username);
                if (currentEmployee == null)
                {
                    MessageBox.Show("Tên đăng nhập không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tạo một bản sao của employee hiện tại để cập nhật
                var updatedEmployee = new Employee
                {
                    EmployeeID = currentEmployee.EmployeeID,
                    Name = currentEmployee.Name,
                    Phone = currentEmployee.Phone,
                    Address = currentEmployee.Address,
                    Role = currentEmployee.Role,
                    Salary = currentEmployee.Salary,
                    HireDate = currentEmployee.HireDate,
                    Username = currentEmployee.Username,
                    PasswordHash = newPassword, // Mật khẩu mới (chưa hash)
                    CreatedAt = currentEmployee.CreatedAt,
                    UpdatedAt = DateTime.Now,
                    Orders = currentEmployee.Orders,
                    StockTransactions = currentEmployee.StockTransactions
                };

                // Gọi phương thức cập nhật từ service
                _employeeService.UpdateEmployee(updatedEmployee);

                MessageBox.Show("Đổi mật khẩu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đổi mật khẩu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ResetForm()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtRetryPassword.Clear();
            ApplyPlaceholder();
            txtUsername.Focus();
        }

        private void frmChangePassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            ResetForm();
        }
    }
}