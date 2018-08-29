using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprintZero.Core;
using SprintZero.Core.Entities;
using SprintZero.Core.Models;

namespace SprintZero.DataService.Repositories
{
    public class CustomerRespository
    {

        private List<CustomerEntity> _customerListings; //{ get; set; }

        public CustomerRespository()
        {
            _customerListings = new List<CustomerEntity>
            {
                new CustomerEntity
                {
                    Id = 1,
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


        public CustomerRespository(List<CustomerEntity> CourseListings)
        {
            _customerListings = CourseListings;
        }

        public List<CustomerEntity> GetAllCustomerEntities()
        {
            return _customerListings;
        }

        public CustomerEntity GetCustomerEntity(int? id)
        {
            return _customerListings.FirstOrDefault(i => i.Id == id);
        }

        

         public void  AddCoustomerEntity(CustomerEntity customer)
        {
             _customerListings.Add(customer);        
        }

        public void EditCustomerEntity(CustomerEntity customer)
        {
            CustomerEntity customerEntity = GetCustomerEntity(customer.Id);
            _customerListings.Remove(customerEntity);
            customerEntity = customer;
            _customerListings.Add(customerEntity);
        }

        public void DeleteCustomerById(int? Id)
        {
            CustomerEntity customerEntity = GetCustomerEntity(Id);
            _customerListings.Remove(customerEntity);
        }
    }
}
