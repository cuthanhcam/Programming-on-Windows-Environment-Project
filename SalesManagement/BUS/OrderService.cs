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
    }
}
