using CustomerSite.Server.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerSite.Server.Controllers
{
    public interface ICustomersController
    {
        /// <summary>
        /// Retrieves a list of all customers.
        /// </summary>
        /// <returns>IEnumerable of Customers</returns>
        Task<IEnumerable<Customer>> Get();

        /// <summary>
        /// Updates a single customer.
        /// </summary>
        /// <param name="value">JSON representation of customer data</param>
        Task Post(string value);

        /// <summary>
        /// Creates a new customer.
        /// </summary>
        /// <param name="value">JSON representation of customer data</param>
        /// <returns></returns>
        Task Put(string value);
    }
}
