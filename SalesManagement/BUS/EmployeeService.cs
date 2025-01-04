using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BUS
{
    public class EmployeeService
    {
        private readonly SalesManagementContext _context;

        public EmployeeService(SalesManagementContext context)
        {
            _context = context;
        }

        public List<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return _context.Employees.FirstOrDefault(e => e.EmployeeID == id);
        }

        public void AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public List<Employee> SearchEmployeeById(int id)
        {
            return _context.Employees.Where(e => e.EmployeeID == id).ToList();
        }

        public void UpdateEmployee(Employee employee)
        {
            var existingEmployee = _context.Employees.Find(employee.EmployeeID);
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.Phone = employee.Phone;
                existingEmployee.Address = employee.Address;
                existingEmployee.Role = employee.Role;
                existingEmployee.Salary = employee.Salary;
                existingEmployee.HireDate = employee.HireDate;
                _context.SaveChanges();
            }
        }

        public void DeleteEmployee(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }

        public List<Employee> FilterEmployees(string searchName, string role, string salarySort)
        {
            var employees = _context.Employees.AsQueryable();

            if (!string.IsNullOrEmpty(searchName))
            {
                employees = employees.Where(e => e.Name.Contains(searchName));
            }

            if (!string.IsNullOrEmpty(role) && role != "All")
            {
                employees = employees.Where(e => e.Role == role);
            }

            if (salarySort == "Salary Ascending")
            {
                employees = employees.OrderBy(e => e.Salary);
            }
            else if (salarySort == "Salary Descending")
            {
                employees = employees.OrderByDescending(e => e.Salary);
            }

            return employees.ToList();
        }

        public bool Login(string username, string password, out string role)
        {
            role = null;

            // Tìm nhân viên theo username
            var employee = _context.Employees.FirstOrDefault(e => e.Username == username);
            if (employee == null) return false;

            // Kiểm tra mật khẩu
            if (!VerifyPasswordHash(password, employee.PasswordHash))
            {
                return false;
            }

            role = employee.Role; // Trả về vai trò của nhân viên
            return true;
        }

        private bool VerifyPasswordHash(string password, string storedHash)
        {
            using (var sha256 = SHA256.Create())
            {
                var computedHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var computedHashString = string.Concat(computedHash.Select(b => b.ToString("x2")));
                return storedHash.Equals(computedHashString, StringComparison.OrdinalIgnoreCase);
            }
        }
    }
}