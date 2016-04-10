using System.Collections.Generic;
using MSAFocusModule.Model;

namespace MSAFocusModule.Repository
{
    public interface ICustomerService
    {
        IList<Customer> GetAllCustomer();
    }
}