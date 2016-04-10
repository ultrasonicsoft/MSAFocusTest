using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSAFocusModule.Model;

namespace MSAFocusModule.Repository
{
    public class CustomerServiceMock : ICustomerService
    {
        public IList<Customer> GetAllCustomer()
        {
            var customers = new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    Name = "Balram",
                    State = "Maharashtra",
                    Country = "India"
                },
                new Customer
                {
                    Id = 2,
                    Name = "Krishna",
                    State = "CA",
                    Country = "USA"
                }
            };
            return customers;
        }
    }
}
