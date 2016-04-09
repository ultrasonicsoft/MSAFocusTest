using System.Collections.Generic;
using MSAFocusModule.Utils;

namespace MSAFocusModule.Repository
{
    public interface ICustomerService
    {
        IList<Customer> GetAllCustomer();
    }
}