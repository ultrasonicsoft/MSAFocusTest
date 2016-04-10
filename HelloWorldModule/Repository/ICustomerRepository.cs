using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSAFocusModule.Model;

namespace MSAFocusModule.Repository
{
    public interface ICustomerRepository
    {
        IList<Customer> GetAllCustomers();
    }
}
