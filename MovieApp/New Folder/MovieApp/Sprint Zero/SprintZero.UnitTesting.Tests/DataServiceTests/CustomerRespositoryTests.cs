using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SprintZero.DataService.Repositories;
using SprintZero.Core.Entities;

namespace SprintZero.UnitTesting.Tests.DataServiceTests
{

    [TestClass]
    public class CustomerRespositoryTests
    {
        public CustomerRespositoryTests()
        {
        }

        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }


        [TestMethod]
        public void GetAllCustomerEntitiesTest()
        {

            CustomerRespository _repository = new CustomerRespository(MockedData());
            var result = _repository.GetAllCustomerEntities();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<CustomerEntity>));
            Assert.AreEqual(2, result.Count);
        }


        [TestMethod]
        public void GetCustomerEntityTest()
        {
            int id = 2;
            CustomerRespository _repository = new CustomerRespository(MockedData());

            var result = _repository.GetCustomerEntity(id);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(CustomerEntity));
        }



        [TestMethod]
        public void AddCoustomerEntityTest()
        {

            CustomerRespository _repository = new CustomerRespository(MockedData());
            CustomerEntity cust = new CustomerEntity
            {
                Id = 4,
                FirstName = "Satya",
                LastName = "Bommireddi",
                StreetAddress = "rega",
                City = "StCloud",
                State = "MN",
                ZipCode = "56301",
                PhoneNumber = unchecked((int)6469233340),
                BirthData = "1/1/2017",
                EmailAddress = "mahesh@gmail.com"
            };

            _repository.AddCoustomerEntity(cust);
            var result = _repository.GetAllCustomerEntities();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<CustomerEntity>));
            Assert.AreEqual(3, result.Count);

        }


        [TestMethod]
        public void EditCustomerEntityTest()
        {
            int id = 2;
            CustomerRespository _repository = new CustomerRespository(MockedData());
            var data = _repository.GetCustomerEntity(id);
            data.City = "MSP";
            _repository.EditCustomerEntity(data);
           var result = _repository.GetCustomerEntity(id);
            Assert.IsNotNull(result.City);
            Assert.AreEqual("MSP", result.City);
        }


        [TestMethod]
        public void DeleteCustomerByIdTest()
        {
            int id = 2;
            CustomerRespository _repository = new CustomerRespository(MockedData());
             _repository.DeleteCustomerById(id);                 
            var result = _repository.GetCustomerEntity(id);
            Assert.AreEqual(null, result);
        }


        private List<CustomerEntity> MockedData()
        {
            return new List<CustomerEntity>
            {
                new CustomerEntity
                {

                        Id = 2,
                    FirstName = "Satya",
                    LastName = "Bommireddi",
                    StreetAddress = "rega",
                    City ="StCloud",
                    State = "MN",
                    ZipCode = "56301",
                    PhoneNumber =  unchecked((int)6469233340),
                    BirthData ="1/1/2017",
                    EmailAddress ="mahesh@gmail.com"

                },
                  new CustomerEntity
                {

                    Id = 3,
                    FirstName = "Satya",
                    LastName = "Bommireddi",
                    StreetAddress = "rega",
                    City ="StCloud",
                    State = "MN",
                    ZipCode = "56301",
                    PhoneNumber =  unchecked((int)6469233340),
                    BirthData ="1/1/2017",
                    EmailAddress ="mahesh@gmail.com"

                }
            };
        }

    }
}
