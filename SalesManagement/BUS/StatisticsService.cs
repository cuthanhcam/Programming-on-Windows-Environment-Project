using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data;
using BUS.Extensions;

namespace BUS
{
    public class StatisticsService
    {
        private readonly SalesManagementContext _context;

        public StatisticsService(SalesManagementContext context)
        {
            _context = context;
        }

        // Lớp để lưu trữ dữ liệu doanh thu
        public class RevenueData
        {
            public int OrderID { get; set; }
            public string CustomerName { get; set; }
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal TotalAmount { get; set; }
        }

        // Phương thức lấy dữ liệu doanh thu
        public List<RevenueData> GetRevenueData(DateTime startDate, DateTime endDate, string category)
        {
            var adjustedEndDate = endDate.AddDays(1);

            var query = _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderDetails.Select(od => od.Product))
                .Where(o => o.OrderDate >= startDate && o.OrderDate < adjustedEndDate && o.Status == "Completed")
                .AsQueryable();

            if (!string.IsNullOrEmpty(category) && category != "All")
            {
                // Chỉ lấy đơn hàng có ít nhất 1 sản phẩm trong danh mục được chọn
                query = query.Where(o => o.OrderDetails.Any(od => od.Product.Category == category));
            }

            Console.WriteLine($"Orders count after category filter: {query.Count()}");

            var revenueData = query.AsEnumerable()
                .SelectMany(o => o.OrderDetails
                    .Where(od => category == "All" || od.Product.Category == category)  // Lọc chi tiết theo category
                    .Select(od => new RevenueData
                    {
                        OrderID = o.OrderID,
                        CustomerName = o.Customer.Name,
                        ProductName = od.Product.Model,
                        Quantity = od.Quantity,
                        UnitPrice = od.UnitPrice,
                        TotalAmount = od.Price
                    }))
                .ToList();

            Console.WriteLine($"Filtered revenue data count: {revenueData.Count}");

            return revenueData;
        }

        public List<string> GetProductCategories()
        {
            return _context.Products
                .Select(p => p.Category)
                .Distinct()
                .ToList();
        }

        public DataTable GetTableData(string tableName, DateTime startDate, DateTime endDate)
        {
            var adjustedEndDate = endDate.AddDays(1);

            switch (tableName)
            {
                case "Customers":
                    return _context.Customers
                        .Where(c => c.CreatedAt >= startDate && c.CreatedAt < adjustedEndDate)
                        .Select(c => new
                        {
                            c.CustomerID,
                            c.Name,
                            c.Email,
                            c.Phone,
                            c.Address,
                            c.MembershipLevel,
                            c.CreatedAt,
                            c.UpdatedAt
                        })
                        .ToDataTable();

                case "Employees":
                    return _context.Employees
                        .Where(e => e.CreatedAt >= startDate && e.CreatedAt < adjustedEndDate)
                        .Select(e => new
                        {
                            e.EmployeeID,
                            e.Name,
                            e.Phone,
                            e.Address,
                            e.Role,
                            e.Salary,
                            e.HireDate,
                            e.Username,
                            e.CreatedAt,
                            e.UpdatedAt
                        })
                        .ToDataTable();

                case "Products":
                    return _context.Products
                        .Where(p => p.CreatedAt >= startDate && p.CreatedAt < adjustedEndDate)
                        .Select(p => new
                        {
                            p.ProductID,
                            p.Category,
                            p.Model,
                            p.Brand,
                            p.Price,
                            p.StockQuantity,
                            p.CreatedAt,
                            p.UpdatedAt
                        })
                        .ToDataTable();

                case "Orders":
                    return _context.Orders
                        .Where(o => o.OrderDate >= startDate && o.OrderDate < adjustedEndDate)
                        .Select(o => new
                        {
                            o.OrderID,
                            CustomerName = o.Customer.Name,
                            EmployeeName = o.Employee.Name,
                            o.OrderDate,
                            o.TotalAmount,
                            o.Discount,
                            o.Status,
                            o.Note,
                            o.CreatedAt,
                            o.UpdatedAt
                        })
                        .ToDataTable();

                case "OrderDetails":
                    return _context.OrderDetails
                        .Where(od => od.CreatedAt >= startDate && od.CreatedAt < adjustedEndDate)
                        .Select(od => new
                        {
                            od.OrderDetailID,
                            od.Order.OrderID,
                            ProductName = od.Product.Model,
                            od.Quantity,
                            od.UnitPrice,
                            od.Price,
                            od.CreatedAt,
                            od.UpdatedAt
                        })
                        .ToDataTable();

                case "StockTransactions":
                    return _context.StockTransactions
                        .Where(st => st.TransactionDate >= startDate && st.TransactionDate < adjustedEndDate)
                        .Select(st => new
                        {
                            st.TransactionID,
                            ProductName = st.Product.Model,
                            st.TransactionType,
                            st.Quantity,
                            st.TransactionDate,
                            EmployeeName = st.Employee.Name,
                            st.Note,
                            st.CreatedAt,
                            st.UpdatedAt
                        })
                        .ToDataTable();

                default:
                    throw new ArgumentException("Invalid table name");
            }
        }
    }
}