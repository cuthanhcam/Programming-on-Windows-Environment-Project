using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

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
                existingEmployee.Position = employee.Position;
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

        public List<Employee> FilterEmployees(string searchName, string position, string salarySort)
        {
            var employees = _context.Employees.AsQueryable();

            if (!string.IsNullOrEmpty(searchName))
            {
                employees = employees.Where(e => e.Name.Contains(searchName));
            }

            if (!string.IsNullOrEmpty(position) && position != "All")
            {
                employees = employees.Where(e => e.Position == position);
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
    }
}