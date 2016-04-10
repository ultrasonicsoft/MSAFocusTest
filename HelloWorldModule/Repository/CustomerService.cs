using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSAFocusModule.Model;

namespace MSAFocusModule.Repository
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public IList<Customer> GetAllCustomer()
        {
            return _customerRepository.GetAllCustomers();
        }
    }
}
