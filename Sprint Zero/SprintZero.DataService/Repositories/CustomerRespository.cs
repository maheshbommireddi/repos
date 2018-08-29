using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprintZero.Core;
using SprintZero.Core.Entities;
using SprintZero.Core.Models;

namespace SprintZero.DataService.Repositories
{
    public class CustomerRespository : ICustomerRespository
    {
        static SqlConnection GetConnection()
        {
            string connectionsString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\MovieDataBase.mdf;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";

            SqlConnection connection = new SqlConnection(connectionsString);
            return connection;
        }
        static SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
        static DataSet dataSet = new DataSet();
        static DataTable dataTable ;
        const string CUSTOMER = "Customer";

      //  private static void 




        private List<CustomerEntity> customer = new List<CustomerEntity>();
       
        public List<CustomerEntity> GetCustomerEntities()
        {
            return _customerListings;
        }
        public void AddTestCoustomerEntity(CustomerEntity customerE)
        {
            customer.Add(customerE);
        }


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
            return customer;
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
