using CustomerSite.Server.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CustomerSite.Server.Controllers
{
    public class CustomersController : ApiController
    {
        private ICustomerRepository customers;

        public CustomersController()
        {
            customers = new CustomerEntityRepository();
        }

        #region PUBLIC API
        public async Task<IEnumerable<Customer>> Get()
        {
            return await customers.GetAll();
        }

        public async Task Post([FromBody]string value)
        {
            var model = Deserialise<Customer>(value);
            await customers.UpdateOne(model);
        }

        public async Task Put([FromBody]string value)
        {
            var model = Deserialise<Customer>(value);
            try
            {
                await customers.CreateOne(model);
            }
            catch (Exception e)
            {

            }
        }
        #endregion

        #region PRIVATE METHODS
        private T Deserialise<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
        #endregion
    }
}
