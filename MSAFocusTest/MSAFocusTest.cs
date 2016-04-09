using System.Collections.Generic;
using System.Linq;
using HelloWorldModule.Repository;
using HelloWorldModule.Utils;
using HelloWorldModule.ViewModel;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace MSAFocusTest
{
    [TestClass]
    public class MSAFocusModuleTest
    {
        private IUnityContainer _unityContainer;
        private ICustomerService _customerService;
        [TestInitialize]
        public void Setup()
        {
            _unityContainer = new UnityContainer();
            _unityContainer.RegisterType<ICustomerService, CustomerServiceMock>();
        }
        [TestMethod]
        public void CustomerServiceShouldReturnListOfTypeCustomer()
        {
            var customerService = _unityContainer.Resolve<ICustomerService>();
            CollectionAssert.AllItemsAreInstancesOfType(customerService.GetAllCustomer().ToList(), typeof(Customer));
        }
        [TestMethod]
        public void CustomerServiceShouldReturnNonEmptyListOfCustomers()
        {
            var customerService = _unityContainer.Resolve<ICustomerService>();
            CollectionAssert.AllItemsAreNotNull(customerService.GetAllCustomer().ToList());
        }

        [TestCleanup]
        public void CleanUp()
        {
            _unityContainer.Dispose();
        }
    }
}
