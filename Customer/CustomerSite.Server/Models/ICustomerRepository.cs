using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerSite.Server.Models
{
    /// <summary>
    /// Persistant store of customer data.
    /// </summary>
    public interface ICustomerRepository
    {
        /// <summary>
        /// Asynchronously retrieves all customers from the database.
        /// </summary>
        /// <returns>List of customers</returns>
        Task<IEnumerable<Customer>> GetAllAsync();

        /// <summary>
        /// Asynchronously updates customer information 
        /// </summary>
        /// <param name="model">Mode to update</param>
        /// <returns>Updated customer</returns>
        Task<Customer> UpdateOneAsync(Customer model);

        /// <summary>
        /// Asynchronously creates a new customer
        /// </summary>
        /// <param name="model">Mode to create</param>
        /// <returns>Created customer</returns>
        Task<Customer> CreateOneAsync(Customer model);
    }
}
