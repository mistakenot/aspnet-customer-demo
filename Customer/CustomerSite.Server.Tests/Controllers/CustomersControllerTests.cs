using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomerSite.Server.Controllers;
using System.Threading.Tasks;
using CustomerSite.Server.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace CustomerSite.Server.Tests.Controllers
{
    [TestClass]
    public class CustomersControllerTests
    {
        private ICustomersController controller;
        private Customer customer;

        [TestInitialize]
        public void Init()
        {
            controller = new CustomersController();
            customer = new Customer("Zaphod", "Beeblebrox", "01234 567 789", DateTime.Parse("01/01/1990"));
        }

        [TestMethod]
        public async Task CustomersController_Get_OK()
        {
            await controller.Get();
        }

        [TestMethod]
        public async Task CustomersController_Create_OK()
        {
            var json = ToJson(customer);
            await controller.Put(json);

            var all = await controller.Get();
            var retrieved = all.Last();

            Assert.AreEqual(customer.DisplayName, retrieved.DisplayName);
            Assert.AreEqual(customer.Age, retrieved.Age);
            Assert.AreEqual(customer.Colour, retrieved.Colour);
            Assert.AreEqual(customer.Telephone, retrieved.Telephone);
        }

        [TestMethod]
        public async Task CustomersController_Update_OK()
        {
            var json = ToJson(customer);
            await controller.Put(json);

            var all = await controller.Get();
            var retrieved = all.Last();

            retrieved.FirstName = customer.FirstName + "abcdefg";

            await controller.Post(ToJson(retrieved));
            var updated = (await controller.Get()).Last();

            Assert.AreNotEqual(customer.FirstName, updated.FirstName);
        }

        private string ToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
