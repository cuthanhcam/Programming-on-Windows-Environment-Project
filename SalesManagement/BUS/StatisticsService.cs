using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class StatisticsService
    {
        private readonly SalesManagementContext _context;
        public StatisticsService(SalesManagementContext context)
        {
            _context = context;
        }
    }
}
