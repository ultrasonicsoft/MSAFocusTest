using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWorldModule.Utils;

namespace HelloWorldModule.Repository
{
    public class CustomerService : ICustomerService
    {
        private readonly DBManager dbManager = new DBManager();
        public IList<Customer> GetAllCustomer()
        {
            return dbManager.GetAllCustomers();
        }
    }
}
