using CustomerSite.Server.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CustomerSite.Server.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerRepository customers;

        public CustomerController()
        {
            customers = new CustomerEntityRepository();
        }

        public async Task<ActionResult> Index()
        {
            return View();
        }

        public async Task<ActionResult> GetCustomers()
        {
            var allCustomers = await customers.GetAll();
            return PartialView("ExistingCustomerList", allCustomers);
        }

        [HttpPost]
        public async Task UpdateCustomer(string json)
        {
            var model = JsonConvert.DeserializeObject<Customer>(json);
            await customers.UpdateOne(model);
        }
    }
}