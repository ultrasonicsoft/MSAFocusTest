using System.Collections.Generic;
using HelloWorldModule.Utils;

namespace HelloWorldModule.Repository
{
    public interface ICustomerService
    {
        IList<Customer> GetAllCustomer();
    }
}