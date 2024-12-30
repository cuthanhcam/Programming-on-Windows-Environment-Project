using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class CustomerService
    {
        public static List<DAL.Entities.Customer> GetAll()
        {
            return BUS.CustomerService.GetAll();
        }

        public static DAL.Entities.Customer GetCustomerById(int id)
        {
            return BUS.CustomerService.GetCustomerById(id);
        }

        public static bool AddCustomer(DAL.Entities.Customer customer)
        {
            return BUS.CustomerService.AddCustomer(customer);
        }

        public static bool UpdateCustomer(DAL.Entities.Customer customer)
        {
            return BUS.CustomerService.UpdateCustomer(customer);
        }

        public static bool DeleteCustomer(int id)
        {
            return BUS.CustomerService.DeleteCustomer(id);
        }
    }
}
