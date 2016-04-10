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
            var dbCustomers = _customerRepository.GetAllCustomers() as List<DbCustomer>;
            var customers = dbCustomers.ConvertAll((dbCustomer) => new Customer
            {
                Id = dbCustomer.CustomerId,
                Name = dbCustomer.CustomerName,
                State = dbCustomer.State,
                Country = dbCustomer.Country
            });
            return customers;
        }
    }
}
