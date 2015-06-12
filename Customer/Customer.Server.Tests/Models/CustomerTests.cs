using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomerSite.Server.Tests.Models
{
    [TestClass]
    public class CustomerTests
    {
        private CustomerSite.Server.Models.Customer customer;

        private const string firstName = "Zaphod";
        private const string lastName = "Beeblebrox";
        private const string telephone = "01234 567 890";
        private readonly DateTime dateOfBirth = DateTime.Parse("01/01/1900");


        [TestInitialize]
        public void Setup()
        {
            customer = new Server.Models.Customer(firstName, lastName, telephone, dateOfBirth);
        }

        [TestMethod]
        public void CustomerTests_Init_Ok()
        {
            Assert.AreEqual(customer.FirstName, firstName);
            Assert.AreEqual(customer.Surname, lastName);
            Assert.AreEqual(customer.Telephone, telephone);
            Assert.AreEqual(customer.DateOfBirth, dateOfBirth);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CustomerFirstName_SetToNull_Throw()
        {
            customer.FirstName = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CustomerLastName_SetToNull_Throw()
        {
            customer.Surname = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CustomerTelephone_SetToNull_Throw()
        {
            customer.Telephone = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CustomerDateOfBirth_SetToInvalidDateInFuture_Throw()
        {
            customer.DateOfBirth = DateTime.UtcNow.AddDays(1);
        }
    }
}
