using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class CustomerService
    {
        private readonly SalesManagementContext _context;

        public CustomerService(SalesManagementContext context)
        {
            _context = context;
        }

        // Lấy tất cả khách hàng
        public List<Customer> GetAllCustomers()
        {
            try
            {
                return _context.Customers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving customers: " + ex.Message);
            }
        }

        // Lấy thông tin khách hàng bằng ID
        public Customer GetCustomerById(int id)
        {
            try
            {
                return _context.Customers.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving customer by ID: " + ex.Message);
            }
        }

        // Tìm kiếm khách hàng bằng số điện thoại
        public Customer GetCustomerByPhone(string phone)
        {
            try
            {
                return _context.Customers
                    .FirstOrDefault(c => c.Phone == phone);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving customer by phone: " + ex.Message);
            }
        }

        // Thêm khách hàng mới
        public bool AddCustomer(Customer customer)
        {
            try
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding customer: " + ex.Message);
            }
        }

        // Cập nhật thông tin khách hàng
        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                var existingCustomer = _context.Customers.Find(customer.CustomerID);
                if (existingCustomer != null)
                {
                    existingCustomer.Name = customer.Name;
                    existingCustomer.Email = customer.Email;
                    existingCustomer.Phone = customer.Phone;
                    existingCustomer.Address = customer.Address;
                    existingCustomer.MembershipLevel = customer.MembershipLevel;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating customer: " + ex.Message);
            }
        }

        // Xóa khách hàng
        public bool DeleteCustomer(int id)
        {
            try
            {
                var customer = _context.Customers.Find(id);
                if (customer != null)
                {
                    _context.Customers.Remove(customer);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting customer: " + ex.Message);
            }
        }

        public void AddCustomer(string name, string phone, string email, string membershipLevel, string address)
        {
            try
            {
                var newCustomer = new Customer
                {
                    Name = name,
                    Phone = phone,
                    Email = email,
                    MembershipLevel = membershipLevel, // Sử dụng giá trị được truyền vào
                    Address = address,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                _context.Customers.Add(newCustomer);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding customer: " + ex.Message);
            }
        }
    }
}