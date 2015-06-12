using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerSite.Server.Models
{
    /// <summary>
    /// Persistant store of customer data and related operations.
    /// </summary>
    public interface ICustomerRepository
    {
        /// <summary>
        /// Asynchronously retrieves all customers from the database.
        /// </summary>
        /// <returns>List of customers</returns>
        Task<IEnumerable<Customer>> GetAll();

        /// <summary>
        /// Asynchronously updates customer information 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task UpdateOne(Customer model);
    }
}
