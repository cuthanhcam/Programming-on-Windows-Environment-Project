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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                //SetFormStyle(this);  // Áp dụng UI cho toàn bộ form
                //CustomizeDesign();   // Tùy chỉnh thiết kế các control
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // Thiết lập UI Form
        private void SetFormStyle(Form form)
        {
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.BackColor = Color.White;
            form.Font = new Font("Segoe UI", 10);
            form.ForeColor = Color.Black;
            form.StartPosition = FormStartPosition.CenterScreen;
        }

        // Thiết kế Control như Panel, Button
        private void CustomizeDesign()
        {
            // Panel chính (Fill toàn bộ form)
            Panel panelMain = new Panel();
            panelMain.Dock = DockStyle.Fill;
            panelMain.BackColor = Color.White;
            this.Controls.Add(panelMain);

            // Panel bên trái (Sidebar)
            Panel panelLeft = new Panel();
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Width = 300;
            panelLeft.BackColor = Color.FromArgb(41, 128, 185);  // Màu xanh
            this.Controls.Add(panelLeft);

            // Label chào mừng
            Label lblWelcome = new Label();
            lblWelcome.Text = "Welcome to Service Management";
            lblWelcome.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblWelcome.ForeColor = Color.White;
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            lblWelcome.Dock = DockStyle.Top;
            panelLeft.Controls.Add(lblWelcome);

            // Nút Login
            Button btnLogin = new Button();
            btnLogin.Text = "LOGIN";
            btnLogin.Size = new Size(250, 40);
            btnLogin.Location = new Point(180, 220);
            btnLogin.BackColor = Color.FromArgb(41, 128, 185);
            btnLogin.ForeColor = Color.White;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.Click += btnLogin_Click;
            panelMain.Controls.Add(btnLogin);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Login Clicked!");
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
                txtPassword.PasswordChar = '•';
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.Gray;
                txtPassword.PasswordChar = '\0';
            }
        }
    }
}
