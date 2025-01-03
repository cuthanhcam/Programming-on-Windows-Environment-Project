using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BUS
{
    public class UserService
    {
        private readonly SalesManagementContext _context;
        public UserService()
        {
            _context = new SalesManagementContext();
        }
        public bool Login(string username, string password, out string role)
        {
            role = null;

            // Find user by username
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user == null) return false;

            // Verify password
            if (!VerifyPasswordHash(password, user.PasswordHash))
            {
                return false;
            }

            role = user.Role; // Set role (Admin/User)
            return true;
        }

        // Method encrypt SHA256
        private bool VerifyPasswordHash(string password, string storedHash)
        {
            // Hàm trả về mã băm SHA256
            /*
            using (var sha256 = SHA256.Create())
            {
                var computedHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var computedHashString = string.Concat(computedHash.Select(b => b.ToString("x2")));
                return storedHash.Equals(computedHashString, StringComparison.OrdinalIgnoreCase);
            }
            */
            // Cập nhật lại hàm VerifyPasswordHash so sánh mã băm dưới dạng chuỗi HEX
            using (var sha256 = SHA256.Create())
            {
                // Tính toán băm của mật khẩu nhập vào
                var computedHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                // Chuyển đổi băm tính được thành chuỗi hex
                var computedHashString = string.Concat(computedHash.Select(b => b.ToString("x2")));

                // So sánh với giá trị băm đã lưu trong cơ sở dữ liệu
                return storedHash.Equals(computedHashString, StringComparison.OrdinalIgnoreCase);
            }
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            var existingUser = _context.Users.Find(user.UserID);
            if (existingUser != null)
            {
                existingUser.Username = user.Username;
                existingUser.PasswordHash = user.PasswordHash;
                existingUser.Role = user.Role;
                _context.SaveChanges();
            }
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.UserID == id);
        }

        public User GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }
    }
}
