using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CustomerSite.Server.Models
{
    public class CustomerDataContext : DbContext
    {
        public static string ConnectionString { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public CustomerDataContext() 
            : base(ConnectionString)
        {

        }
    }
}