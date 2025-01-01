using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class StockService
    {
        private readonly SalesManagementContext _context;
        public StockService(SalesManagementContext context)
        {
            _context = context;
        }
    }
}
