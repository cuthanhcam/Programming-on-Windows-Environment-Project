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

        // Tính tổng số tiền đã chi của khách hàng
        //public decimal GetTotalSpentByCustomer(int customerID)
        //{
        //    try
        //    {
        //        var total = _context.Orders
        //            .Where(o => o.CustomerID == customerID && o.Status == "Completed")
        //            .Sum(o => (decimal?)o.TotalAmount) ?? 0; // Sử dụng decimal? để tránh lỗi NULL

        //        return total;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error calculating total spent by customer: " + ex.Message);
        //    }
        //}

        public decimal GetTotalSpentByCustomer(int customerID)
        {
            try
            {
                var orders = _context.Orders
                    .Where(o => o.CustomerID == customerID && o.Status == "Completed")
                    .ToList();

                decimal totalSpent = 0;

                foreach (var order in orders)
                {
                    var customer = _context.Customers.FirstOrDefault(c => c.CustomerID == order.CustomerID);
                    if (customer != null)
                    {
                        decimal discountRate = GetDiscountRate(customer.MembershipLevel);
                        decimal discountAmount = order.TotalAmount * discountRate;
                        decimal totalAmountPayable = order.TotalAmount - discountAmount;

                        totalSpent += totalAmountPayable;
                    }
                }

                return totalSpent;
            }
            catch (Exception ex)
            {
                throw new Exception("Error calculating total spent by customer: " + ex.Message);
            }
        }

        private decimal GetDiscountRate(string membershipLevel)
        {
            switch (membershipLevel?.ToLower())
            {
                case "silver":
                    return 0m;
                case "gold":
                    return 0.05m;
                case "platinum":
                    return 0.10m;
                default:
                    return 0m;
            }
        }

        // Lấy danh sách khách hàng kèm tổng số tiền đã chi
        public List<CustomerWithTotal> GetAllCustomersWithTotalSpent()
        {
            try
            {
                var customers = _context.Customers.ToList();
                var result = new List<CustomerWithTotal>();

                foreach (var customer in customers)
                {
                    decimal totalSpent = GetTotalSpentByCustomer(customer.CustomerID);
                    string membershipLevel = CalculateMembershipLevel(totalSpent);

                    result.Add(new CustomerWithTotal
                    {
                        CustomerID = customer.CustomerID,
                        Name = customer.Name,
                        Email = customer.Email,
                        Phone = customer.Phone,
                        Address = customer.Address,
                        MembershipLevel = membershipLevel,
                        TotalSpent = totalSpent
                    });
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving customers with total spent: " + ex.Message);
            }
        }

        // Phương thức tính toán MembershipLevel
        private string CalculateMembershipLevel(decimal totalSpent)
        {
            if (totalSpent < 2000)
                return "Silver";
            else if (totalSpent >= 2000 && totalSpent < 5000)
                return "Gold";
            else
                return "Platinum";
        }

        // Lớp hỗ trợ để lưu thông tin khách hàng kèm tổng số tiền đã chi
        public class CustomerWithTotal
        {
            public int CustomerID { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
            public string MembershipLevel { get; set; }
            public decimal TotalSpent { get; set; }
        }
    }
}