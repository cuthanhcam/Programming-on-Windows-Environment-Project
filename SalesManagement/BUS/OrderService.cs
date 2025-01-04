using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BUS
{
    public class OrderService
    {
        private readonly SalesManagementContext _context;

        public OrderService(SalesManagementContext context)
        {
            _context = context;
        }

        public List<Order> GetOrdersWithCustomerInfo(string searchOrderID = null, DateTime? searchOrderDateStart = null, DateTime? searchOrderDateEnd = null, string sortByTotalAmount = null)
        {
            var query = _context.Orders
                .Include(o => o.Customer)
                .AsQueryable();

            // Tìm kiếm theo OrderID
            if (!string.IsNullOrEmpty(searchOrderID))
            {
                query = query.Where(x => x.OrderID.ToString().Contains(searchOrderID));
            }

            // Tìm kiếm theo khoảng ngày
            if (searchOrderDateStart.HasValue && searchOrderDateEnd.HasValue)
            {
                query = query.Where(x => DbFunctions.TruncateTime(x.OrderDate) >= searchOrderDateStart.Value.Date &&
                                         DbFunctions.TruncateTime(x.OrderDate) <= searchOrderDateEnd.Value.Date);
            }

            // Sắp xếp theo TotalAmount
            if (!string.IsNullOrEmpty(sortByTotalAmount))
            {
                if (sortByTotalAmount.ToLower() == "asc")
                {
                    query = query.OrderBy(x => x.TotalAmount);
                }
                else if (sortByTotalAmount.ToLower() == "desc")
                {
                    query = query.OrderByDescending(x => x.TotalAmount);
                }
            }

            var result = query.ToList();
            return result;
        }

        public Order GetOrderDetails(int orderID)
        {
            var order = _context.Orders
                .Include(o => o.OrderDetails)
                .Include("OrderDetails.Product")
                .Include(o => o.Customer)
                .FirstOrDefault(o => o.OrderID == orderID);

            return order;
        }

        public Customer GetCustomerByOrderID(int orderID)
        {
            var order = _context.Orders
                .Include(o => o.Customer)
                .FirstOrDefault(o => o.OrderID == orderID);

            return order?.Customer;
        }

        public void UpdateOrderStatus(int orderID, string status)
        {
            try
            {
                var order = _context.Orders.FirstOrDefault(o => o.OrderID == orderID);
                if (order != null)
                {
                    order.Status = status;
                    order.UpdatedAt = DateTime.Now;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating order status: {ex.Message}");
            }
        }
    }
}