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
                int orderId;
                if (int.TryParse(searchOrderID, out orderId))
                {
                    query = query.Where(x => x.OrderID == orderId);
                }
                else
                {
                    // Nếu searchOrderID không phải là số, không trả về kết quả nào
                    query = query.Where(x => false);
                }
            }

            // Tìm kiếm theo khoảng ngày
            if (searchOrderDateStart.HasValue && searchOrderDateEnd.HasValue)
            {
                query = query.Where(x => DbFunctions.TruncateTime(x.OrderDate) >= DbFunctions.TruncateTime(searchOrderDateStart.Value) &&
                         DbFunctions.TruncateTime(x.OrderDate) <= DbFunctions.TruncateTime(searchOrderDateEnd.Value));

            }

            // Sắp xếp theo TotalAmount
            if (!string.IsNullOrEmpty(sortByTotalAmount))
            {
                if (sortByTotalAmount.Equals("Ascending", StringComparison.OrdinalIgnoreCase))
                {
                    query = query.OrderBy(x => x.TotalAmount);
                }
                else if (sortByTotalAmount.Equals("Descending", StringComparison.OrdinalIgnoreCase))
                {
                    query = query.OrderByDescending(x => x.TotalAmount);
                }
                // Nếu là "All" hoặc không hợp lệ, không sắp xếp
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
                var order = _context.Orders
                    .Include(o => o.OrderDetails)
                    .FirstOrDefault(o => o.OrderID == orderID);

                if (order != null)
                {
                    if (status == "Completed" && order.Status != "Completed")
                    {
                        // Cập nhật trạng thái đơn hàng
                        order.Status = status;
                        order.UpdatedAt = DateTime.Now;
                        _context.SaveChanges();

                        // Cập nhật lại MembershipLevel của khách hàng
                        var customerService = new CustomerService(_context);
                        customerService.GetAllCustomersWithTotalSpent();
                    }
                    else if (status == "Canceled" && order.Status == "Pending")
                    {
                        foreach (var detail in order.OrderDetails)
                        {
                            if (detail == null) continue;

                            var product = _context.Products.FirstOrDefault(p => p.ProductID == detail.ProductID);
                            if (product != null)
                            {
                                int oldQuantity = product.StockQuantity;
                                product.StockQuantity += detail.Quantity;
                                _context.Entry(product).State = EntityState.Modified;

                                // Log để kiểm tra
                                Console.WriteLine($"Product ID: {product.ProductID}, Old Quantity: {oldQuantity}, Added Quantity: {detail.Quantity}, New Quantity: {product.StockQuantity}");
                            }
                        }

                        order.Status = status;
                        order.UpdatedAt = DateTime.Now;
                        _context.SaveChanges();

                        // Log để kiểm tra
                        Console.WriteLine($"Order ID: {order.OrderID} has been canceled successfully.");
                    }
                }
                else
                {
                    throw new Exception("Order not found.");
                }
            }
            catch (Exception ex)
            {
                // Log lỗi
                Console.WriteLine($"Error updating order status: {ex.Message}");
                throw new Exception($"Error updating order status: {ex.Message}");
            }
        }

        public void UpdateOrderNote(int orderID, string note)
        {
            try
            {
                var order = _context.Orders.FirstOrDefault(o => o.OrderID == orderID);
                if (order != null)
                {
                    order.Note = note;
                    order.UpdatedAt = DateTime.Now;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating order note: {ex.Message}");
            }
        }
        public int CreateOrder(int customerID, int employeeID, decimal totalAmount, string status, string note)
        {
            try
            {
                var order = new Order
                {
                    CustomerID = customerID,
                    EmployeeID = employeeID,
                    TotalAmount = totalAmount,
                    Status = status,
                    Note = note,
                    OrderDate = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                _context.Orders.Add(order);
                _context.SaveChanges();

                return order.OrderID; // Trả về ID của đơn hàng vừa tạo
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating order: " + ex.Message);
            }
        }

        public void AddOrderDetail(int orderID, int productID, int quantity, decimal unitPrice)
        {
            try
            {
                var orderDetail = new OrderDetail
                {
                    OrderID = orderID,
                    ProductID = productID,
                    Quantity = quantity,
                    UnitPrice = unitPrice,
                    Price = unitPrice * quantity, // Tính toán giá trị Price
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                _context.OrderDetails.Add(orderDetail);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding order detail: " + ex.Message);
            }
        }

        // Lấy lịch sử mua hàng của khách hàng
        public List<Order> GetPurchaseHistoryByCustomer(int customerID)
        {
            try
            {
                return _context.Orders
                    .Where(o => o.CustomerID == customerID)
                    .OrderByDescending(o => o.OrderDate)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving purchase history: " + ex.Message);
            }
        }
   
    }
}