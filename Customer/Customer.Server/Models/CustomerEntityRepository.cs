using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web;

namespace CustomerSite.Server.Models
{
    public class CustomerEntityRepository : ICustomerRepository
    {
        public async Task<IEnumerable<Customer>> GetAll()
        {
            using (var db = new CustomerDataContext())
            {
                return await db.Customers.ToListAsync();
            }
        }

        public async Task UpdateOne(Customer model)
        {
            using (var db = new CustomerDataContext())
            {
                var customer = await db.Customers.FindAsync(model.ID);

                if (customer == null)
                    throw new ArgumentException("ID not found.");

                // Don't save the model object directly - this ensures that
                // validation code is run against each property.
                customer.DateOfBirth = model.DateOfBirth;
                customer.FirstName = model.FirstName;
                customer.Surname = model.Surname;
                customer.Telephone = model.Telephone;

                await db.SaveChangesAsync();
            }
        }
    }
}