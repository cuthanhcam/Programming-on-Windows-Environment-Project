using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class OrderService
    {
        private readonly SalesManagementContext _context;
        public OrderService(SalesManagementContext context)
        {
            _context = context;
        }

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


    }
}
