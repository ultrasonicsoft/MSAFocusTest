using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldModule.Utils
{
    public interface ICustomerRepository
    {
        IList<Customer> GetAllCustomers();
    }
}
