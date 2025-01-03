using DAL.Entities;
using System;
using System.Collections.Generic;
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

        // Lấy tất cả đơn hàng
        public List<Order> GetAllOrders()
        {
            try
            {
                return _context.Orders.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving orders: " + ex.Message);
            }
        }

        // Lấy danh sách đơn hàng có trạng thái Pending
        public List<Order> GetPendingOrders()
        {
            try
            {
                return _context.Orders
                    .Where(o => o.Status == "Pending")
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving pending orders: " + ex.Message);
            }
        }

        // Lấy chi tiết đơn hàng
        public List<OrderDetail> GetOrderDetails(int orderID)
        {
            try
            {
                return _context.OrderDetails
                    .Where(od => od.OrderID == orderID)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving order details: " + ex.Message);
            }
        }

        // Tạo đơn hàng mới
        public bool CreateOrder(Order order, List<OrderDetail> orderDetails)
        {
            try
            {
                _context.Orders.Add(order);
                _context.SaveChanges();

                foreach (var detail in orderDetails)
                {
                    detail.OrderID = order.OrderID;
                    _context.OrderDetails.Add(detail);
                }

                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating order: " + ex.Message);
            }
        }

        // Cập nhật trạng thái đơn hàng
        public bool UpdateOrderStatus(int orderID, string status)
        {
            try
            {
                var order = _context.Orders.Find(orderID);
                if (order != null)
                {
                    order.Status = status;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating order status: " + ex.Message);
            }
        }
    }
}