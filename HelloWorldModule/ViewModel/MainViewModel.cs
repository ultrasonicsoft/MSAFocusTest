using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWorldModule.Repository;
using HelloWorldModule.Utils;

namespace HelloWorldModule.ViewModel
{
    public class MainViewModel
    {
        private ICustomerService customerService = new CustomerService();
        public IList<Customer> Customers { get; set; }
        public MainViewModel()
        {
            Customers = customerService.GetAllCustomer();
        }
    }
}
