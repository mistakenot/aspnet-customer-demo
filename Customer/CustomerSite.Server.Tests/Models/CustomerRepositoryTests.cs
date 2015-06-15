using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomerSite.Server.Models;
using System.Threading.Tasks;

namespace CustomerSite.Server.Tests.Models
{
    [TestClass]
    public class CustomerRepositoryTests
    {
        private ICustomerRepository repo;

        [TestInitialize]
        public void Init()
        {
            // TODO Use a local DB file instance so we don't mess up production table.
            CustomerDataContext.ConnectionString = @"Server=(localdb)\v11.0;Integrated Security=true;";
            repo = new CustomerEntityRepository();
        }

        [TestMethod]
        public async Task CustomerRepo_CreateEntity_OK()
        {
            var customer = CreateNew();

            var created = await repo.CreateOneAsync(customer);

            Assert.AreEqual(customer.FirstName, created.FirstName);
            Assert.AreEqual(customer.Surname, created.Surname);
            Assert.AreEqual(customer.DateOfBirth, created.DateOfBirth);
            Assert.AreEqual(customer.Telephone, created.Telephone);
        }

        [TestMethod]
        public async Task CustomerRepo_UpdateEntity_OK()
        {
            var customer = CreateNew();

            var created = await repo.CreateOneAsync(customer);

            created.FirstName = "Douglas";

            var updated = await repo.UpdateOneAsync(created);

            Assert.AreEqual(updated.FirstName, created.FirstName);
            Assert.AreEqual(updated.Surname, created.Surname);
            Assert.AreEqual(updated.DateOfBirth, created.DateOfBirth);
            Assert.AreEqual(updated.Telephone, created.Telephone);
        }

        private Customer CreateNew()
        {
            return new Customer("Zaphod", "Beeblebrox", "01234 567890", DateTime.Parse("01/01/1900"));
        }
    }
}